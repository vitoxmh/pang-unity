using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }







    public void soundBang()
    {

        SoundManager.sm.play("Bang");

    }



    public void destroyBall()
    {
        
        Destroy(gameObject, (float)0);

    }
}
