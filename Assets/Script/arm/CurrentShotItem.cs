using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShotItem : MonoBehaviour
{
    public GameObject itemArrow;
    public GameObject itemAncle;
    public GameObject itemGun;
    
    public void CurrentShot(int item)
    {

        Debug.Log("Tipoooo" + item);

        if (item == 0)
        {

            itemArrow.SetActive(true);
            itemAncle.SetActive(false);
            itemGun.SetActive(false);

        } 
        else if (item == 1)
        {

            itemArrow.SetActive(false);
            itemAncle.SetActive(true);
            itemGun.SetActive(false);

        }
        else if (item == 2)
        {

            itemArrow.SetActive(false);
            itemAncle.SetActive(false);
            itemGun.SetActive(true);

        }
        else
        {
            itemArrow.SetActive(false);
            itemAncle.SetActive(false);
            itemGun.SetActive(false);

        }

    }

}
