using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWalking : MonoBehaviour
{
    
    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void playAudio(){
        if(!audioSrc.isPlaying){
            audioSrc.Play();
        }
    }
}
