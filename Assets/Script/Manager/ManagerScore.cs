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
    private int countScore;
    public int[] comboScore; 




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
}
