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
    public float TimeLife;
    private SpriteRenderer sr;
    LifeManager lm;

    void Start()
    {
        AllBang = false;
        detalDelayBang = Time.time;
        StartCoroutine(timeLifeDead());
        sr = GetComponent<SpriteRenderer>();
        lm = FindObjectOfType<LifeManager>();

    }

    // Update is called once per frame
    void Update()
    {


        
    }


    public IEnumerator timeLifeDead()
    {

        bool initPalpate = false;
        float deltaNextState = Time.time;


        while (TimeLife > 0)
        {
            TimeLife -= Time.deltaTime;


            if (!initPalpate && deltaNextState <= Time.time && TimeLife < 2.5f)
            {
                sr.enabled = true;
                deltaNextState = 0.13f + Time.time;
                initPalpate = true;
            }

            if (initPalpate && deltaNextState <= Time.time && TimeLife < 2.5f)
            {
                sr.enabled = false;
                deltaNextState = 0.13f + Time.time;
                initPalpate = false;
            }


            yield return null;
        }


        Destroy(gameObject, (float)0f);

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



            }
            else if (typeItem == 3)
            {


                BallManager.bm.startSlowBall();



            }else if (typeItem == 4)
            {

                lm.life(1);

            }
            else
            {
                item = Instantiate(itemPreFabs[typeItem], new Vector3(col.gameObject.transform.position.x + 0.1f, col.gameObject.transform.position.y,0f), Quaternion.identity);

            }
            
           
            Destroy(gameObject, (float)0);


        }



    }


}
