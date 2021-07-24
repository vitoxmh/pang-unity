using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedChain;
    private SpriteRenderer sprite;
    private float heightChain;
    private SpriteRenderer sr;
    private Sprite[] textures;
    

     
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        heightChain = -0.25f;
      

    }


    void Update()
    {


        int index = (int)(Time.timeSinceLevelLoad * 6);

        heightChain = heightChain - 0.013f;
        sprite.size = new Vector2(sprite.size.x, heightChain);

        index = index % 2;
        if(index == 0 || index == 2 || index == 3)
        {
            transform.localScale = new Vector3(-4.0f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(4.0f, transform.localScale.y, transform.localScale.z);
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
