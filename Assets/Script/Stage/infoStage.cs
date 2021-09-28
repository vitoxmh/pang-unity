using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoStage : MonoBehaviour
{
    // Start is called before the first frame update
    public string stage;
    public string country;
    public string musicStage;
    public float time;

    public static infoStage si;


    private void Awake()
    { 
        if (si == null)
        {
            si = this;

        }
        else if (si != null)
        {
            Destroy(gameObject);
        }

    }



    void Start()
    {

        if(time == 0)
        {
            time = 100f;
        }


        ManagerStage.ms.setStage(stage);

        CurrentShotItem.cs.CurrentShot(-1);






    }



}
