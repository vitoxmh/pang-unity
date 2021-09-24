using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStage : MonoBehaviour
{
    // Start is called before the first frame update

    public static ManagerStage ms;
    public string[] stage;
    public int currentStage;
    public GameObject txtGameOver;

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




    }

    void Start()
    {
        stage[0] = "1-1";
        stage[1] = "1-2";
        stage[2] = "1-3";
        stage[3] = "2-1";
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
