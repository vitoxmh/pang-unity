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

        Debug.Log("Posicion Mapa" + map);

        nextCountry(map);

        Debug.Log("Estado Mapa"+ ConfigGame.cg.positionMap);

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

                nextPonit(0f, 2f, 3f, 1);

            break;


            case "2-6":

                nextPonit(66.771f, 2f, 2.5f, 2);

                break;

            case "3-9":

                nextPonit(180f, 1f, 2.5f, 3);

                break;

            case "4-12":

                nextPonit(114.268f, 2f, 3f, 4);

                break;
            case "5-15":

                nextPonit(-47.434f, 2f, 3f, 5);

                break;

            case "6-18":

                nextPonit(-47.434f, 2f, 5f, 6);

            break;


            case "7-21":

                nextPonit(12.05f, 2f, 5f, 7);

            break;

            case "8-24":

                nextPonit(345.931f, 2f, 5f, 8);

            break;


            case "9-27":

                nextPonit(59.4f, 2f, 5f, 9);

            break;


            case "10-30":

                nextPonit(-176.817f, 2f, 5f, 10);
                

                break;

            case "11-33":

                nextPonit(-216.053f, 2f, 5f, 11);
                

            break;
            case "12-36":

                nextPonit(-269.031f, 2f, 5f, 12);


             break;

            case "13-39":

                nextPonit(-384.887f, 2f, 5f, 13);


             break;

            case "14-42":

                nextPonit(48.973f, 2f, 5f, 14);


             break;


            case "15-45":

                nextPonit(115.64f, 2f, 5f, 15);


             break;

            case "16-48":

                nextPonit(-388.624f, 2f, 5f, 15);


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

        yield return new WaitForSeconds(1.5f);
        ManagerStage.ms.currentStage++;
        SceneManager.LoadScene(ManagerStage.ms.stage[ManagerStage.ms.currentStage]);

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