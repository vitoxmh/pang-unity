using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    // Start is called before the first frame update
    public int typeItem;
    public GameObject[] itemPreFabs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {

       

        if (col.gameObject.tag == "Player")
        {


            GameObject item = Instantiate(itemPreFabs[typeItem], new Vector3(col.gameObject.transform.position.x + 0.1f, col.gameObject.transform.position.y, 1f), Quaternion.identity);
            item.transform.parent = col.gameObject.transform;
            Destroy(gameObject, (float)0);


        }



    }




}
