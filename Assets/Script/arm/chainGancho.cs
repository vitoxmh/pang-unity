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
        //GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().play("Firehook");

        SoundManager.sm.play("Firehook");

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
            heightChain = heightChain - speedChain;
            sprite.size = new Vector2(sprite.size.x, heightChain);
        }
        

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("piso"))
        {

            ManagerScore.ms.combo = 0;
            SoundManager.sm.play("HookAnchored");
            touchCeiling = true;
            Animator.SetBool("techo", true);
            


        }


        if (col.CompareTag("block"))
        {

            ManagerScore.ms.combo = 0;
            touchCeiling = true;
            Animator.SetBool("techo", true);
           


        }




        if (col.CompareTag("ball"))
        {

            ManagerScore.ms.combo++;

            int sizeBall = col.gameObject.GetComponent<Ball>().scoreBall;
            int scoreCombo = ManagerScore.ms.comboScore[ManagerScore.ms.combo];

            int totalScore = scoreCombo + sizeBall;

            ManagerScore.ms.UpdateScore(totalScore);


            Destroy(gameObject, (float)0);
          


        }
    }

    public void destroyGancho()
    {
        Destroy(gameObject, (float)0);
    }
}
