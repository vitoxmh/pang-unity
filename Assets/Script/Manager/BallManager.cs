using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static BallManager bm;

    public bool isBallBang;
    public bool isFreeze;
    public float freezeTime;
    public float slowTime;
    private float detalDelayBang;
    public bool freeze;
    public float TimeFreezeInit;
    public float TimeSlowInit;
    public bool isSlowBall;


    private void Awake()
    {
        if(bm == null)
        {
            bm = this;
            
        }
        else if (bm != null)
        {
            Destroy(gameObject);
        }
        

    }

    void Start()
    {

        detalDelayBang = Time.time;
        freeze = false;



    }

    // Update is called once per frame
    void Update()
    {

        if (isBallBang)
        {
            BangAllBall();

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BangAllBallKill();
        }



    }



    public void startSlowBall()
    {

        StartCoroutine(SlowTime());

    }


    public void StartFreeze() {


        if (!freeze)
        {
            StartCoroutine(FreezeTime());

        }

       




    }


    public IEnumerator SlowTime()
    {


        slowTime = TimeSlowInit;


        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

    

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().slowBall();

        }




        while (slowTime > 0)
        {
            slowTime -= Time.deltaTime;


            yield return null;
        }

        arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().unSlowBall();


        }




    }


    public IEnumerator FreezeTime()
    {
    
        freeze = true;
        freezeTime = TimeFreezeInit;
        freezeBall();
        int count = 0;

        bool initPalpate = false;

        float deltaNextState = Time.time;

       
       

            while (freezeTime > 0)
            {

                if (!GameManager.gm.Lose)
                {

                    freezeTime -= Time.deltaTime;
            
 
                    if (!initPalpate && deltaNextState <= Time.time && freezeTime < 2.5f)
                    {
                        InvisibleAllBall();
                        deltaNextState = 0.13f + Time.time;
                        initPalpate = true;
                    }

                    if(initPalpate && deltaNextState <= Time.time && freezeTime < 2.5f)
                    {
                        noInvisibleAllBall();
                        deltaNextState = 0.13f + Time.time;
                        initPalpate = false;
                    }
                }

                yield return null;
            }
        


        unfreezeBall();

    }


    public void BangAllBall()
    {



        if (Time.time > detalDelayBang)
        {


            detalDelayBang = Time.time + 0.35f;

            GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");


            foreach (GameObject ball in arrayBall)
            {
                if (ball.GetComponent<Ball>().sizeBall < 3)
                {
                    ball.GetComponent<Ball>().bangBall();
                }
                
            }


        }


    }



    public void BangAllBallKill()
    {



        if (Time.time > detalDelayBang)
        {


            detalDelayBang = Time.time + 0.35f;

            GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");


            foreach (GameObject ball in arrayBall)
            {
                ball.GetComponent<Ball>().bangBall();

            }


        }


    }







    public void InvisibleAllBall()
    {

        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().Invisible();

        }

    }

    public void noInvisibleAllBall()
    {

        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().NoInvisible();

        }

    }



    public void freezeBall()
    {

        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {


            arrayBall[i].GetComponent<Ball>().freezeBall();


        }

    }



    public void unfreezeBall()
    {

        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        if (!GameManager.gm.Lose) {

            for (int i = 0; i < arrayBall.Length; i++)
            {

                arrayBall[i].GetComponent<Ball>().unfreezeBall();


            }

            freeze = false;

        }


    }

     

    public void unTriggerColliderBall()
    {

        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {
            arrayBall[i].GetComponent<CircleCollider2D>().isTrigger = true;
        }


    }




}
