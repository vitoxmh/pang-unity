using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] sound;



    void Start()
    {
      
    }

  


    public void play(string mySound)
    {

        AudioSource audio;
        
        audio = GetComponent<AudioSource>();

       
        switch (mySound)
        {
            case "Firehook":
                audio.PlayOneShot(sound[0], 1f);
            break;
            case "FireBullet":
                audio.PlayOneShot(sound[1], 1f);
            break;
            case "HookAnchored":
                audio.PlayOneShot(sound[2], 1f);
            break;
            case "GetItem":
                audio.PlayOneShot(sound[3], 1f);
            break;
            case "Brokenblock":
                audio.PlayOneShot(sound[4], 1f);
            break;
            case "Bang":
                audio.PlayOneShot(sound[5], 1f);
            break;
            case "BulletCrush":
                audio.PlayOneShot(sound[6], 1f);
            break;
        }
    }
}
