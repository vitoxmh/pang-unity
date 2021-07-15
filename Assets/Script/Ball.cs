using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float starForce;

    private Rigidbody2D rb;
    private CircleCollider2D circle;
    private float x, y;
   

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
        circle = GetComponent<CircleCollider2D>();
        x = -1f;
  


    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = transform.position;
        temp.x = temp.x + (starForce * Time.deltaTime * x);

        transform.position = temp;

    }


    private void FixedUpdate()
    {


        
    }



    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("cuerpo"))
        {
            x = x * -1f;
            
        }

        if (col.CompareTag("piso"))
        {
            rb.velocity = new Vector2(0, 6f);
        }


    }



    void OnTriggerExit2D(Collider2D other)
    {


        if (other.CompareTag("cuerpo"))
        {
            

           
        }

    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "piso")
        {
           

        }
            
    }




}