using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_erkennen : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            if(hit.collider.tag == "NPC_interaktiv"){
               Debug.Log("NPC gefunden");
            }
        }
    }
}
