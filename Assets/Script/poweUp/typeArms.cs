using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeArms : MonoBehaviour
{
    private Rigidbody2D rb;
    private float touchFloor;
    public int typeArm;
    private BoxCollider2D collider;
    public int MaxShot;
    private SpriteRenderer sr;
    public float TimeLife;

    CurrentShotItem getItemShot;

    private void Awake()
    {

        getItemShot = FindObjectOfType<CurrentShotItem>();
        sr = GetComponent<SpriteRenderer>();

    }

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        StartCoroutine(timeLifeDead());




    }



    public IEnumerator timeLifeDead()
    {

        bool initPalpate = false;
        float deltaNextState = Time.time;


        while (TimeLife > 0)
        {

            if (!GameManager.gm.Lose)
            {

            
                TimeLife -= Time.deltaTime;


                if (!initPalpate && deltaNextState <= Time.time && TimeLife < 2.5f)
                {
                    sr.enabled = true;
                    deltaNextState = 0.13f + Time.time;
                    initPalpate = true;
                }

                if (initPalpate && deltaNextState <= Time.time && TimeLife < 2.5f)
                {
                    sr.enabled = false;
                    deltaNextState = 0.13f + Time.time;
                    initPalpate = false;
                }


                yield return null;
            }
        }


        Destroy(gameObject, (float)0f);

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




     

    }


    void OnTriggerStay2D(Collider2D col)
    {


       
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Colision al item");
            getItemShot.CurrentShot(typeArm);
             
            col.gameObject.GetComponent<PlayerController>().typeArms = typeArm;
            col.gameObject.GetComponent<PlayerController>().maxShot = MaxShot;

            Destroy(gameObject, (float)0f);



        }
    }


}
