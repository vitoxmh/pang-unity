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
    public Text FreezeTimeText;
    public GameObject FreezeTimeCount;
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
        }else if (bm != null)
        {
            Destroy(gameObject);
        }

        
    }

    void Start()
    {
        FreezeTimeCount.SetActive(false);
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

        Debug.Log("Slow Ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().slowBall();


        }




        while (slowTime > 0)
        {
            slowTime -= Time.deltaTime;


            yield return null;
        }



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
        FreezeTimeCount.SetActive(true);
        bool initPalpate = false;

        float deltaNextState = Time.time;

        while (freezeTime > 0)
        {
            freezeTime -= Time.deltaTime;
            FreezeTimeText.text = "TIME: "+freezeTime.ToString("f2");
 
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

            for (int i = 0; i <= arrayBall.Length; i++)
            {

                if (arrayBall[i].GetComponent<Ball>().sizeBall < 3)
                {
                    arrayBall[i].GetComponent<Ball>().bangBall();
                }


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
        Debug.Log("Funcion congela");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().freezeBall();


        }

    }



    public void unfreezeBall()
    {

        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().unfreezeBall();


        }

        freeze = false;
        FreezeTimeCount.SetActive(false);

    }




}