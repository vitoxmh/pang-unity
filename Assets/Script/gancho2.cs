using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gancho2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 startPos;
    public GameObject chainGFX;

    void Start()
    {

        GameObject chain = Instantiate(chainGFX, transform.position, Quaternion.identity);
        chain.transform.parent = transform;
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.up * 6f * Time.deltaTime;

        if ((transform.position.y - startPos.y) >= 0.1f)
        {

            //GameObject chain = Instantiate(chainGFX, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //chain.transform.parent = transform;
            //startPos = transform.position;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ball") || col.CompareTag("techo"))
        {

            Destroy(gameObject, (float)0);
            Debug.Log("Muere");

        }
    }
}
