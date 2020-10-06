using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePerson : MonoBehaviour
{

    public int dialogueNumber;
    public int [] followingDialogueNumber = new int[5];

    bool imCollider;

    private void OnCollisionEnter(Collision col)
    {
        imCollider = true;
        GameObject.Find("DialogScript").GetComponent<Dialogues>().showHintText();
    } 

    private void OnCollisionExit(Collision col)
    {
        imCollider = false;
        GameObject.Find("DialogScript").GetComponent<Dialogues>().deleteHintText();
    } 

    void Update(){
        if(imCollider && Input.GetKey(KeyCode.Space)){
            GameObject.Find("DialogScript").GetComponent<Dialogues>().setDialog(dialogueNumber);
            
        }
    }

}
