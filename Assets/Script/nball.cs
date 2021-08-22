using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class nball : MonoBehaviour
{
    // Start is called before the first frame update

    Text texto;
    

    void Start()
    {
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("nUMEROS DE BOLAS"+GameObject.FindGameObjectsWithTag("ball").Length);
        texto.text = "N Balls: " + GameObject.FindGameObjectsWithTag("ball").Length.ToString();

    }
}
