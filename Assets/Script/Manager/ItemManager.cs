using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static ItemManager im;

    public GameObject[] item;


    private void Awake()
    {
         

        if (im == null)
        {
            im = this;
           
        }
        else if (im != null)
        {
            Destroy(gameObject);
        }

        
    }

    
    public void createItem(string Getitem, Transform positionObject)
    {

        switch (Getitem)
        {

           case "Arrow":
                Instantiate(item[0], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Hook":
                Instantiate(item[1], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Gun":
                Instantiate(item[2], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Shield":
                Instantiate(item[3], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Clock":
                Instantiate(item[4], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "SandClock":
                Instantiate(item[5], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Dynamite":
                Instantiate(item[6], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           default:
                Instantiate(item[0], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break; 

        }
        




    }



    public void createItemRandom(Transform positionObject)
    {

        int RandomInt;

        int combo = ManagerScore.ms.combo;


        if(combo >= 0 && combo <= 7)
        {

            RandomInt = Random.Range(0, 60);

            if(RandomInt == 0 || RandomInt == 10 || RandomInt == 20 || RandomInt == 30 || RandomInt == 40 || RandomInt == 50 || RandomInt == 35 || RandomInt == 25)
            {

                // Dinamita
                createItem("Dynamite", positionObject);


            }
            else if(RandomInt == 15 || RandomInt == 30 || RandomInt == 50)
            {

                // Sheild
                createItem("Shield", positionObject);

            }
            else if (RandomInt == 11 || RandomInt == 31 || RandomInt == 49)
            {

                // Hook
                createItem("Hook", positionObject);
            }
            else if (RandomInt == 12 || RandomInt == 32 || RandomInt == 48)
            {

                // Arrow
                createItem("Arrow", positionObject);
            }
            else if (RandomInt == 13 || RandomInt == 33 || RandomInt == 47)
            {

                // Clock
                createItem("Clock", positionObject);
            }
            else if (RandomInt == 14 || RandomInt == 34 || RandomInt == 46)
            {

                // SandClock
                createItem("SandClock", positionObject);
            }
            else if (RandomInt == 15 || RandomInt == 35 || RandomInt == 45)
            {

                // Gun
                createItem("Gun", positionObject);
            }


        }
        else
        {





            RandomInt = Random.Range(0, 50);

            if (RandomInt == 0 || RandomInt == 10 || RandomInt == 30 || RandomInt == 40)
            {

                // Dinamita
                createItem("Dynamite", positionObject);

            }
            else if (RandomInt == 1 || RandomInt == 11 || RandomInt == 21 || RandomInt == 31 || RandomInt == 41 || RandomInt == 50)
            {

                // Sheild
                createItem("Shield", positionObject);

            }
            else if (RandomInt == 2 || RandomInt == 12 || RandomInt == 22 || RandomInt == 32 || RandomInt == 42 || RandomInt == 49)
            {

                // Hook
                createItem("Hook", positionObject);
            }
            else if (RandomInt == 3 || RandomInt == 13 || RandomInt == 23 || RandomInt == 33 || RandomInt == 43 || RandomInt == 48)
            {

                // Arrow
                createItem("Arrow", positionObject);
            }
            else if (RandomInt == 4 || RandomInt == 14 || RandomInt == 24 || RandomInt == 34 || RandomInt == 44 || RandomInt == 47)
            {

                // Clock
                createItem("Clock", positionObject);
            }
            else if (RandomInt == 3 || RandomInt == 13 || RandomInt == 23 || RandomInt == 33 || RandomInt == 43 || RandomInt == 48)
            {

                // SandClock
                createItem("SandClock", positionObject);
            }
            else if (RandomInt == 4 || RandomInt == 14 || RandomInt == 24 || RandomInt == 34 || RandomInt == 44 || RandomInt == 47)
            {

                // Gun
                createItem("Gun", positionObject);
            }




        }

        


        





    }





}
