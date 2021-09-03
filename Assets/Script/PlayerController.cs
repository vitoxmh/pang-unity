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
    private Sprite[] textures;
    private SpriteRenderer sr;
    public int downLadder;
    public int maxShot;
    public bool ladderFooter;
    public bool ladderTop;
    public bool ladderExit;
    public bool ladderTopExit;
    private float detalDelayBang;
    public bool stateFreeze;

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
        downLadder = 0;
        ladderFooter = false;
        ladderTop = false;
        ladderExit = false;
        ladderTopExit = false;
        detalDelayBang = Time.time;
     



    }

    // Update is called once per frame
    void Update()
    {



        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (!stateFreeze)
        {

            if (horizontal < 0.0f) transform.localScale = new Vector3(-4.0f, 4.0f, 4.0f);
            else if (horizontal > 0.0f) transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        }

        if (!stateFreeze)
        {
            fire();
        }
        countBall();
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
                transform.position = new Vector2(posLadder.x, transform.position.y + 0.05f);
                 
               
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

                    transform.Translate(-2 * Time.deltaTime * Speed, 0, 0);
                    Animator.SetInteger("PlayerAnimation", 1);

                }
                else if (horizontal > 0)
                {

                    transform.Translate(2 * Time.deltaTime * Speed, 0, 0);
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

                    transform.Translate(-2 * Time.deltaTime * Speed, 0, 0);
                    Animator.SetInteger("PlayerAnimation", 1);

                }
                else if (horizontal > 0)
                {

                    transform.Translate(2 * Time.deltaTime * Speed, 0, 0);
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

                transform.position = new Vector2(posLadder.x, transform.position.y - 0.05f);
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

            if(typeArms == 2)
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


    public void countBall()
    {

     
        Debug.Log("N ball: " + GameObject.FindGameObjectsWithTag("ball").Length);


    }

    private void OnTriggerStay2D(Collider2D col)
    {
       

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "ladder")
        {
            onLadder = true;
            //posLadder = new Vector2(other.gameObject.transform.position.x + 0.05f, transform.position.y);
            posLadder = other.gameObject.transform.position;
            rg.gravityScale = 0;
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
            Debug.Log("tOCA CIELO");

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
            Debug.Log("tOCA CIELO");

        }


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "item")
        {
            //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("GetItem");
            SoundManager.sm.play("GetItem");
        }
    }






    public void exitLadder()
    {
        ladderTopExit = false;
    }



    public void BangAllBall()
    {

        if (Time.time > detalDelayBang)
        {


            detalDelayBang = Time.time + 0.35f;

            GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

            for (int i = 0; i <= arrayBall.Length; i++)
            {

                if (arrayBall[i].GetComponent<Ball>().sizeBall < 3)
                {
                    arrayBall[i].GetComponent<Ball>().bangBall();
                }


            }

        }

    }



}
