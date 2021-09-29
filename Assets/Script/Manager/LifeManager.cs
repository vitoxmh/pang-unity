using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int lifesPlayer1;
    public int lifesPlayer2;
    public GameObject[] dollLife;
    public GameObject textLife;
    public GameObject textContinue;
    public Text lifeText;
    public Text countContinue;
    public GameObject itenBox;
    public float timeContinue;
    public static LifeManager lm;


    private void Awake()
    {
        if (lm == null)
        {
            lm = this;

        }
        else if (lm != null)
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {


        textContinue.SetActive(false);
        updateUiLife();


    }

    // Update is called once per frame
    void Update()
    {

        

    }





    public void life(int l)
    {

        if(l < 0)
        {
            lifesPlayer1--;
        }
        else
        {
            lifesPlayer1++;
        }
       

        updateUiLife();
         

    }



    public void updateUiLife()
    {
        int i = 0;


        GameObject[] arrayDoll = GameObject.FindGameObjectsWithTag("dollLife");



        foreach (GameObject doll in arrayDoll)
        {

            if ((i + 1) <= lifesPlayer1)
            {
                doll.SetActive(true);
            }
            else
            {
                doll.SetActive(false);
            }

            i++;

        }


        
        

      

        if (lifesPlayer1 > 4)
        {

            GameObject.SetActive(true);

        }
        else
        {
            GameObject.SetActive(false);
        }

        lifeText.text = lifesPlayer1.ToString();


    }



    public void hideDollLifes()
    {

        for (int i = 0; i < dollLife.Length; i++)
        {

            dollLife[i].SetActive(false);

        }


        textLife.SetActive(false);

    }




    public void showDollLifes()
    {

        for (int i = 0; i < dollLife.Length; i++)
        {

            dollLife[i].SetActive(true);

        }


        textLife.SetActive(true);

    }




    public void continueGame()
    {

        hideDollLifes();
        textContinue.SetActive(true);
        itenBox.SetActive(false);
        MusicManager.mn.play("Continue");
        textContinue.transform.GetChild(0).gameObject.GetComponent<Text>().text = "CONTINUE?";
        StartCoroutine(countContinueGame());


    }



    public IEnumerator countContinueGame()
    {

        countContinue.enabled = true;

        while (timeContinue > 1)
        {

            timeContinue -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(timeContinue % 60);
         
            countContinue.text = seconds.ToString();

            yield return null;
        }



        float timeGameOver = 3f;
        
        textContinue.transform.GetChild(0).gameObject.GetComponent<Text>().text = "GAME OVER";
        countContinue.enabled = false; 

        while (timeGameOver > 1)
        {

            timeGameOver -= Time.deltaTime;
            yield return null;
        }

        MusicManager.mn.stop();

        MusicManager.mn.play("GameOver");


        while (timeGameOver > 1)
        {

            timeGameOver -= Time.deltaTime;
            yield return null;
        }

        float timeGameOverText = 6f;


        ManagerStage.ms.showTextgameOver();

        while (timeGameOverText > 1)
        {

            timeGameOverText -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("Start");
        reset();
        

    }



    public void reset()
    {

        ManagerStage.ms.hideTextgameOver();
        MusicManager.mn.stop();
        ManagerStage.ms.currentStage = 0;
        lifesPlayer1 = 1;
        showDollLifes();
        ManagerScore.ms.resetData();
        updateUiLife();
        itenBox.SetActive(true);
        textContinue.SetActive(false);
        timeContinue = 9f;


    }



}
