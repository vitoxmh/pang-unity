using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gm;
    public float TimeGame;
    public Text FreezeTimeText;
    public float StartStage;
    public GameObject TimeCount;
    public bool Lose;

  


    private void Awake()
    {
        if (gm == null)
        { 
            gm = this;
           
        }
        else if (gm != null)
        {
            Destroy(gameObject);
        }




    }




    public void inicio()
    {

        MusicManager.mn.stop();
        Application.LoadLevel("Start");

    }


    void Start()
    {
        



        TimeCount.SetActive(true);
        
        TimeGame = infoStage.si.time;

        FreezeTimeText.text = "TIME:" + TimeGame.ToString("N");


        StartCoroutine(starGame());



        if (infoStage.si.country != "")
        {

            GameObject.FindGameObjectWithTag("textLocation").GetComponent<UnityEngine.UI.Text>().text = infoStage.si.country.ToString();
            GameObject.FindGameObjectWithTag("textStage").GetComponent<UnityEngine.UI.Text>().text = infoStage.si.stage.ToString() + " STAGE";


        }






    }

    // Update is called once per frame
    void Update()
    {


        nBall();


    }



    private void nBall()
    {

        if(GameObject.FindGameObjectsWithTag("ball").Length == 0)
        {

           
            StartCoroutine(NextStage());
        }

    }


    public IEnumerator NextStage()
    {

       
 
        yield return new WaitForSeconds(1f);

        MusicManager.mn.stop();
 
        Application.LoadLevel("ChangeStage");

    }
        

    public IEnumerator timeGame()
    {


        while (TimeGame > 0)
        {
            TimeGame -= Time.deltaTime;
            FreezeTimeText.text = "TIME:" + TimeGame.ToString("N");
            yield return null;
        }

    }



    public IEnumerator starGame()
    {


        frezzerAll();

        bool initPalpate = false;
        float deltaNextState = Time.time;

        while (StartStage > 0)
        {
            StartStage -= Time.deltaTime;


            if (!initPalpate && deltaNextState <= Time.time && StartStage < 1f)
            {
               
                deltaNextState = 0.13f + Time.time;
                initPalpate = true;
                TimeCount.SetActive(false);
            }

            if (initPalpate && deltaNextState <= Time.time && StartStage < 1f)
            {
                
                deltaNextState = 0.13f + Time.time;
                initPalpate = false;
                TimeCount.SetActive(true);
            }


            yield return null;
        }
         
        
        MusicManager.mn.play(infoStage.si.musicStage);


        unFrezzerAll();
        TimeCount.SetActive(false);
        StartCoroutine(timeGame());

    }





    public void frezzerAll()
    {



        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");



        foreach (GameObject ball in arrayBall)
        {

            ball.GetComponent<Ball>().freezeBall();

        }


       
        GameObject[] arrayPlayer = GameObject.FindGameObjectsWithTag("Player");



        foreach (GameObject player in arrayPlayer)
        {

            player.GetComponent<PlayerController>().stateFreeze = true;

        }

      
    }



    private void unFrezzerAll()
    {


        GameObject[] arrayBall = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < arrayBall.Length; i++)
        {

            arrayBall[i].GetComponent<Ball>().unfreezeBall();


        }


        GameObject[] arrayPlayer = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < arrayPlayer.Length; i++)
        {

            arrayPlayer[i].GetComponent<PlayerController>().stateFreeze = false;


        }


    }


    public void rebootStage()
    {

    }



}
