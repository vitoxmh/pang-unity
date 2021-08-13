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
    public bool usingLadder = false;
    public GameObject[] armPreFabs;
    public int typeArms;
    public int maxFire;
    private int deltaFire;
    public bool onLadder = false;
    public float climbSpeed;
    public float exitHop = 3f;
    public bool Grounded;
    public GameObject posLadder;
    private Sprite[] textures;
    private SpriteRenderer sr;
    public int downLadder;
    public int maxShot;
    public AudioSource audio;

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



    }

    // Update is called once per frame
    void Update()
    {



        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-4.0f, 4.0f, 4.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        fire();
        countBall();
        isGrounded();
       

        if (deltaStop >= Time.time)
        {
            rg.velocity = Vector2.zero;
            //Animator.SetBool("fire", true);
            Animator.SetInteger("PlayerAnimation", 2);
            Debug.Log("01");

        }
        else
        {
            if (!onLadder)
            {
                rg.velocity = new Vector2(horizontal * Speed, rg.velocity.y);

                Animator.SetInteger("PlayerAnimation", 1);
            }
            

            ladder();

        }


    }


    private void FixedUpdate()
    {


    }



   private void isGrounded()
   {

        Debug.DrawRay(transform.position, Vector3.down * 0.67f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.67f);
  
        if (hit.collider != null)
        {

            if (hit.collider.tag == "piso" || hit.collider.tag == "ladderTop")
            {

                Grounded = true;
                Debug.Log("0001");

            }
            else
            {
                Grounded = false;
                Debug.Log("0002");
            }


            if(hit.collider.tag == "ladderTop" && vertical < 0.0f)
            {
                Debug.Log("Baja escalera");

                hit.collider.gameObject.GetComponentInChildren<BoxCollider2D >().enabled = false;
                Animator.SetInteger("PlayerAnimation", 5);


            }
            else
            {

            }


        }
        else
        {
            Grounded = false;
            Debug.Log("0002");
        }
    }


    private void fire()
    {


        //Debug.Log(maxShot + "====" + GameObject.FindGameObjectsWithTag("arma").Length);

        if (Input.GetKeyDown(KeyCode.E) && (GameObject.FindGameObjectsWithTag("arma").Length < maxShot) && Grounded)
        {

            deltaStop = Time.time + timeStop;

            if(typeArms == 2)
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
            }
            else
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y - 0.6f, 1f), Quaternion.identity);
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.E) && (GameObject.FindGameObjectsWithTag("arma").Length < maxShot) && !Grounded && onLadder)
        {

            deltaStop = Time.time + timeStop;

            if (typeArms == 2)
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
            }
            else
            {
                Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y - 0.6f, 1f), Quaternion.identity);
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
            posLadder = other.gameObject;
            other.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
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

            downLadder = 0;

        }


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "item")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }


    private void ladder()
    {

            
            if (onLadder && Grounded && vertical > 0 && horizontal == 0)
            {

                rg.velocity = new Vector2(0, vertical * climbSpeed);
                rg.gravityScale = 0;
                downLadder = 1;
                transform.position = new Vector2(posLadder.transform.position.x, transform.position.y);

                //Animator.SetBool("upLadder", true);
                //Animator.SetBool("run", false);
                //Animator.SetBool("UpladderIdle", false);
                Animator.SetInteger("PlayerAnimation", 3);
                Debug.Log("eSCALERA 01");

            }
            if (!onLadder && Grounded && vertical < 0 && horizontal == 0)
            {

                rg.velocity = new Vector2(0, vertical * climbSpeed);
                rg.gravityScale = 0;

                transform.position = new Vector2(posLadder.transform.position.x, transform.position.y);

                //Animator.SetBool("upLadder", true);
                //Animator.SetBool("run", false);
                //Animator.SetBool("UpladderIdle", false);
                Animator.SetInteger("PlayerAnimation", 5);
                Debug.Log("eSCALERA 0101");

            }
            else if (onLadder && Grounded && vertical == 0 && horizontal == 0)
            {
                rg.velocity = new Vector2(0, 0);
                rg.gravityScale = 0;
                downLadder = 0;
                Animator.SetInteger("PlayerAnimation", 0);
                Debug.Log("eSCALERA 02");
            }
            else if (onLadder && !Grounded && vertical == 0 && horizontal == 0)
            {
                rg.velocity = new Vector2(0, 0);
                rg.gravityScale = 0;

                if(downLadder == 0)
                {
                    Animator.SetInteger("PlayerAnimation", 5);
                   
                }
                else if (downLadder == 1)
                {
                    Animator.SetInteger("PlayerAnimation", 4);
                }
                else
                {
                    Animator.SetInteger("PlayerAnimation", 4);
                    downLadder = 1;
                }
                

                Debug.Log("eSCALERA 03");
            }
            else if (onLadder && !Grounded && vertical != 0 && horizontal == 0)
            {
                rg.velocity = new Vector2(0, vertical * climbSpeed);
                rg.gravityScale = 0;

                if(vertical < 0 && downLadder == 0)
                {
                    Animator.SetInteger("PlayerAnimation", 5);
                    downLadder = 1;
                    Debug.Log("aaaaaa");


                }
                if (vertical > 0 && downLadder == 0)
                {

                    Animator.SetInteger("PlayerAnimation", 5);
                  

                }
                else {
                    Animator.SetInteger("PlayerAnimation", 3);
                    Debug.Log("bbbb");
                }

            



                Debug.Log("eSCALERA 04");

            }
            else if (onLadder && Grounded && vertical == 0 && horizontal != 0)
            {
                rg.velocity = new Vector2(horizontal * Speed, rg.velocity.y);
                rg.gravityScale = 1;
                Animator.SetInteger("PlayerAnimation", 1);
                Debug.Log("eSCALERA 05");

            }
            else if (!onLadder)
            {

                //Debug.Log("eSCALERA 06");
              
                if(horizontal != 0)
                {
                    Animator.SetInteger("PlayerAnimation", 1);
                }
                else
                {

                    Animator.SetInteger("PlayerAnimation", 0);
                }


            }
        
    }




    void Animations(string animation)
    {

        switch (animation)
        {

            case "run":
            
            
            break;

        }


    }


}
