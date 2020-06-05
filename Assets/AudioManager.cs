using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip sword, bow, background1, background2;

    static AudioSource audioSource;
    void Start()
    {
        sword = Resources.Load<AudioClip>("SwordSwing");
        bow = Resources.Load<AudioClip>("ArrowShot");
        background1 = Resources.Load<AudioClip>("Background1");
        background2 = Resources.Load<AudioClip>("Background2");
        audioSource = GetComponent<AudioSource>();
        //PlaySound("background1");
        PlaySound("background2");
    }

    public static void PlaySound(string sound)
    {
        switch(sound) {
            case "sword":
                audioSource.PlayOneShot(sword,0.6f);
                    break;
            case "bow":
                audioSource.PlayOneShot(bow,0.5f);
                break;
            case "background1":
                audioSource.PlayOneShot(background1, 0.3f);
                break;
            case "background2":
                audioSource.PlayOneShot(background2,0.3f);
                break;

        }
    }

   
}
