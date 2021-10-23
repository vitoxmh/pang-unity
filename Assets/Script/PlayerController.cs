using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public float Speed;
    public float timeStop;
    private float deltaStop;
    private Rigidbody2D rg;
    private float horizontal;
    private float vertical;
    private Animator Animator;
    private int deltaFire;
    public bool usingLadder = false;
    public GameObject[] armPreFabs;
    public int typeArms;
    public int maxFire;
    public bool onLadder = false;
    public float exitHop = 3f;
    public bool Grounded;
    public Vector2 posLadder;
    private Sprite[] textures;
    private SpriteRenderer sr;
    public int maxShot;
    private float detalDelayBang;
    public bool stateFreeze;
    private int nRebote;
    public bool wallLeft;
    public bool wallRigth;
    public bool fly;
    public bool newLadder; 


    /************************************
    
    Animation: 
        0: Idle
        1 Walk
        2: Fire
        3: UpLadder
    */

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        textures = Resources.LoadAll<Sprite>("Sprites/player/upladder");
        sr = GetComponent<SpriteRenderer>();
        detalDelayBang = Time.time;
        nRebote = 0;



    }

    // Update is called once per frame
    void Update()
    {




        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");






        if (!stateFreeze)
        {

            if (horizontal < 0.0f) transform.localScale = new Vector3(-4.0f, 4.0f, 4.0f);
            else if (horizontal > 0.0f) transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        }



        if (!stateFreeze)
        {
            fire();
        }


        isGrounded();



        if (!stateFreeze)
        {
            if (deltaStop >= Time.time)
            {
                rg.velocity = Vector2.zero;
           
                Animator.SetInteger("PlayerAnimation", 2);
           

            }
            else
            {

           

                    ladder();
            

            }
        }

        if (GameManager.gm.Lose)
        {
            rg.gravityScale = 3;
            
        }



    }


    private void ladder()
    {


        


    }



    private void isGrounded()
   {

        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.3f), Vector3.down * 0.4f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.4f), Vector3.down, 0.3f);


  
        if (hit.collider != null)
        {
      
            if (hit.collider.tag == "piso" || hit.collider.tag == "block")
            {

                Grounded = true;

               
            }
            else
            {
                Grounded = false;
               
            }


        }
        else
        {
            Grounded = false;
         
        }
    }


    private void fire()
    {


    

        if (Input.GetKeyDown(KeyCode.E) && (GameObject.FindGameObjectsWithTag("arma").Length < maxShot) && Grounded)
        {

            deltaStop = Time.time + timeStop;
            Instantiate(armPreFabs[3], new Vector3(transform.position.x, transform.position.y+0.81f, -1f), Quaternion.identity);
            if (typeArms == 2)
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
                //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("FireBullet");
                SoundManager.sm.play("FireBullet");

            }
            else
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y - 0.6f, 1f), Quaternion.identity);
                //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("Firehook");
                SoundManager.sm.play("Firehook");



            }
           
        }
        else if (Input.GetKeyDown(KeyCode.E) && (GameObject.FindGameObjectsWithTag("arma").Length < maxShot) && !Grounded && onLadder)
        {

            deltaStop = Time.time + timeStop;
            Instantiate(armPreFabs[3], new Vector3(transform.position.x, transform.position.y+ 0.81f, -1f), Quaternion.identity);
            if (typeArms == 2)
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
                //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("FireBullet");
                SoundManager.sm.play("FireBullet");

            }
            else
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y - 0.6f, 1f), Quaternion.identity);
         
                SoundManager.sm.play("Firehook");
            }

        }




    }


    private void OnTriggerStay2D(Collider2D other)
    {




    }


    void OnTriggerEnter2D(Collider2D other)
    {



        if ((other.tag == "piso") && nRebote == 0)
        {

            rg.velocity = new Vector2(-1f, 5f);
            
           
            nRebote++;

        }



        if ((other.tag == "Wall") && GameManager.gm.Lose && (nRebote == 0 || nRebote == 1))
        {

            rg.velocity *= -1;
            //rg.velocity = new Vector2(2f, 5f);
            nRebote++;
        }




    }

    private void OnTriggerExit2D(Collider2D other)
    {
       

        if (other.tag == "RebootStage")
        {


            GameManager.gm.respawn();

        }

        if (other.tag == "Wall")
        {


            GameManager.gm.respawn();

        }



    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "item")
        {
            
            SoundManager.sm.play("GetItem");



        }


        if (col.gameObject.tag == "ball" && !BallManager.bm.freeze)
        {

            col.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;

            dead();

        }



        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "blockVertical")
        {


            if (col.contacts[0].normal.x > 0)
            {
                wallLeft = true;

            }
            else if (col.contacts[0].normal.x < 0)
            {
                wallRigth = true;

            }


        }





    }



    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "blockVertical")
        {
          

            if (col.contacts[0].normal.x > 0)
            {
                wallLeft = true;

            }
            else if (col.contacts[0].normal.x < 0)
            {
                wallRigth = true;

            }

        }



        if (col.gameObject.tag == "block" || col.gameObject.tag == "piso" || col.gameObject.tag == "blockVertical")
        {


            fly = false;
        }



    }



    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "blockVertical")
        {

            wallLeft = false;
            wallRigth = false;

   


        }

        if (col.gameObject.tag == "block" || col.gameObject.tag == "piso" || col.gameObject.tag == "blockVertical")
        {
           

            fly = true;
        }
    }


    public void dead()
    {
        GameManager.gm.frezzerAll();
        GameManager.gm.Lose = true;
        rg.velocity = Vector2.zero;
        Animator.speed = 0;
        rg.isKinematic = true;
       

        BallManager.bm.unTriggerColliderBall();

        StartCoroutine(throwPlayer());


    }


    public IEnumerator throwPlayer()
    {


        yield return new WaitForSeconds(1f);
        rg.gravityScale = 3;
        SoundManager.sm.play("Lose");

        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        rg.isKinematic = false;

        Animator.SetInteger("PlayerAnimation", 10);
        

        rg.gravityScale = 3f;

        if (transform.position.x <= 0)
        {
            //rg.velocity = new Vector2(-2f, 7f);
            rg.isKinematic = false;
            rg.AddForce(new Vector2(-4,40), ForceMode2D.Impulse);

        }
        else
        {
            //rg.velocity = new Vector2(2f, 7f);
            rg.isKinematic = false;
            rg.AddForce(new Vector2(4, 40), ForceMode2D.Impulse);

        }
        



    }



}
