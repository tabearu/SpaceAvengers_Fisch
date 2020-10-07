using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoPlayer : MonoBehaviour {

    bool restartAudio = false;
    public bool playing;
    public bool endingVideo = false;

    /*
    void Start () {
        VideoPlayer vp = gameObject.AddComponent<VideoPlayer> ();
        AudioSource audioSource = gameObject.AddComponent<AudioSource> ();

        vp.playOnAwake = false;
        //p.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        //vp.targetMaterialRenderer = GetComponent<Renderer>();
        //vp.targetMaterialProperty = "_MainTex";
        vp.targetTexture = Resources.Load ("Textures/videoTexture") as RenderTexture;
        vp.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
        vp.SetTargetAudioSource (0, audioSource);
    }
    */

    public void setClip(VideoClip c){
        VideoPlayer vp = gameObject.GetComponent<VideoPlayer> ();
        vp.clip = c;
    }

    public void playVideo () {
        VideoPlayer vp = gameObject.GetComponent<VideoPlayer> ();
        if (!vp.isPlaying) {
            GameObject.Find ("Start_Skript").GetComponent<AudioSource> ().Stop ();
            vp.Play ();
            playing = true;
            InvokeRepeating ("checkOver", .1f, .1f);
        }
    }

    void checkOver () {
        var vp = gameObject.GetComponent<VideoPlayer> ();
        if (!vp.isPlaying && !restartAudio && !endingVideo) {
            GameObject.Find ("Start_Skript").GetComponent<AudioSource> ().Play ();
            Destroy (GameObject.Find ("Main Camera/Canvas/RawImage"));
            restartAudio = true;
            playing = false;
            //Destroy RawImage
        }
    }

}