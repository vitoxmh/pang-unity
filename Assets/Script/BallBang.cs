using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        SoundManager.sm.play("Bang");

    }


    public void Bang()
    {
        Destroy(gameObject, (float)0);
    }
}
