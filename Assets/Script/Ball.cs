using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     
    public float starForce;
    public GameObject[] explotionPreFabs;
    public bool isFreeze;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private CircleCollider2D circle;
    private float x, y;
    private Sprite[] textures;
    public bool stateSlow;
    public int colorBall;
    public bool directionBallLeft;
    public int sizeBall;
    public int scoreBall; 
    private Vector3 size;
    private float speedBall;
    public float ballBounce;
    public float timeInvisible;
    private float deltaInvisible;
    private int maxExplotion;
    private ContactPoint2D[] contacts = new ContactPoint2D[10];
    public Vector2 currentVelocity;
    private bool starBounce;
   


    void Awake()
    {
        Application.targetFrameRate = 100;
    }


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        starBounce = false;
        stateSlow = false;



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

        if (isFreeze) {

            
            rb.isKinematic = true;   
            rb.velocity = Vector2.zero;
            starBounce = true;
        }
        else
        {
            rb.isKinematic = false;

            Vector3 temp = transform.position;
            // Movimiento de la Bola de Derecha a Izquierda
            if (starBounce)
            {
                rb.velocity = currentVelocity;
                starBounce = false;
                Debug.Log("iNICIA rEBOTE"+ currentVelocity);
            }
            if (stateSlow)
            {
                temp.x = temp.x + ((starForce / 1.5f) * Time.deltaTime * x);

            }
            else
            {
                temp.x = temp.x + (starForce * Time.deltaTime * x);

            }
           
            transform.position = temp;

        }
        


        // Escala de la Bola
        transform.localScale = size;

        // Carga la textura de la Bola seleccionada
        // 0 - Azul / 1 - Verde / 2 - Rojo
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
                scoreBall = 50;
                break;
            case 1:
                size = new Vector3(2.5f, 3f, 1f);
                speedBall = 0.8f;
                ballBounce = 9.5f;
                scoreBall = 100;
                break;
            case 2:
                size = new Vector3(1.25f, 1.5f, 1f);
                speedBall = 0.7f;
                ballBounce = 7f;
                scoreBall = 150;
                break;
            case 3:
                size = new Vector3(0.5f, 0.5f, 1f);
                speedBall = 0.5f;
                ballBounce = 6f;
                scoreBall = 200;

                break;
        }

    }




    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.tag == "piso" || col.gameObject.tag == "block")
        {
           

            if(col.contacts[0].normal.y > 0)
            {
               
                if (stateSlow)
                {

                   
                    rb.velocity = new Vector2(0, ballBounce * 0.7f);

                }
                else
                {
                    rb.velocity = new Vector2(0, ballBounce);
                }

            }
            else if (col.contacts[0].normal.y < 0)
            {
                if (stateSlow)
                {
                    rb.velocity = new Vector2(0, -1);
                }
                else
                {
                    rb.velocity = new Vector2(0, -2);
                }
                
            }

            if (col.contacts[0].normal.x > 0)
            {
                 x = speedBall;
            }
            else if (col.contacts[0].normal.x < 0)
            {

                x = -speedBall;
            }    
           
        }

    
        if (col.gameObject.tag == "arma" || col.gameObject.tag == "shield")
        {

            // Clona una bola  hasta que sea la mas chica
            bangBall();


        }

    }



    public void bangBall()
    {

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
            newBall01.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.5f);
            newBall02.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.5f);
            maxExplotion++;


        }



        GameObject newExplotion = Instantiate(explotionPreFabs[colorBall], rb.position, Quaternion.identity);
        newExplotion.transform.localScale = size;

        Destroy(gameObject, (float)0);


    }

    void OnTriggerEnter2D(Collider2D col)
    {



        if (col.CompareTag("arma") || col.CompareTag("shield"))
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

                newBall01 = Instantiate(newBall, new Vector2(rb.position.x - 0.15f, rb.position.y), Quaternion.identity);

                newBall.GetComponent<Ball>().directionBallLeft = false;
                newBall02 = Instantiate(newBall, new Vector2(rb.position.x + 0.15f, rb.position.y), Quaternion.identity);
    
                // Hace un salto 
                newBall01.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.5f);
                newBall02.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3.5f);
                maxExplotion++;


            }



            GameObject newExplotion = Instantiate(explotionPreFabs[colorBall], rb.position, Quaternion.identity);
            newExplotion.transform.localScale = size;

            Destroy(gameObject, (float)0);
        }

    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "piso")
        {
           


        }
            
    }

    public void freezeBall() {

        isFreeze = true;
        currentVelocity = rb.velocity;
        
    }


    public void unfreezeBall()
    {
        sr.enabled = true;
        isFreeze = false;
    }



    public void slowBall()
    {
        Debug.Log("Baja gravedad");


        //rb.velocity = new Vector2(0, ballBounce / 1.5f);
        stateSlow = true;
        rb.gravityScale = 0.5f;
       
       

    }



    public void unSlowBall()
    {

        rb.gravityScale = 1f;
        stateSlow = false;

    }



    public void Invisible()
    {
        sr.enabled = false;
    }


    public void NoInvisible()
    {
        sr.enabled = true;
    }



}