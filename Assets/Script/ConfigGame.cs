using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigGame : MonoBehaviour
{
    // Start is called before the first frame update



    public static ConfigGame cg;
    public int lifePlayer1;
    public int plifePlayer2;
    public string[] stages;
    public string[] country;



    private void Awake()
    {
        if (cg == null)
        {
            cg = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (cg != null)
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
