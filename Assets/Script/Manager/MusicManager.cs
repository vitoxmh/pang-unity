using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MusicManager mn;

    public AudioClip[] music;
    public int setMusic;


    private void Awake()
    {
        if (mn == null)
        {
            mn = this;
        }
        else if (mn != null)
        {
            Destroy(gameObject);
        }


    }
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(music[setMusic], 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
