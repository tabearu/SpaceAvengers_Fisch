using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class savedData : MonoBehaviour
{
    //flags, die im Spiel gesetzt werden sollen, wenn etwas Scenen-übergreifend passieren soll
    //nicht bei reinen Infos
    bool kampfGewonnen;
    bool arbeitPuenktlich;

    string path;

    void getDocument(){
        path = Application.dataPath + "/entscheidungen.txt";
        if(!File.Exists(path)){
            File.WriteAllText(path, "Entscheidungen \n\nTime:6"); 
            //File.AppendAllText(path, content);
        }
        setGameTime();
    }

    void Start(){
        getDocument();
    }

    public void saveGameTime(){
        string t  = "Time:" + GameObject.Find("LightByTime").GetComponent<LightByTime>().getTimeHour();
        //Debug.Log("savingtime: " + t);
        var lines = File.ReadAllLines(path);
        StreamWriter writer = new StreamWriter(path);
        foreach (var line in lines)
        {
            if (line.Contains("Time")){
                writer.WriteLine(t);
            }
        }
        writer.Close();
    }

    public void setGameTime(){
        float time = 0;
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            if (line.Contains("Time")){
                string s = line;
                string r = "";
                for (int i = 0; i < s.Length; i++){
                    if (!System.Char.IsLetter(s[i]) && s[i] != ':'){
                        r += s[i];
                    }
                }
                time = float.Parse(r);
            }
        }
        //Debug.Log("Time: " + time);
        GameObject.Find("LightByTime").GetComponent<LightByTime>().setTime(time);
    }
}
