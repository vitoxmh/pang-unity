using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float starForce;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private CircleCollider2D circle;
    private float x, y;
    private Sprite[] textures;
    public int colorBall;
    public bool directionBallLeft;
    public int sizeBall;
    private Vector3 size;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        if(directionBallLeft)
        {
            x = -1f;
        }
        else
        {
            x = 1f;
        }
       
        textures = Resources.LoadAll<Sprite>("Sprites/ball");
        FixedUpdate();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = transform.position;

        
        temp.x = temp.x + (starForce * Time.deltaTime * x);

        transform.position = temp;
        
        transform.localScale = size;

        sr.sprite = textures[colorBall];


    }


    private void FixedUpdate()
    {

        switch (sizeBall)
        {
            case 0:
                size = new Vector3(4f, 5f, 1f);
            break;
            case 1:
              size = new Vector3(2f, 2.5f, 1f);
            break;
            case 2:
                size = new Vector3(1f, 1.25f, 1f);
            break;
            case 3:
                size = new Vector3(0.5f, 0.5f, 1f);
            break;
        }
        
    }


    void getSizeBall()
    {


    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("pared"))
        {
            x = x * -1f;
            
        }

        if (col.CompareTag("piso"))
        {
            rb.velocity = new Vector2(0, 6f);
        }


        if (col.CompareTag("techo"))
        {
            rb.velocity = new Vector2(0, -6f);
        }


        if (col.CompareTag("arma"))
        {

            GameObject newBall = gameObject;
            if (gameObject.GetComponent<Ball>().sizeBall < 3)
            {
                newBall.transform.localScale = new Vector3(2f, 2.5f, 0);
                newBall.GetComponent<Ball>().directionBallLeft = true;
                newBall.GetComponent<Ball>().sizeBall += 1;
                Instantiate(newBall, rb.position + Vector2.left, Quaternion.identity);
                newBall.GetComponent<Ball>().directionBallLeft = false;
                Instantiate(newBall, rb.position, Quaternion.identity);
            }
          

            Destroy(gameObject, (float)0);
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