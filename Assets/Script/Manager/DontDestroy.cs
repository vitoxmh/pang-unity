using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public static DontDestroy dd;
    void Start()
    {


        if (dd == null)
        {
            dd = this;
           
        }
        else if (dd != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void hide()
    {
        //gameObject.SetActive(false);

        transform.GetChild(0).gameObject.SetActive(false);
    }


    public void show()
    {
        //gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
