using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class savedData : MonoBehaviour
{

    void createText(){
        string path = Application.dataPath + "/entscheidungen.txt";
        if(!File.Exists(path)){
            File.WriteAllText(path, "Entscheidungen \n\n");
        }

        string content = "Login date: " + System.DateTime.Now + "\n";

        File.AppendAllText(path, content);
    }

    void Start(){
        createText();
    }
}
