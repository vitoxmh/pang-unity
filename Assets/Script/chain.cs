using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chain : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedChain;
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y < 15f)
        {
            transform.localScale += Vector3.down * Time.deltaTime * speedChain;
        }
    }
}
