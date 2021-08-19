using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] music;
    public int setMusic;
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
