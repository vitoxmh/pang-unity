using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("Bang");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bang()
    {
        Destroy(gameObject, (float)0);
    }
}
