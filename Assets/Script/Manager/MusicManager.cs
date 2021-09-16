using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MusicManager mn;

    public AudioClip[] music;
    public int setMusic;
    private AudioSource audio;


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

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        audio = GetComponent<AudioSource>();
        audio.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void stop()
    {

        audio.Stop();

    }


    public void play(string Mymusic)
    {
       

        
        switch (Mymusic)
        {
            case "MrFuji":
                audio.PlayOneShot(music[0], 1f);
             break;
            case "Barcelona":
                audio.PlayOneShot(music[1], 1f);
            break;
            case "Esmerald":
                audio.PlayOneShot(music[2], 1f);
            break;
            
        }

    }
}
