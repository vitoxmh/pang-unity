using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainGFX : MonoBehaviour
{

    Vector2 startPost;


    void Start()
    {
        startPost = transform.position;
    }

  
    void Update()
    {
        transform.position = startPost;

    }
}
