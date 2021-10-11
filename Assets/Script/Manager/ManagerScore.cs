using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManagerScore ms;

    public Text ScorePlayer01;
    public Text ScorePlayer02;
    public Text textHiScore;
    public int combo;
    public int countScore;
    public int totalBall;
    public int totalBallStage;
    public int hiScore;
    public int[] comboScore;
    public int timeBonus;
    private string scorePresName = "Score";
    private string lifePresName = "Lifes";






    private void Awake()
    {


        if (ms == null)
        {
            ms = this;

        }
        else if (ms != null)
        {
            Destroy(gameObject);
        }


        countScore = 0;
        combo = 0;




    }

    void Start()
    {
        textHiScore.text = "HI" + hiScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(combo >= 15)
        {
            combo = 15;
        }
    }


    public void UpdateScore(int score)
    {

        countScore =  countScore + score;

        ScorePlayer01.text = countScore.ToString();


        updateHiScore(countScore);




    }


    private void saveData()
    {
        //PlayerPrefs.SetInt(scorePresName, countScore);
        //PlayerPrefs.SetInt(lifePresName, 3);

    }




    private void updateHiScore(int score)
    {


        if (countScore > hiScore)
        {

            hiScore = countScore;
            textHiScore.text = "HI"+hiScore.ToString();
            PlayerPrefs.SetInt("hi", hiScore);

        }


    }


    public void resetData()
    {

        countScore = 0;
        UpdateScore(0);

    }

}
