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

        txtGameOver.SetActive(false); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void getStage()
    {


    }




    public void setStage(string nameStage)
    { 


        for (int i = 0; i < stage.Length; i++)
        {
            if (stage[i] == nameStage)
            {

                currentStage = i;
     

            }

        }


    }


    public void showTextgameOver()
    {


        txtGameOver.SetActive(true);
        Debug.Log("aCTIVA TXEXTO GAME OVR");


    }


    public void hideTextgameOver()
    {


        txtGameOver.SetActive(false);


    }


}
