using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public Canvas canvas;
    Camera camera;
    float speedH = 4.0f;
    float speedV = 2.0f;

    float y = 0.0f;
    float x = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        canvas.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.enabled == false){
            Vector3 pos = this.camera.transform.position;
            if(Input.GetKey(KeyCode.W)){
                this.camera.transform.Translate(Vector3.forward * 0.1f);
            }
            if(Input.GetKey(KeyCode.A)){
                this.camera.transform.transform.Translate(-Vector3.right * 0.1f);
            }
            if(Input.GetKey(KeyCode.S)){
                this.camera.transform.transform.Translate(-Vector3.forward * 0.1f);
            }
            if(Input.GetKey(KeyCode.D)){
                this.camera.transform.transform.Translate(Vector3.right * 0.1f);
            }
            if (Input.GetMouseButtonDown(0)){
                this.camera.transform.transform.Rotate(0,-10.0f,0);
            }
            if (Input.GetMouseButtonDown(1)){
                this.camera.transform.transform.Rotate(0,10.0f,0);
            } 
            y += speedH * Input.GetAxis("Mouse X");
            //x -= speedV * Input.GetAxis("Mouse Y");

            this.camera.transform.eulerAngles = new Vector3(x, y, 0.0f);
        }
        
    }
}
