using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passanten : MonoBehaviour
{
    GameObject buergersteig;
    // Start is called before the first frame update
    void Start()
    {
        buergersteig = GameObject.Find("Buergersteige");
        if(buergersteig != null){
            Debug.Log("buh");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){
        Debug.Log(this.name + "OnTriggerEnter mit " + other.gameObject.name);       
    }
}
