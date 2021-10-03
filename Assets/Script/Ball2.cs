using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();

        m_Rigidbody.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
