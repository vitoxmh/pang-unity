using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

        for (int i = 0; i < dollLife.Length; i++)
        {

            if ((i + 1) <= lifesPlayer1)
            {
                dollLife[i].SetActive(true);
            }
            else
            {
                dollLife[i].SetActive(false);
            }

        }



        if(lifesPlayer1 > 4)
        {

            textLife.SetActive(true);

        }
        else
        {
            textLife.SetActive(false);
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
        StartCoroutine(countContinueGame());


    }



    public IEnumerator countContinueGame()
    {

        float timeContinue = 10f;

        while (timeContinue > 1)
        {

            timeContinue -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(timeContinue % 60);
         
            countContinue.text = seconds.ToString();

            yield return null;
        }

        Application.LoadLevel("Start");

    }




}
