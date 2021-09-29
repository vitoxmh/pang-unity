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
            DontDestroyOnLoad(gameObject);
        }
        else if (dd != null)
        {
            Destroy(gameObject);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
