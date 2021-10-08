using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    private Rigidbody2D rb;
    public GameObject bulletExplotion;
    private Animator Animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.Lose)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            Animator.speed = 0;


        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, Speed);
        }
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("piso") || col.CompareTag("block"))
        {
            ManagerScore.ms.combo = 0;
            Instantiate(bulletExplotion, new Vector3(transform.position.x, transform.position.y + 0.05f, 1f), Quaternion.identity);
            Destroy(gameObject, (float)0);


        }


        if (col.CompareTag("ball"))
        {


            ManagerScore.ms.combo++;

            int sizeBall = col.gameObject.GetComponent<Ball>().scoreBall;
            int scoreCombo = ManagerScore.ms.comboScore[ManagerScore.ms.combo];

            int totalScore = scoreCombo + sizeBall;

            ManagerScore.ms.UpdateScore(totalScore);
            ManagerScore.ms.totalBallStage++;
            ManagerScore.ms.totalBall++;

            Destroy(gameObject, (float)0);


        }
    }
}
