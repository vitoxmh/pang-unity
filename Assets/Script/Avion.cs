using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public Text country;
    public Text nextCountryMap;


    void Start()
    {
        Animator = GetComponent<Animator>();

        string map = ConfigGame.cg.stages[ConfigGame.cg.positionMap];
        map = map.Replace("~", "-");

        Debug.Log("DFDFDFF"+ map);
      
        nextCountry(map);

      

        if (GameObject.Find("DontDestroy"))
        {

            GameObject.Find("DontDestroy").transform.position = new Vector3(0, -1.6f, 0);
            Canvas canvasFixedUI = GameObject.Find("FixedUI").GetComponent<Canvas>();
            canvasFixedUI.renderMode = RenderMode.ScreenSpaceCamera;
            canvasFixedUI.worldCamera = Camera.main;
            canvasFixedUI.enabled = false;

        }

    }

    // Update is called once per frame


    public void nextCountry(string country)
    {

        


        switch (country)
        {

            case "1-3":

                nextPonit(0f,2f,3f,1);

                break;


            case "4-6":

                nextPonit(66.771f, 2f, 2.5f, 2);

            break;

            case "7-9":

                nextPonit(180f, 1f, 2.5f, 3);

            break;

            case "10-12":

                nextPonit(114.268f, 2f, 3f, 4);

            break;
            case "13-15":

                nextPonit(-47.434f, 2f, 3f, 5);

            break;

            case "16-18":

                nextPonit(-47.434f, 2f, 5f, 6);

            break;


        }


        SoundManager.sm.play("Plane");

    }



    void nextPonit(float _rotation, float _time, float _speed, int _nextMapPosition)
    {

        Transform mapPointA = GameObject.Find(ConfigGame.cg.stages[ConfigGame.cg.positionMap].Replace("~", "-")).transform;

        Transform mapPointB = GameObject.Find(ConfigGame.cg.stages[(ConfigGame.cg.positionMap + 1)].Replace("~", "-")).transform;


        transform.position = new Vector3(mapPointA.position.x, mapPointA.position.y, -7f);

        GameObject.Find(ConfigGame.cg.stages[ConfigGame.cg.positionMap].Replace("~", "-")).GetComponent<CircleCollider2D>().enabled = false;

        PointB = new Vector3(mapPointB.position.x, mapPointB.position.y, -7f);

        transform.eulerAngles = new Vector3(0.451f, -0.194f, _rotation);
        speed = _speed;
        time = _time;
        ConfigGame.cg.positionMap = _nextMapPosition;


    }



    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PointB, step);
    }



    public IEnumerator nextStage()
    {



        country.text = ConfigGame.cg.country[ConfigGame.cg.positionMap].ToString();
        nextCountryMap.text = "STAGE " + ConfigGame.cg.stages[ConfigGame.cg.positionMap].ToString();

        yield return new WaitForSeconds(1f);

        ManagerStage.ms.currentStage++;

        SceneManager.LoadScene(ManagerStage.ms.stage[ManagerStage.ms.currentStage]);
        Debug.Log("sTAGE " + ManagerStage.ms.stage[ManagerStage.ms.currentStage]);

    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "PointMap")
        {


            SoundManager.sm.play("Plane");


        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PointMap")
        {

            SoundManager.sm.stop();
            StartCoroutine(nextStage());

        }


    }


  

}
