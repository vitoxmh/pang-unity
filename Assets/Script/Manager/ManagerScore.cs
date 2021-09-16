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
    public int combo;
    public int countScore;
    public int[] comboScore;
    private string scorePresName = "Score";
    private string lifePresName = "Lifes";





    private void Awake()
    {


        if (ms == null)
        {
            ms = this;
            DontDestroyOnLoad(gameObject);
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
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(combo >= 15)
        {
            combo = 0;
        }
    }


    public void UpdateScore(int score)
    {

        countScore =  countScore + score;

        ScorePlayer01.text = countScore.ToString();


    }


    private void saveData()
    {
        PlayerPrefs.SetInt(scorePresName, countScore);
        PlayerPrefs.SetInt(lifePresName, 3);

    }


    private void loadData()
    {

        

    }

}
