using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direccion;
    Vector2 reflejado_aux;
    bool pega = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Damos una velocidad inicial
        rb.velocity = new Vector2(3, -1);
    }


    void FixedUpdate()
    {
        if (!pega)
        {
            direccion = rb.velocity;
        }

    }

        // Update is called once per frame
        void Update()
    {
        
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        pega = true;
        //coll.contacts nos devuelve una matriz con los contactos de la colision
        Vector2 reflejado = Vector2.Reflect(direccion, coll.contacts[0].normal) * 3f;
        rb.velocity = reflejado;
    }



    void OnCollisionExit2D(Collision2D coll)
    {
        pega = false;
    }


}
