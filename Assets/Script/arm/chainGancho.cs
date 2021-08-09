using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainGancho : MonoBehaviour
{
    public float speedChain;
    private SpriteRenderer sprite;
    private float heightChain;
    private SpriteRenderer sr;
    private Sprite[] textures;
    private bool touchCeiling;
    private Animator Animator;
    public AudioSource[] EffectsSource;

    private void Awake()
    {
        EffectsSource[0].Play();

    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        heightChain = -0.25f;
        Animator = GetComponent<Animator>();
        touchCeiling = false;


    }


    void Update()
    {


        if (!touchCeiling)
        {
            heightChain = heightChain - 0.013f;
            sprite.size = new Vector2(sprite.size.x, heightChain);
        }
        

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("piso"))
        {

  
            touchCeiling = true;
            Animator.SetBool("techo", true);
            EffectsSource[1].Play();

        }


        if (col.CompareTag("ball"))
        {

            Destroy(gameObject, (float)0);
          


        }
    }

    public void destroyGancho()
    {
        Destroy(gameObject, (float)0);
    }
}
