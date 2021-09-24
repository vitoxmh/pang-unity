using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeStage : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text textStage;
    public GameObject[] stagesChange;
    string currentStage;

    void Start()
    {


      


        StartCoroutine(stageChange());

    }




    private void showChangeStage()
    {

        
        
        //textStage.text = "STAGE "+ currentStage + " COMPLETE";


       



    }



    public IEnumerator stageChange()
    {




        MusicManager.mn.play("StageComplete");

        
        currentStage = ManagerStage.ms.stage[ManagerStage.ms.currentStage].ToString();

        textStage.text = "STAGE " + currentStage + " COMPLETE";

        ManagerStage.ms.currentStage++;



        for (int i = 0; i < stagesChange.Length; i++)
        {

            stagesChange[i].SetActive(false);

        }

        int maxStage = stagesChange.Length;

        int randomChangeStage = Random.Range(0, maxStage);


        Debug.Log("Stage Random" + randomChangeStage + " mAXIMO " + maxStage);


        stagesChange[randomChangeStage].SetActive(true);


        yield return new WaitForSeconds(3.5f);

        SceneManager.LoadScene(ManagerStage.ms.stage[ManagerStage.ms.currentStage]);

    }


}
