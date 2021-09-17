using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        MusicManager.mn.play("StageComplete");
        StartCoroutine(stageChange());

    }



    public IEnumerator stageChange()
    {


        yield return new WaitForSeconds(3.5f);

        Application.LoadLevel("Stage02");

    }


}
