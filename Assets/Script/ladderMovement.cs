using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rg;
    private float vertical;
    private Animator Animator;
    //PlayerController controller;
 
    public bool onLadder = false;
    public float climbSpeed;
    public float exitHop = 3f;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        //controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {

       
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("ladder"))
        {
           
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                rg.velocity = new Vector2(rg.velocity.x, Input.GetAxisRaw("Vertical") * climbSpeed);
                rg.gravityScale = 0;
                onLadder = true;
                col.gameObject.GetComponent<BoxCollider>();
                col.gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
                Animator.SetBool("upLadder", true);
                Animator.SetBool("UpladderIdle", false);


            }
            else if(Input.GetAxisRaw("Vertical") == 0 && onLadder)
            {
                rg.velocity = new Vector2(rg.velocity.x, 0);
                Animator.SetBool("UpladderIdle", true);
                Animator.SetBool("upLadder", true);



            }

  
        }


        
    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("ladder") && onLadder)
        {
          
            rg.gravityScale = 1;
            onLadder = false;
            other.gameObject.GetComponents<BoxCollider2D>()[1].enabled = true;
            Animator.SetBool("upLadder", false);
            Animator.SetBool("UpladderIdle", false);
            Debug.Log("Sale de la escaler");

        }
    }



}
