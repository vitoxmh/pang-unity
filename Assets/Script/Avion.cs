using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Avion : MonoBehaviour
{
    // Start is called before the first frame update

    public string nameAnimation;
    private Animator Animator;
    public int NextMap;

    public Transform PointA;
    public Vector3 PointB;
    public float speed;
    public float time;
    void Start()
    {
        Animator = GetComponent<Animator>();
        //string map = "2-4";

        string map = ManagerStage.ms.stage[ManagerStage.ms.currentStage];
        Debug.Log("==========>" + map);
        nextCountry(map);

        StartCoroutine(nextStage());

    }

    // Update is called once per frame
     

    public void nextCountry(string country)
    {

        switch (country)
        {

            case "1-3":  

                transform.position = new Vector3(GameObject.Find("1-1").transform.position.x, GameObject.Find("1-1").transform.position.y, -7f);
                PointB = new Vector3(GameObject.Find("2-4").transform.position.x, GameObject.Find("2-4").transform.position.y, -7f);
                speed = 1f;
                time = 2f;
                break;


            case "2-6":

                
                transform.position = new Vector3(GameObject.Find("2-4").transform.position.x, GameObject.Find("2-4").transform.position.y, -7f);

                transform.eulerAngles = new Vector3(0.451f, -0.194f, 66.771f);

                PointB = new Vector3(GameObject.Find("3-7").transform.position.x, GameObject.Find("3-7").transform.position.y, -7f);

                speed = 2f;
                time = 2.5f;

                break;


        }


        SoundManager.sm.play("Plane");

    }



    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PointB, step);
    }



    public IEnumerator nextStage()
    {


        yield return new WaitForSeconds(time);

        ManagerStage.ms.currentStage++;

        SceneManager.LoadScene(ManagerStage.ms.stage[ManagerStage.ms.currentStage]);
        Debug.Log("sTAGE " + ManagerStage.ms.stage[ManagerStage.ms.currentStage]);

    }


}
