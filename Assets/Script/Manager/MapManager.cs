using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update

    public string[] stage;
    public int indexPositionMap;
    public string setStageMap;
    public Vector3[] positionMap;
    public GameObject pointMapItem;
    public Vector3 setPoitMap;

    void Start()
    {
        indexPositionMap = 0;
        setStageMap = stage[indexPositionMap];
        positionMap = new[] {
                        new Vector3 { x = 5.692f, y = 1.52f, z = 0 }, 
                        new Vector3 { x = 4.236f, y = 1.52f, z = 0 },
                        new Vector3 { x = 3.66f, y = 0.228f, z = 0 },
                        new Vector3 { x = 4.231f, y = 0.234f, z = 0 },
                        new Vector3 { x = 5.252f, y = -2.176f, z = 0 },
                        new Vector3 { x = 2.928f, y = 0.391f, z = 0 },
                        new Vector3 { x = 0.733f, y = 2.797f, z = 0 },
                        new Vector3 { x = -0.434f, y = 2.467f, z = 0 },
                        new Vector3 { x = -1.316f, y = 2.793f, z = 0 },
                        new Vector3 { x = -2.037f, y = 1.662f, z = 0 }
                       };

 


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && indexPositionMap > 0)
        {
      
                indexPositionMap--;
           

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && indexPositionMap < 9)
        {

            indexPositionMap++;


        }


        setStageMap = stage[indexPositionMap];

        setPoitMap = positionMap[indexPositionMap];
        pointMapItem.transform.position = setPoitMap;




    }
}
