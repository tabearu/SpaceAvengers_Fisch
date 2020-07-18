using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spieler : MonoBehaviour
{
    BoxCollider spielerCollider;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        spielerCollider = gameObject.AddComponent<BoxCollider>();
        spielerCollider.isTrigger = true;

        this.transform.localScale = new Vector3(1, 3, 1);
        var spielerRenderer = this.GetComponent<Renderer>();
        spielerRenderer.material = new Material(Shader.Find("Diffuse"));
        spielerRenderer.material.SetColor("_Color", Color.blue);

        camera = Camera.main;
        camera.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            this.transform.Translate(Vector3.forward * 0.1f);
        }
        if(Input.GetKey(KeyCode.A)){
            this.transform.Translate(-Vector3.right * 0.1f);
        }
        if(Input.GetKey(KeyCode.S)){
            this.transform.Translate(-Vector3.forward * 0.1f);
        }
        if(Input.GetKey(KeyCode.D)){
            this.transform.Translate(Vector3.right * 0.1f);
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log(this.name + " collides with " + other.gameObject.name);
    }
}
