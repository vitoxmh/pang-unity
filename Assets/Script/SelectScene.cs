using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void Scene(string s)
    { 

        SceneManager.LoadScene(s);

    }

}
