using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerStage : MonoBehaviour
{
    // Start is called before the first frame update

    public static ManagerStage ms;
    public string[] stage;
    public int currentStage;
    public GameObject txtGameOver;
    public GameObject nD;


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




    }

    void Start()
    {
        stage[0] = "1-1";
        stage[1] = "1-2";
        stage[2] = "1-3";
        stage[3] = "End";
        txtGameOver.SetActive(false);


       




    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void getStage()
    {


    }




    public void setStage()
    {


    }


    public void showTextgameOver()
    {


        txtGameOver.SetActive(true);


    }


    public void hideTextgameOver()
    {


        txtGameOver.SetActive(false);


    }



}
