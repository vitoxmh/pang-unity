using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public GameObject chainGFX;
    private Vector2 startPos;

    void Start()
    {
  
       
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += (Vector3.up * 6f * Time.deltaTime);

        if ((transform.position.y - startPos.y) >= 0.6f)
        {

            GameObject chain = Instantiate(chainGFX, new Vector3(transform.position.x, transform.position.y - 0.35f , transform.position.z), Quaternion.identity);
            chain.transform.parent = transform;
            startPos = transform.position;
        }


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ball") || col.CompareTag("techo"))
        {

            Destroy(gameObject, (float)0);

        }
    }

}
