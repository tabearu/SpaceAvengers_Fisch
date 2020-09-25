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
    void createText(){
        string path = Application.dataPath + "/entscheidungen.txt";
        if(!File.Exists(path)){
            File.WriteAllText(path, "Entscheidungen \n\n");
        }
        //Testdaten
        string content = "Login date: " + System.DateTime.Now + "\n";

        File.AppendAllText(path, content);
    }

    void Start(){
        createText();
    }
}
