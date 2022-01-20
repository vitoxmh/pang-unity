using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapSelection : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator Animator;
    private string sceneMap;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void select(string _sceneMap)
    {

        sceneMap = _sceneMap;

        Animator.SetBool("Select", true);

    }



    public void nextEscene()
    {
        Debug.Log("Mapa seleccionado"+sceneMap);
        SceneManager.LoadScene(sceneMap);
    }
     

}
