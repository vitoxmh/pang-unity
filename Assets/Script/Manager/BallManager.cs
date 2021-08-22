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
    private float detalDelayBang;
    public bool freeze;
    public float TimeFreezeInit; 


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


    public void StartFreeze() {


        if (!freeze)
        {
            StartCoroutine(FreezeTime());
           
        }
            
    
    
    }


    public IEnumerator FreezeTime()
    {
        Debug.Log("DSSSSSSS");
        freeze = true;
        freezeTime = TimeFreezeInit;
        freezeBall();

        FreezeTimeCount.SetActive(true);


        while (freezeTime > 0)
        {
            freezeTime -= Time.deltaTime;
            FreezeTimeText.text = freezeTime.ToString("f2");
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
