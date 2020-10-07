using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCollider : MonoBehaviour {

    bool endingTrigger = false;
    bool kanalhinweis = false;

    private void OnTriggerEnter (Collider col) {
        
        if (gameObject.name == "EndingTrigger" && col.gameObject.name == "Main Camera" && !endingTrigger) {
            endingTrigger = true;
            GameObject.Find ("Start_Skript").GetComponent<savedData> ().checkForEnding ();

        } 

        //Kanalisationshinweis
        if (gameObject.name == ""  && col.gameObject.name == "Main Camera"){
            kanalhinweis = true;
            GameObject.Find ("Start_Skript").GetComponent<savedData> ().writeLine ("Kanalisation-Hinweis:True");
        }

        //
        if (gameObject.name == ""  && col.gameObject.name == "Main Camera"){
            kanalhinweis = true;
            GameObject.Find ("Start_Skript").GetComponent<savedData> ().writeLine ("Kanalisation-Hinweis:True");
        }

    }
}