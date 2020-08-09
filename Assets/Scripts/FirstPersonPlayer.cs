using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
