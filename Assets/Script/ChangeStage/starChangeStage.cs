using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starChangeStage : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] textures;
    private SpriteRenderer sr;
    private float speed;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 tem = transform.position;
        
        

        if (Input.GetKeyDown(KeyCode.E))
        {

            speed = 4f;
        }
        else
        {

            speed = 2f;

        }

       
        if(tem.x <= -3.61f)
        {

            tem.x = 3.64f;

        }
        tem.x = tem.x - (Time.deltaTime * speed);
        
        transform.position = tem;


        starAnimation(8f);



    }




    void starAnimation(float fps)
    {

        int index = (int)(Time.timeSinceLevelLoad * fps);

        index = index % textures.Length;

        sr.sprite = textures[index];

    }
}
