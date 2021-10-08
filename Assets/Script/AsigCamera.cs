using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsigCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;


    void Start()
    {

        Canvas canvas = gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
