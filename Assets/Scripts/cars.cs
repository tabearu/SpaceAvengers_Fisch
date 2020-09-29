using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{

    public GameObject auto;
    GameObject[] autosHighwayPos;
    GameObject[] autosHighwayNeg;
    GameObject[] autosNormalPos;
    GameObject[] autosNormalNeg;

    // Start is called before the first frame update
    void Start()
    {       
        autosHighwayPos = new GameObject[3];
        autosHighwayNeg = new GameObject[3];
        autosNormalPos = new GameObject[4];
        autosNormalNeg = new GameObject[3];
        int j = 0;
        for (int i = 0; i < 13; i++){
            if (i < 3){
                //highwayPos
                float z = 72.5f;
                float x = Random.Range(0f, 200.0f);
                autosHighwayPos[i] = createCars(x,z,0f);
            } else if(i < 6){
                //highwayNeg
                float z = 53f;
                float x = Random.Range(0f, 200.0f);
                autosHighwayNeg[j] = createCars(x,z,180f);
                j++;
            } else if(i < 10){
               j = i == 6 ? 0 : j;
                float x;
                float z;
                if (i < 16){
                    x = 152f;
                    z = Random.Range(0f, 200.0f);
                } else {
                    x = 59f;
                    z = Random.Range(72f, 200.0f);
                }
                autosNormalPos[j] = createCars(x,z,-90);
                j++;
            } else if (i < 13) {
                j = i == 10 ? 0 : j;
                float x;
                float z;
                if (i < 20){
                    x = 165f;
                    z = Random.Range(0f, 200.0f);
                    autosNormalNeg[j] = createCars(x,z,90f); 
                } else {
                    x = Random.Range(0f, 200.0f);
                    z = 72.5f;
                    autosNormalNeg[j] = createCars(x,z,0f);
                }
                j++;
            } 
        }

    }

    GameObject createCars(float x, float z, float r){
        GameObject car = Instantiate<GameObject> (auto);
        car.transform.position = new Vector3(x, 1f, z);
        car.transform.localScale = new Vector3 (2f, 2f, 3f);
        car.transform.Rotate(0.0f, r, 0.0f);

        var col = car.AddComponent<BoxCollider>();
        col.isTrigger = true;
        col.size = new Vector3(8f, 3f, 3f);
        col.center = new Vector3(0f, 1f, 0);
        //var carRend = car.AddComponent<MeshRenderer>();
        Renderer[] component = car.GetComponentsInChildren<Renderer>();
        Color color = getCarColor();
        car.name = "auto";
        for (int i = 0; i < component.Length; i++)
        {
            if (component[i].name == "Dach" || component[i].name == "Unterbau"){
                component[i].material.color = color;
            } else {
                component[i].material.color = Color.black;
            }
        }
        car.AddComponent<carSpeed>();
        var rig = car.AddComponent<Rigidbody>();
        rig.isKinematic = true;
        rig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        car.AddComponent<carCollider>();

        return car;
    }

    Color getCarColor(){
        Color c;
        int rand = Random.Range(0, 3);
        if (rand == 0){
            c = Color.red;
        } else if (rand == 1){
            c = Color.blue;
        } else {
            c = Color.yellow;
        }
        return c;
    }

    // Update is called once per frame
    void Update()
    {   
                                    
        for (int i = 0; i < autosHighwayPos.Length; i++){
            var speed = autosHighwayPos[i].GetComponent<carSpeed>().speed;
            var x = autosHighwayPos[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayPos[i].transform.position = new Vector3(x - speed, autosHighwayPos[i].transform.position.y, autosHighwayPos[i].transform.position.z);
        }
        for (int i = 0; i < autosHighwayNeg.Length; i++){
            var speed = autosHighwayNeg[i].GetComponent<carSpeed>().speed;
            var x = autosHighwayNeg[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayNeg[i].transform.position = new Vector3(x + speed, autosHighwayNeg[i].transform.position.y, autosHighwayNeg[i].transform.position.z);
        }
        
        for (int i = 0; i < autosNormalPos.Length; i++){
            var speed = autosNormalPos[i].GetComponent<carSpeed>().speed;
            var z = autosNormalPos[i].transform.position.z;
            var x = autosNormalPos[i].transform.position.x;
            //z = z > 200 ? 0 : z;
            z = z < 0 ? 200 : z;
            
            if (z <= 74f && z > 72f && x == 59f) {
                autosNormalPos[i].transform.Rotate(0.0f, 90f, 0.0f);
                autosNormalPos[i].transform.position = new Vector3(x  - speed, autosNormalPos[i].transform.position.y, 72.1f);
            } else if (x == 152f || x == 59f){
                autosNormalPos[i].transform.position = new Vector3(x, autosNormalPos[i].transform.position.y, z - speed);
            } else if (x < 0){
                autosNormalPos[i].transform.Rotate(0.0f, -90f, 0.0f);
                autosNormalPos[i].transform.position = new Vector3(59f, autosNormalPos[i].transform.position.y, 200f);
            } else{
                autosNormalPos[i].transform.position = new Vector3(x  - speed, autosNormalPos[i].transform.position.y, z);
            }            
        }


        for (int i = 0; i < autosNormalNeg.Length; i++){
            var speed = autosNormalNeg[i].GetComponent<carSpeed>().speed;
            var z = autosNormalNeg[i].transform.position.z;
            var x = autosNormalNeg[i].transform.position.x;
            if(x == 71f && z > 200){
                z = 72.5f;
                autosNormalNeg[i].transform.Rotate(0.0f, -90f, 0.0f);
                x = 200f;
            } else  if(z > 200){
                z = 0;
            }
            //z = z < 0 ? 200 : z;
            if (z == 72.5f && x != 165f){
                autosNormalNeg[i].transform.position = new Vector3(x - 0.251f, autosNormalNeg[i].transform.position.y, z);
                if (x < 70f && x >= 69f){  
                    autosNormalNeg[i].transform.Rotate(0.0f, 90f, 0.0f);
                    autosNormalNeg[i].transform.position = new Vector3(71f, autosNormalNeg[i].transform.position.y, z + speed);
                }
            } else {
                autosNormalNeg[i].transform.position = new Vector3(x, autosNormalNeg[i].transform.position.y, z + speed);
            }
            
        }

    }
}
