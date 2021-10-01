using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update

    public Text pointText;
    void Start()
    {
        MusicManager.mn.play("End");
        int scoreFinal = ManagerScore.ms.countScore;
        pointText.text = "PUNTOS:"+ scoreFinal.ToString();
       
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public IEnumerator startGame()
    {

        yield return new WaitForSeconds(8f);

        MusicManager.mn.stop();
        SceneManager.LoadScene("Map");


    }

}
