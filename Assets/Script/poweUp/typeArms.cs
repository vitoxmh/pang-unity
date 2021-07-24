using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeArms : MonoBehaviour
{
    private Rigidbody2D rb;
    private float touchFloor;
    public int typeArm;
    private BoxCollider2D collider;
    public AudioSource[] EffectsSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        //touchFloor = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        
  
    }
     
    void FixedUpdate()
    {
       // transform.position += Vector3.down * touchFloor * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("piso"))
        {
            touchFloor = 0f;
            collider.isTrigger = true;
            rb.gravityScale = 0f;
        }


        if (col.CompareTag("Player"))
        {
            Destroy(gameObject, (float)0);
            col.gameObject.GetComponent<PlayerController>().typeArms = typeArm;
        }

        Debug.Log("Toca");

    }


    void OnTriggerStay2D(Collider2D col)
    {


       
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject, (float)0);
            col.gameObject.GetComponent<PlayerController>().typeArms = typeArm;
        }
    }


}
