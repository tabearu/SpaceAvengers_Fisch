using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hinweis_blau : MonoBehaviour
{
    public Canvas canvas;
    public Camera camera;

    void Start(){
        canvas.GetComponent<Canvas>();
        camera.GetComponent<Camera>();
    }

    void Update(){
        //trackt wo die Kamera hinzeigt
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            if(Input.GetKeyDown(KeyCode.E)){
                canvas.enabled = true;
            }
        }
    }
}
