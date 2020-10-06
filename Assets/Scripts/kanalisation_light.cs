using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanalisation_light : MonoBehaviour
{

    GameObject go;

    // Start is called before the first frame update
    void Start()
    {   
        go  = GameObject.Find("Lights");
    }


    void Update()
    {
        Light l = go.transform.GetChild(Random.Range(0, go.transform.childCount)).GetComponent<Light>();
        l.intensity = l.intensity == 1 ? 0 : 1;
    }
}
