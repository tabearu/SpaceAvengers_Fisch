using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCollider : MonoBehaviour {

    bool endingTrigger = false;
    bool kanalhinweis = false;
    bool schluessel = false;

    private void OnTriggerEnter (Collider col) {
        
        //ending
        if (gameObject.name == "EndingTrigger" && col.gameObject.name == "Main Camera" && !endingTrigger) {
            endingTrigger = true;
            GameObject.Find ("Start_Skript").GetComponent<savedData> ().checkForEnding ();

        } 

        //Kanalisationshinweis
        if (gameObject.name == "kanalHinweis"  && col.gameObject.name == "Main Camera" && !kanalhinweis){
            
            kanalhinweis = true;
            GameObject.Find ("Start_Skript").GetComponent<savedData> ().writeLine ("Kanalisation-Hinweis:True");
            Destroy(GameObject.Find ("kanalHinweis"));
        }

        //schluessel
        if (gameObject.name == "schluessel"  && col.gameObject.name == "Main Camera" && !schluessel){
            
            schluessel = true;
            GameObject.Find ("Start_Skript").GetComponent<savedData> ().writeLine ("Schluessel:True");
            
        }

    }
}