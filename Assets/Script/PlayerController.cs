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
    public float climbSpeed;
    public float exitHop = 3f;
    public bool Grounded;
    public Vector2 posLadder;
    private SpriteRenderer sr;
    public int downLadder;
    public int maxShot;
    public bool ladderFooter;
    public bool ladderTop;
    public bool ladderExit;
    public bool ladderTopExit;
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
        sr = GetComponent<SpriteRenderer>();
        downLadder = 0;
        ladderFooter = false;
        ladderTop = false;
        ladderExit = false;
        ladderTopExit = false;
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


        if (ladderExit && vertical < 0 && ladderTop)
        {
            
            Animator.SetInteger("PlayerAnimation", 5);

            ladderExit = false;
            return;

        }


        if (vertical > 0 && ladderTopExit)
        {

            Animator.SetInteger("PlayerAnimation", 5);


            return;

        }


        if (ladderExit && vertical > 0 && ladderTopExit)
        {

            Animator.SetInteger("PlayerAnimation", 5);
            ladderTopExit = false;

            return;

        }




        if (ladderFooter)
        {
            if(vertical > 0)
            {
                transform.position = new Vector3(posLadder.x, transform.position.y + 0.05f, transform.position.z);
                 
               
                Animator.SetInteger("PlayerAnimation", 3);
            }
            else
            {
                if(horizontal == 0)
                {

                    transform.Translate(0, 0, 0);
                    Animator.SetInteger("PlayerAnimation", 0);
                   

                }
                else if(horizontal < 0)
                {
                    if(wallLeft)
                    {
                        transform.Translate(0, 0, 0);
                    }
                    else
                    {
                        transform.Translate(-2 * Time.deltaTime * Speed, 0, 0);
                    }
                    
                    Animator.SetInteger("PlayerAnimation", 1);

                }
                else if (horizontal > 0)
                {
                    if (wallRigth)
                    {

                        transform.Translate(0, 0, 0);
                    }
                    else
                    {
                        transform.Translate(2 * Time.deltaTime * Speed, 0, 0);
                    }
                   
                    Animator.SetInteger("PlayerAnimation", 1);

                }
            }
        }
        else
        {

            if (onLadder)
            {


                if (vertical > 0)
                {
                    transform.Translate(0, 2 * Time.deltaTime * Speed, 0);
                    Animator.SetInteger("PlayerAnimation", 3);

                }
                else if(vertical < 0)
                {
                    transform.Translate(0, -2 * Time.deltaTime * Speed, 0);
                    Animator.SetInteger("PlayerAnimation", 3);

                }
                else if(vertical == 0)
                {
                    transform.Translate(0, 0, 0);
                    Animator.SetInteger("PlayerAnimation", 4);
                    rg.velocity = Vector2.zero;
                }

            }
            else
            {
                
                if (horizontal == 0)
                {

                    transform.Translate(0, 0, 0);
                    Animator.SetInteger("PlayerAnimation", 0);

                }
                else if (horizontal < 0)
                {
                    if(wallLeft)
                    {
                        transform.Translate(0, 0, 0);
                    }
                    else
                    {
                        if (!fly && !onLadder) { 
                            transform.Translate(-2 * Time.deltaTime * Speed, 0, 0);
                            rg.gravityScale = 1;
                        }
                        else
                        {
                            transform.Translate(-2 * Time.deltaTime * 1.3f, 0, 0);
                            rg.gravityScale = 3;
                        }
                    }
                   
                    Animator.SetInteger("PlayerAnimation", 1);

                }
                else if (horizontal > 0)
                {


                    if (wallRigth)
                    {
                        transform.Translate(0, 0, 0);
                    }
                    else 
                    {
                        if (!fly && !onLadder) { 
                            
                            transform.Translate(2 * Time.deltaTime * Speed, 0, 0);
                            rg.gravityScale = 1;

                        } else{


                            transform.Translate(2 * Time.deltaTime * 1.3f, 0, 0);
                            rg.gravityScale = 3;
                        }
                    }

                    
                    Animator.SetInteger("PlayerAnimation", 1);

                }


            }


        }


    }



    private void isGrounded()
   {

        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.3f), Vector3.down * 0.4f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.4f), Vector3.down, 0.3f);


  
        if (hit.collider != null)
        {
      
            if (hit.collider.tag == "piso" || hit.collider.tag == "ladderTop" || hit.collider.tag == "block" || hit.collider.tag == "ladderFooter")
            {

                Grounded = true;

               
            }
            else
            {
                Grounded = false;
               
            }


            if(hit.collider.tag == "ladderTop" && vertical < 0.0f)
            {
       
               
                posLadder = hit.collider.gameObject.transform.position;
                hit.collider.gameObject.GetComponentInChildren<BoxCollider2D >().enabled = false;

                transform.position = new Vector3(posLadder.x, transform.position.y - 0.05f, transform.position.z);
                ladderTop = true;


            }
            else
            {

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
            Instantiate(armPreFabs[3], new Vector3(transform.position.x, transform.position.y+0.81f, transform.position.z+1f), Quaternion.identity);
            if (typeArms == 2)
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("FireBullet");
                SoundManager.sm.play("FireBullet");

            }
            else
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z+1f), Quaternion.identity);
                //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("Firehook");
                SoundManager.sm.play("Firehook");



            }
           
        }
        else if (Input.GetKeyDown(KeyCode.E) && (GameObject.FindGameObjectsWithTag("arma").Length < maxShot) && !Grounded && onLadder)
        {

            deltaStop = Time.time + timeStop;
            Instantiate(armPreFabs[3], new Vector3(transform.position.x, transform.position.y+ 0.81f, transform.position.z + 1f), Quaternion.identity);
            if (typeArms == 2)
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);
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

        if (other.tag == "ladder")
        {
            onLadder = true;

            posLadder = other.gameObject.transform.position;

            if(GameManager.gm.Lose)
            {
                rg.gravityScale = 3;
       
            }
            else
            {
                rg.gravityScale = 0;

           
            }
            


            other.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        }

        if (other.tag == "ladderFooter")
        {
            ladderFooter = true;
        }

        if (other.tag == "ladderExit")
        {

            ladderExit = true;

        }

        if (other.tag == "ladderTopExit")
        {

            ladderTopExit = true;
     

        }


        if ((other.tag == "piso") && nRebote == 0)
        {

            rg.velocity = new Vector2(-1f, 5f);
            
           
            nRebote++;

        }



        if ((other.tag == "Wall") && GameManager.gm.Lose && (nRebote == 0 || nRebote == 1))
        {

            rg.velocity *= -1;
           
            nRebote++;
        }




    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ladder")
        {
            onLadder = false;
            rg.gravityScale = 1;

            other.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
         
        }


        if (other.tag == "ladderExit")
        {

            ladderExit = false;

        }



        if (other.tag == "ladderFooter")
        {
            ladderFooter = false;
        }


        if (other.tag == "ladderTopExit")
        {

            ladderTopExit = false;


        }


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



        if (col.gameObject.tag == "ladderTop" || col.gameObject.tag == "block" || col.gameObject.tag == "piso" || col.gameObject.tag == "blockVertical")
        {
            Debug.Log("En escalera");

            fly = false;
        }

        if (col.gameObject.tag == "block") {

            Grounded = true;


        }



    }



    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "blockVertical")
        {

            wallLeft = false;
            wallRigth = false;

   


        }



        if (col.gameObject.tag == "ladderTop" || col.gameObject.tag == "block" || col.gameObject.tag == "piso" || col.gameObject.tag == "blockVertical")
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





    public void exitLadder()
    {
        ladderTopExit = false;
    }






}
