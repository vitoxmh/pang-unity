using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeStage : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text textStage;

    void Start()
    {

        MusicManager.mn.play("StageComplete");

        string currentStage = ManagerStage.ms.stage[ManagerStage.ms.currentStage];

        textStage.text = "STAGE " + currentStage + " COMPLETE";

        ManagerStage.ms.currentStage++;
        
        

        StartCoroutine(stageChange());

    }



    public IEnumerator stageChange()
    {


        yield return new WaitForSeconds(3.5f);
        
        Application.LoadLevel(ManagerStage.ms.stage[ManagerStage.ms.currentStage]);

    }


}
