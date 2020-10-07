using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class savedData : MonoBehaviour {
    //flags, die im Spiel gesetzt werden sollen, wenn etwas Scenen-übergreifend passieren soll
    //nicht bei reinen Infos
    bool kampfGewonnen;
    bool arbeitPuenktlich;
    bool firstStart = true;
    bool firstStartOverride;

    string path;

    public VideoClip startsequenz;

    void getDocument () {
        path = Application.dataPath + "/entscheidungen.txt";
        if (!File.Exists (path)) {
            File.WriteAllText (path, "Entscheidungen \n\nTime:6\n");
            SceneManager.LoadScene ("PlayerHome");
            //File.AppendAllText(path, content);
        }
        setGameTime ();
    }

    void Start () {
        getDocument ();
        checkFirstStart();
    }

    public void saveGameTime () {
        string t = "Time:" + GameObject.Find ("LightByTime").GetComponent<LightByTime> ().getTimeHour ();
        //Debug.Log("savingtime: " + t);
        var lines = File.ReadAllLines (path);
        StreamWriter writer = new StreamWriter (path);
        foreach (var line in lines) {
            if (line.Contains ("Time")) {
                writer.WriteLine (t);
            } else {
                writer.WriteLine (line);
            }
        }
        writer.Close ();
    }

    public void setGameTime () {
        float time = 0;
        var lines = File.ReadAllLines (path);
        foreach (var line in lines) {
            if (line.Contains ("Time")) {
                string s = line;
                string r = "";
                for (int i = 0; i < s.Length; i++) {
                    if (!System.Char.IsLetter (s[i]) && s[i] != ':') {
                        r += s[i];
                    }
                }
                time = float.Parse (r);
            }
        }
        //Debug.Log("Time: " + time);
        GameObject.Find ("LightByTime").GetComponent<LightByTime> ().setTime (time);
    }

    void checkFirstStart () {
        var lines = File.ReadAllLines (path);
        StreamWriter writer = new StreamWriter (path);
        bool lineFound = false;
        foreach (var line in lines) {
            if (line.Contains ("First:true")) {
                var v = GameObject.Find("Video").AddComponent<videoPlayer>();
                v.playVideo();
                writer.WriteLine ("First:false");
                firstStart = false;
            } else if (line.Contains ("First:false")){
                writer.WriteLine (line);
                lineFound = true;
            } else {
                writer.WriteLine (line);
            }
        }
        writer.Close ();
        if (firstStart && !lineFound){
            File.AppendAllText(path, "First:true");
        }
    }

    string read (string key){
        var lines = File.ReadAllLines (path);
        foreach (var line in lines) {
            if (line.Contains (key)) {
                return line;
            }
        }
        return "";
    }

    public bool writeLine(string key){
        var lines = File.ReadAllLines (path);
        foreach (var line in lines) {
            if (line.Contains (key)) {
                return true;
            }
        }
        File.AppendAllText(path, key);
        return false;
    }

}