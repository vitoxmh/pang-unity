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



    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");



        if (horizontal < 0.0f) transform.localScale = new Vector3(-4.0f, 4.0f, 4.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);


        Animator.SetBool("run", horizontal != 0.0f);
        fire();
        countBall();

    }


    private void FixedUpdate()
    {


        if (deltaStop >= Time.time)
        {
            rg.velocity = Vector2.zero;
            Animator.SetBool("fire", true);

        }
        else
        {

            rg.velocity = new Vector2(horizontal * Speed, rg.velocity.y);
            Animator.SetBool("fire", false);
        }

    }



    private void fire()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {

            deltaStop = Time.time + timeStop;

            Instantiate(armPreFabs[typeArms], new Vector3(transform.position.x, transform.position.y - 0.6f, 1f), Quaternion.identity);


        }

    }


    public void countBall()
    {

      

        Debug.Log("N ball: " + GameObject.FindGameObjectsWithTag("ball").Length);


    }

    void OnCollisionEnter2D(Collision2D col)
    {

       
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        
    }

}
