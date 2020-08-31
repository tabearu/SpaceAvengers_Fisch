using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hinweis_blau : MonoBehaviour
{
    public Canvas canvas;

    void start(){
        canvas.GetComponent<Canvas>();
    }
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Click");
            canvas.gameObject.SetActive(true);
        }
       
    }
}
