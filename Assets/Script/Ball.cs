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
    private float speedBall;
    private float ballBounce;
    public float timeInvisible;
    private float deltaInvisible;
    private int maxExplotion;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        
        getSizeBall();

        // Indica la direccion de la Bola al iniciar
        if (directionBallLeft)
        {
            x = speedBall * -1f;
        }
        else
        {
            x = speedBall;
        }
        
        // Carga las texturas de las Bolas
        textures = Resources.LoadAll<Sprite>("Sprites/ball");

        deltaInvisible = Time.time + deltaInvisible;
        maxExplotion = 0;


    }

    // Update is called once per frame
    void Update()
    {


        if (deltaInvisible <= Time.time)
        {
            circle.enabled = true;
        }
        else
        {

            circle.enabled = false;
        }

            Vector3 temp = transform.position;

        // Movimiento de la Bola de Derecha a Izquierda
        temp.x = temp.x + (starForce * Time.deltaTime * x);

        transform.position = temp;
        
        // Escala de la Bola
        transform.localScale = size;

        // Carga la textura de la Bola seleccionada
        // 0 - Azul / 1 - Rojo / 2 - Verde
        sr.sprite = textures[colorBall];

       
    }


    private void FixedUpdate()
    {

        
        
    }

    // Instancia el tipo de Bola
    void getSizeBall()
    {
        switch (sizeBall)
        {
            case 0:
                size = new Vector3(5f, 6f, 1f);
                speedBall = 1f;
                ballBounce = 11.5f;
                break;
            case 1:
                size = new Vector3(2.5f, 3f, 1f);
                speedBall = 0.8f;
                ballBounce = 9.5f;
                break;
            case 2:
                size = new Vector3(1.25f, 1.5f, 1f);
                speedBall = 0.7f;
                ballBounce = 7f;
                break;
            case 3:
                size = new Vector3(0.5f, 0.5f, 1f);
                speedBall = 0.6f;
                ballBounce = 6f;
                break;
        }

    }




    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("pared"))
        {
            x = x * -1f;
            
        }

        if (col.CompareTag("piso"))
        {
            rb.velocity = new Vector2(0, ballBounce);
        }


        if (col.CompareTag("techo"))
        {
            rb.velocity = new Vector2(0, -ballBounce);
        }


        if (col.CompareTag("arma"))
        {

            // Clona una bola mas chica hasta que sea la mas chica

            GameObject newBall = gameObject;

            if (gameObject.GetComponent<Ball>().sizeBall < 3 && maxExplotion == 0)
            {
                GameObject newBall01;
                GameObject newBall02;

                newBall.transform.localScale = new Vector3(2f, 2.5f, 0);
                newBall.GetComponent<Ball>().directionBallLeft = true;
                newBall.GetComponent<Ball>().sizeBall += 1;

                newBall01 = Instantiate(newBall, rb.position + Vector2.left, Quaternion.identity);

                newBall.GetComponent<Ball>().directionBallLeft = false;
                newBall02 = Instantiate(newBall, rb.position, Quaternion.identity);
                
                // Hace un salto 
                newBall01.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
                newBall02.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
                maxExplotion++;

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