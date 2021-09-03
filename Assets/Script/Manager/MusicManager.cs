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
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void play(string Mymusic)
    {
        AudioSource audio;

        audio = GetComponent<AudioSource>();


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
