using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    // Start is called before the first frame update
    public int typeItem;
    public GameObject[] itemPreFabs;
    public bool AllBang;
    private float detalDelayBang;
    void Start()
    {
        AllBang = false;
        detalDelayBang = Time.time;

    }

    // Update is called once per frame
    void Update()
    {


        
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        GameObject item = null;

        if (col.gameObject.tag == "Player")
        {

            if(typeItem == 0)
            {
                item = Instantiate(itemPreFabs[typeItem], new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 0.171f), Quaternion.identity);
                item.transform.parent = col.gameObject.transform;
            }
            else if (typeItem == 1)
            {
                
                BallManager.bm.isBallBang = true;
                Debug.Log("Destuye Bolas");

            }
            else if (typeItem == 2)
            {

      
                BallManager.bm.StartFreeze();

               

            }else
            {
                item = Instantiate(itemPreFabs[typeItem], new Vector3(col.gameObject.transform.position.x + 0.1f, col.gameObject.transform.position.y,0f), Quaternion.identity);

            }
            
           
            Destroy(gameObject, (float)0);


        }



    }


}
