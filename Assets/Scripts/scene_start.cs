using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scene_start : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        canvas.GetComponent<Canvas>();
        //canvas.gameObject.SetActive(false);
        canvas.enabled = false;
    }
}
