using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{

    public GameObject auto;

    // Start is called before the first frame update
    void Start()
    {           
        for (int i = 0; i < 10; i++){
            createCars(Random.Range(0f, 200.0f), Random.Range(0f, 200.0f));
        }
    }

    void createCars(float x, float z){
        var car = Instantiate<GameObject> (auto);
        car.transform.position = new Vector3(x, 1f, z);
        car.transform.localScale = new Vector3 (2f, 2f, 3f);
        //var carRend = gameObject.AddComponent<Renderer> ();
        //carRend.material.color = Color.red;
        //car.transform.parent = autos.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
