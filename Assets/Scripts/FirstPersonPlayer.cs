using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public Canvas canvas;
    Camera camera;
    float speedH = 4.0f;
    float speedV = 2.0f;

    float y = 0.0f;
    float x = 0.0f;

    bool videoPlaying;
    bool dialogueDisplayed;

    // Start is called before the first frame update
    void Start()
    {   
        camera = Camera.main;
        canvas.GetComponent<Canvas>();
        try {
            videoPlaying = GameObject.Find("Video").GetComponent<videoPlayer>().playing;
            dialogueDisplayed = GameObject.Find("DialogScript").GetComponent<Dialogues>().dialogueIsDisplayed;
        } catch {
            videoPlaying = false;
            dialogueDisplayed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        tryCatchBools();
        
        if(canvas.enabled == false && !videoPlaying && !dialogueDisplayed){
            if(Input.GetKey(KeyCode.W)){
                this.camera.transform.Translate(Vector3.forward * 0.1f);
                gameObject.GetComponent<audioPlayer> ().playAudio();
            }
            if(Input.GetKey(KeyCode.A)){
                this.camera.transform.transform.Translate(-Vector3.right * 0.1f);
                gameObject.GetComponent<audioPlayer> ().playAudio();
            }
            if(Input.GetKey(KeyCode.S)){
                this.camera.transform.transform.Translate(-Vector3.forward * 0.1f);
                gameObject.GetComponent<audioPlayer> ().playAudio();
            }
            if(Input.GetKey(KeyCode.D)){
                this.camera.transform.transform.Translate(Vector3.right * 0.1f);
                gameObject.GetComponent<audioPlayer> ().playAudio();
            }
            
            y += speedH * Input.GetAxis("Mouse X");
            //x -= speedV * Input.GetAxis("Mouse Y");

            this.camera.transform.eulerAngles = new Vector3(x, y, 0.0f);
        }
        
    }

    void tryCatchBools(){
        try {
            videoPlaying = GameObject.Find("Video").GetComponent<videoPlayer>().playing;
            
        } catch {
            videoPlaying = false;
        }
        try{
            dialogueDisplayed = GameObject.Find("DialogScript").GetComponent<Dialogues>().dialogueIsDisplayed;
        } catch {
            dialogueDisplayed = false;
        }
    }
}
