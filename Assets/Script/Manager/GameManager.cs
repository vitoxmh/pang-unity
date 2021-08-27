using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gm;


    private void Awake()
    {
        if (gm == null)
        { 
            gm = this;
        }
        else if (gm != null)
        {
            Destroy(gameObject);
        }


    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
