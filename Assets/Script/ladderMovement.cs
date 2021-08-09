using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float climbSpeed;
    private GameObject tope;


    void Start()
    {
      

        //controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {

       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
       
        if(other.tag == "Player" && Input.GetAxisRaw("Vertical") != 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxisRaw("Vertical"));
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
            //transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
            tope = transform.GetChild(0).gameObject;
            tope.GetComponent<BoxCollider2D>().enabled = false;
            //transform.GetChild(1).


            Debug.Log("00");
        }

        else if (other.tag == "Player" && Input.GetAxisRaw("Vertical") == 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Debug.Log("02");
        }



    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 1;

        }


    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 1;

        }

    }



}
