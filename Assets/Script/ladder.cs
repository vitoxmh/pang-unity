using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    // Start is called before the first frame update
    public bool onLadderPlayer1;
     

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {


            onLadderPlayer1 = true;
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;


        }
    
    
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {


            onLadderPlayer1 = false;
            other.gameObject.GetComponent<PlayerController>().newLadder = false;


        }

    }


 }
