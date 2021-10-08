using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeStage : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text textStage;
    public Text textTimeBonus;
    public Text textBalls;
    public GameObject[] stagesChange;
    string currentStage;

    void Start()
    {

        StartCoroutine(stageChange());

        if (GameObject.Find("DontDestroy"))
        {

            GameObject.Find("DontDestroy").transform.position = new Vector3(0, -9f, 0);


            Canvas canvasFixedUI = GameObject.Find("FixedUI").GetComponent<Canvas>();
            canvasFixedUI.renderMode = RenderMode.ScreenSpaceCamera;
            canvasFixedUI.worldCamera = Camera.main;
            canvasFixedUI.enabled = false;


        }

    }




    private void showChangeStage()
    {

        
        
        //textStage.text = "STAGE "+ currentStage + " COMPLETE";


       



    }



    public IEnumerator stageChange()
    {

        // INICIOA MUSICA DE ETAPA COMPLETADA
        MusicManager.mn.play("StageComplete");

        
        // GUARDA EN VARIABLE LOCAL LA ETAPA COMPLETADA
        currentStage = ManagerStage.ms.stage[ManagerStage.ms.currentStage].ToString();

        // CAMBIA EL OBJECTO TEXT 
        textStage.text = "STAGE " + currentStage + " COMPLETE";

        // AUMENTA EN 1 Y ASI SABER A QUE ETAPA DEBE SEGUIR
        ManagerStage.ms.currentStage++;

        // CALCULA EL BONUS DE BOLAS ROTAS.
        int bonusBall = (ManagerScore.ms.totalBallStage * 100);
        //CALCULA EL BONUS DE TIEMPO
        int timeBonus = ManagerScore.ms.timeBonus * 500;
        
        // ACTUALIZA TEXTOS DE BONUS TIEMPO Y BALL
        textBalls.text = "BALL "+ManagerScore.ms.totalBallStage.ToString() + "X500 = "+ bonusBall.ToString()+"pts";
        textTimeBonus.text = "TIME BONUS "+ timeBonus.ToString() + "pts";

        // ACTUALIZA EL MARCADO GLOBAL
        ManagerScore.ms.UpdateScore(bonusBall);
        ManagerScore.ms.UpdateScore(timeBonus);


        // ACTIVA ANIMACION DE GANAR
        for (int i = 0; i < stagesChange.Length; i++)
        {

            stagesChange[i].SetActive(false);

        }


        int maxStage = stagesChange.Length;

        int randomChangeStage = Random.Range(0, maxStage);


        Debug.Log("Stage Random" + randomChangeStage + " mAXIMO " + maxStage);


        stagesChange[randomChangeStage].SetActive(true);

        // TIENE UN TIEMPO DE 3.5 SEGUNDOS
        yield return new WaitForSeconds(3.5f);
        // CARGA LA SIGUIENTE ESCENA
        SceneManager.LoadScene(ManagerStage.ms.stage[ManagerStage.ms.currentStage]);

    }


}
