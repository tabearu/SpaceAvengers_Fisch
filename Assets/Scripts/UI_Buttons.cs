using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buttons : MonoBehaviour
{

    public int dialogueNumber;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);   
    }

    void TaskOnClick(){
        Debug.Log("Button pressed");
        GameObject.Find("DialogScript").GetComponent<Dialogues>().setDialog(dialogueNumber);
    }
}
