using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCollider : MonoBehaviour {

    void OnTriggerEnter (Collider col) {
        Collider collider = gameObject.transform.GetChild (11).GetComponent<Collider> (); //Front-Collider
        Debug.Log("Gameobject: " + gameObject.name + " collided with: " + col.gameObject.name);

        if (col.gameObject.name == "Main Camera") {
            gameObject.GetComponent<carSpeed>().speed = 0;
        }else if (collider.bounds.Intersects (col.bounds)) { //nur wenn Front-Collider kollidiert
            if ((col.gameObject.name == "Back-Col") || (col.gameObject.name == "Left-Col") || (col.gameObject.name == "Right-Col")) {
                gameObject.GetComponent<carSpeed> ().standing = true;
                gameObject.GetComponent<carSpeed> ().speed = 0;
            }
        }  
    }

    void OnTriggerExit (Collider col) {
        if (col.gameObject.name == "Main Camera") {
            gameObject.GetComponent<carSpeed> ().speed = 0.25f;
        }else if ((col.gameObject.name == "Back-Col") || (col.gameObject.name == "Left-Col") || (col.gameObject.name == "Right-Col")) {
            gameObject.GetComponent<carSpeed> ().standing = false;
            gameObject.GetComponent<carSpeed> ().speed = 0.25f;
        }  
    }

}