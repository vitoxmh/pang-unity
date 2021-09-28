using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

    public Text coinText;
    public Text creditText;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(insertCoin());
        coinText.enabled = false;
        creditText.enabled = false;
  
        
    } 

    // Update is called once per frame
    void Update()
    {


      



        if (ManagerCoin.mc.coin > 0)
        {
            coinText.enabled = true;
            creditText.enabled = true;
            coinText.text = "PUSH START BUTTON "+ ManagerCoin.mc.coin.ToString();
            creditText.text = "CREDIT "+ ManagerCoin.mc.coin;
        }



        if (Input.GetKeyDown(KeyCode.Return) && ManagerCoin.mc.coin > 0)
        {
            
            //Application.LoadLevel(ManagerStage.ms.stage[0]);
            SceneManager.LoadScene(ManagerStage.ms.stage[0]);

        }



    }


    public IEnumerator insertCoin()
    {

        yield return new WaitForSeconds(1.5f);

        coinText.enabled = true;
         

    }



 }
