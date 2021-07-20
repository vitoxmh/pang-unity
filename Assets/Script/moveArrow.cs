using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArrow : MonoBehaviour
{
    // Start is called before the first frame update


    //public GameObject armPreFabs;
    private BoxCollider2D collider;

    void Start()
    {

        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 6f * Time.deltaTime;
        collider.offset = new Vector2(collider.offset.x, collider.offset.y + 0.5f);
        collider.size = new Vector2(collider.size.x, collider.size.y + 0.05f);



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
