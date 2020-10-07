using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Canvas canvas;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.GetComponent<Camera>();
        canvas.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            if(hit.collider.name == "Hinweis_blau"){
                if(Input.GetKeyDown(KeyCode.E)){
                    canvas.enabled = true;
                }
            }
        }
    }
}
