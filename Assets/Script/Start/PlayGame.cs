using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{

    public Text coinText;
    public Text creditText;
    // Start is called before the first frame update
    private int coin;
    void Start()
    {
        coin = 0;
        StartCoroutine(insertCoin());
        coinText.enabled = false;
        creditText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.F5))
        {

            SoundManager.sm.play("Coin");
        
            coin++;

        }



        if(coin > 0)
        {
            coinText.enabled = true;
            creditText.enabled = true;
            coinText.text = "PUSH START BUTTON "+coin.ToString();
            creditText.text = "CREDIT "+coin;
        }



        if (Input.GetKeyDown(KeyCode.Return) && coin > 0)
        {
            Application.LoadLevel("Stage01");
        }



    }


    public IEnumerator insertCoin()
    {

        yield return new WaitForSeconds(1.5f);

        coinText.enabled = true;
         

    }



 }
