using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("BulletCrush");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void bulletDestroyKill()
    {


        Destroy(gameObject, (float)0);

    }

}
