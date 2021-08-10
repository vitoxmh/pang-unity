using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    private Rigidbody2D rb;
    public GameObject bulletExplotion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, Speed);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("piso"))
        {

            Instantiate(bulletExplotion, new Vector3(transform.position.x, transform.position.y + 0.05f, 1f), Quaternion.identity);
            Destroy(gameObject, (float)0);


        }


        if (col.CompareTag("ball"))
        {

           
            Destroy(gameObject, (float)0);


        }
    }
}
