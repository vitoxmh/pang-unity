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
        if (GameObject.Find("DontDestroy"))
        {

            GameObject.Find("DontDestroy").transform.position = new Vector3(0, -1.6f , 0);

        }


       
  
        
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
            SceneManager.LoadScene("Map");
            ManagerCoin.mc.coin--;

        }



    }


    public IEnumerator insertCoin()
    {

        yield return new WaitForSeconds(1.5f);

        coinText.enabled = true;
         

    }



 }
