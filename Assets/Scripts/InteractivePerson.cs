using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePerson : MonoBehaviour {

    public bool einmalGespraech = false;

    public int dialogueNumber;
    //Nummern der Dialoge die im Gesrpäch direkt hintereinander sind, abgegrenzt durch Btn-Weiter
    public int[] followingDialogueNumber = new int[5] { 0, 0, 0, 0, 0 };

    //Optionen zur auwählen zb bei nachfragen
    /*
    erste Zahl muss mit followifollowingDialogueNumber überinstimmen, 
    zweite und vierte Zahl sind die Antworten die auf die Buttons kommen
    dritte und fünfte sind die Antworten auf die Buttons
    */
    public int[, ] dialogueOptions = new int[4, 5] { { 4, 8, 9, 0, 0 }, { 5, 6, 7, 0, 0 } , {24,25,27,26,27}, {34,35,36,37,38}};
    string normalName;

    int index = 0;

    bool imCollider;

    private void OnCollisionEnter (Collision col) {
        imCollider = true;
        if (index == 0){
            GameObject.Find ("DialogScript").GetComponent<Dialogues> ().showHintText ();
        }
    }

    private void OnCollisionExit (Collision col) {
        imCollider = false;
        GameObject.Find ("DialogScript").GetComponent<Dialogues> ().deleteHintText ();
        gameObject.name = normalName;
        if (!einmalGespraech) {
            resetIndex ();
        }
    }

    void Update () {
        if (imCollider && Input.GetKey (KeyCode.Space) && index == 0) {
            GameObject.Find ("DialogScript").GetComponent<Dialogues> ().setDialog (dialogueNumber);
            if (index < followingDialogueNumber.Length && followingDialogueNumber[index] != 0 && index == 0) {
                normalName = gameObject.name;
                gameObject.name = "aktiveUnterhaltungMitPerson";
                setNextDialogue ();
            }
        }
    }

    public void setNextDialogue () {
        if (index < followingDialogueNumber.Length && followingDialogueNumber[index] != 0) { //weiterer Dialog vorhanden

            Debug.Log ("SetDialogue- index: " + index);
            bool dialogueOptionsSet = false;

            if (index != 0) {
                for (int i = 0; i < dialogueOptions.GetLength (0); i++) {
                    Debug.Log ("Search options- i: " + i + " index: " + index);
                    if (followingDialogueNumber[index] == dialogueOptions[i, 0]) { //dialog-optionen gefunden
                        dialogueOptionsSet = true;
                        if (dialogueOptions[i, 1] != 0) {
                            GameObject.Find ("DialogScript").GetComponent<Dialogues> ().setButton (dialogueOptions[i, 1], 2, dialogueOptions[i, 2]);
                        }
                        if (dialogueOptions[i, 3] != 0) {
                            GameObject.Find ("DialogScript").GetComponent<Dialogues> ().setButton (dialogueOptions[i, 3], 1, dialogueOptions[i, 4]);
                        }
                    }
                }
            }

            if (!dialogueOptionsSet && index == 0) {
                GameObject.Find ("DialogScript").GetComponent<Dialogues> ().setWeiterBtn (followingDialogueNumber[1]);
            } else if (!dialogueOptionsSet) {
                GameObject.Find ("DialogScript").GetComponent<Dialogues> ().setWeiterBtn (followingDialogueNumber[index]);
            }
        } else {
            GameObject.Find ("DialogScript").GetComponent<Dialogues> ().hideWeiterBtn ();
        }
        index++;

    }

    public void resetIndex () {
        index = 0;
    }
}