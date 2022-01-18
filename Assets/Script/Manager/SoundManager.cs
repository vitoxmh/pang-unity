using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager sm;

    public AudioClip[] sound;

    private void Awake()
    {
        if (sm == null)
        {
            sm = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (sm != null)
        {
            Destroy(gameObject);
        }

         
    }

    public void stop()
    {
        AudioSource audio;

        audio = GetComponent<AudioSource>();
        audio.Stop();

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
            case "Lose":
                audio.PlayOneShot(sound[7], 1f);
            break;
            case "Coin":
                audio.PlayOneShot(sound[8], 1f);
            break;
            case "Plane":
                audio.PlayOneShot(sound[9], 1f);
            break;
            case "AngkorWat":
                audio.PlayOneShot(sound[10], 1f);
            break;
            case "CountDown":
                audio.PlayOneShot(sound[10], 1f);
            break;
            case "Life": 
                audio.PlayOneShot(sound[11], 1f);
            break;
        }
    }
}
