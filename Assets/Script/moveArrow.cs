using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 6f * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ball") || col.CompareTag("techo"))
        {

            Destroy(gameObject, (float)0);
            Debug.Log("Mueres");

        }
    }
}
