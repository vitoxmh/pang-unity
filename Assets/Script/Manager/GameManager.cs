using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gm;
    public float TimeGame;
    public Text FreezeTimeText;
    public float StartStage;
    public GameObject TimeCount;
    public bool Lose;
    public bool gameOver;
    GameObject lm;
    private bool GettingLateTime;
    private bool OutOfTime;


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


       


        GettingLateTime = false;
        OutOfTime = false;
      

    }



    void Start()
    {

        if (GameObject.Find("DontDestroy"))
        {

            GameObject.Find("DontDestroy").transform.position = new Vector3(0, 0, -0.89f);

            Canvas canvasFixedUI = GameObject.Find("FixedUI").GetComponent<Canvas>();
            canvasFixedUI.renderMode = RenderMode.ScreenSpaceCamera;
            canvasFixedUI.worldCamera = Camera.main;
            canvasFixedUI.enabled = true;

            Canvas canvasUI = GameObject.Find("UI").GetComponent<Canvas>();
            canvasUI.renderMode = RenderMode.ScreenSpaceCamera;
            canvasUI.worldCamera = Camera.main;


        }
        

        lm = GameObject.Find("LifeManager");

        //lm.GetComponent<LifeManager>().lifesPlayer1 = ConfigGame.cg.lifePlayer1;
        //lm.GetComponent<LifeManager>().lifesPlayer1 = 9;
        //TimeCount.SetActive(true);

        TimeGame = infoStage.si.time;

        int seconds = Mathf.RoundToInt(TimeGame);

        FreezeTimeText.text = "TIME:" + seconds.ToString("000");


        StartCoroutine(starGame());



        if (infoStage.si.country != "")
        {

            GameObject.FindGameObjectWithTag("textLocation").GetComponent<UnityEngine.UI.Text>().text = infoStage.si.country.ToString();
            GameObject.FindGameObjectWithTag("textStage").GetComponent<UnityEngine.UI.Text>().text = infoStage.si.stage.ToString() + " STAGE";

        }

        // Actualiza los datos
        lm.GetComponent<LifeManager>().inicio();
        lm.GetComponent<LifeManager>().updateUiLife();
        ManagerScore.ms.totalBallStage = 0;
        ManagerScore.ms.combo = 0;

    }



    public void respawn()
    {

        MusicManager.mn.stop();



        lm.GetComponent<LifeManager>().life(-1);


        if (lm.GetComponent<LifeManager>().lifesPlayer1 == 0)
        {

            lm.GetComponent<LifeManager>().continueGame();
            GameManager.gm.Lose = true;
            
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //lm.GetComponent<LifeManager>().updateUiLife();

        }



    }




    // Update is called once per frame
    void Update()
    {

        
        nBall();


        if (Input.GetKeyDown(KeyCode.Return) && ManagerCoin.mc.coin > 0)
        {

            MusicManager.mn.stop();
            //SceneManager.LoadScene("Map");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ManagerCoin.mc.coin--;
            LifeManager.lm.reset();
        }


    }


    private void nBall()
    {
        Debug.Log("bALS" + GameObject.FindGameObjectsWithTag("ball").Length);

        if(GameObject.FindGameObjectsWithTag("ball").Length == 0)
        {

           
            StartCoroutine(NextStage());
        }

    }


    public IEnumerator NextStage()
    {

        
 
        yield return new WaitForSeconds(1f);

        MusicManager.mn.stop();

        ManagerScore.ms.timeBonus = (int)TimeGame;

        // Aca cambia al siguiente Pais

        if (infoStage.si.endCountry)
        {

            SceneManager.LoadScene("MapChange");

        }
        else
        {

            SceneManager.LoadScene("ChangeStage");

        }

        

    }
        

    public IEnumerator timeGame()
    {
         

        while (TimeGame > 0)
        {
            if (!GameManager.gm.Lose)
            {
                TimeGame -= Time.deltaTime;
            }


           

            int seconds = Mathf.RoundToInt(TimeGame);



            if(seconds == 50 && !GettingLateTime)
            {
                MusicManager.mn.stop();
                MusicManager.mn.play("GettingLate");
                FreezeTimeText.GetComponent<Text>().color = Color.yellow;
                GettingLateTime = true;
            }


            if (seconds == 20 && !OutOfTime)
            {
                MusicManager.mn.stop();
                MusicManager.mn.play("OutOfTime");
                FreezeTimeText.GetComponent<Text>().color = Color.red;
                OutOfTime = true;
            }

            FreezeTimeText.text = "TIME:" + seconds.ToString("000");

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




}
