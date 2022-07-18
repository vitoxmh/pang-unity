using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static PlayManager pm;
    public bool isPlaying;



    private void Awake()
    {
        if (pm == null)
        {
            pm = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (pm != null)
        {
            Destroy(gameObject);
        }




    }

}
