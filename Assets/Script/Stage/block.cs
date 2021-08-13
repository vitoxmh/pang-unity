using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator Animator;
    private GameObject objeto;
    public GameObject[] item;
    public bool getIten;
    public int typeItem;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnCollisionEnter2D(Collision2D col)
    {



    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("arma"))
        {

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            objeto = col.gameObject;
            Animator.SetBool("broken", true);

        }

    }

    void DestroyBlock()
    {

        
        Destroy(gameObject, (float)0);
        Destroy(objeto, (float)0);

        if (getIten)
        {
            Instantiate(item[typeItem], new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
        }
    }


}
