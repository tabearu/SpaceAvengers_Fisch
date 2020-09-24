using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{

    public GameObject auto;
    GameObject[] autosHighwayPos;
    GameObject[] autosHighwayNeg;
    GameObject[] autosEinbahn;
    GameObject[] autosNormalPos;
    GameObject[] autosNormalNeg;

    // Start is called before the first frame update
    void Start()
    {       
        autosHighwayPos = new GameObject[4];
        autosHighwayNeg = new GameObject[4];
        autosEinbahn = new GameObject[5];
        autosNormalPos = new GameObject[5];
        autosNormalNeg = new GameObject[4];
        int j = 0;
        for (int i = 0; i < 22; i++){
            if (i < 4){
                //highwayPos
                float z = i < 6 ? 72.5f : 85f;
                float x = Random.Range(0f, 200.0f);
                autosHighwayPos[i] = createCars(x,z,0f);
            } else if(i < 8){
                //highwayNeg
                float z = i < 2 ? 40.5f : 53f;
                float x = Random.Range(0f, 200.0f);
                autosHighwayNeg[j] = createCars(x,z,180f);
                j++;
            } else if(i < 13){
                j = i == 8 ? 0 : j;
                float z = i < 10 ? 130f : 170f;
                float x = Random.Range(0f, 200.0f);
                autosEinbahn[j] = createCars(x,z,0);
                j++;
            } else if (i < 18) {
                j = i == 13 ? 0 : j;
                float x = i < 16 ? 152f : 59f;
                float z = Random.Range(0f, 200.0f);
                autosNormalPos[j] = createCars(x,z,-90);
                j++;
            } else if (i < 22) {
                j = i == 18 ? 0 : j;
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
        col.size = new Vector3(6.2f, 3f, 2.5f);
        col.center = new Vector3(0, 1f, 0);
        //var carRend = gameObject.AddComponent<Renderer> ();
        //carRend.material.color = Color.red;
        //car.transform.parent = autos.transform;
        return car;
    }

    // Update is called once per frame
    void Update()
    {   
        for (int i = 0; i < autosHighwayPos.Length; i++){
            var x = autosHighwayPos[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayPos[i].transform.position = new Vector3(x - 0.25f, autosHighwayPos[i].transform.position.y, autosHighwayPos[i].transform.position.z);
        }
        for (int i = 0; i < autosHighwayNeg.Length; i++){
            var x = autosHighwayNeg[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayNeg[i].transform.position = new Vector3(x + 0.25f, autosHighwayNeg[i].transform.position.y, autosHighwayNeg[i].transform.position.z);
        }
        for (int i = 0; i < autosEinbahn.Length; i++){
            var x = autosEinbahn[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosEinbahn[i].transform.position = new Vector3(x - 0.25f, autosEinbahn[i].transform.position.y, autosEinbahn[i].transform.position.z);
        }
        for (int i = 0; i < autosNormalPos.Length; i++){
            var z = autosNormalPos[i].transform.position.z;
            z = z > 200 ? 0 : z;
            z = z < 0 ? 200 : z;
            if (z <= 74f && z > 72f) {
                autosNormalPos[i].transform.Rotate(0.0f, 90f, 0.0f);
                autosNormalPos[i].transform.position = new Vector3(autosNormalPos[i].transform.position.x  - 0.25f, autosNormalPos[i].transform.position.y, 72f);
            }
            if (autosNormalPos[i].transform.position.x != 59f){
                var x = autosNormalPos[i].transform.position.x;
                if (x < 0){
                    autosNormalPos[i].transform.Rotate(0.0f, -90f, 0.0f);
                    autosNormalPos[i].transform.position = new Vector3(59f, autosNormalPos[i].transform.position.y, 200f);
                } else {
                    autosNormalPos[i].transform.position = new Vector3(x  - 0.25f, autosNormalPos[i].transform.position.y, autosNormalPos[i].transform.position.z);
                }
            } else {
                autosNormalPos[i].transform.position = new Vector3(autosNormalPos[i].transform.position.x, autosNormalPos[i].transform.position.y, z - 0.25f);
            }
            
        }


        for (int i = 0; i < autosNormalNeg.Length; i++){
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
                    autosNormalNeg[i].transform.position = new Vector3(71f, autosNormalNeg[i].transform.position.y, z + 0.25f);
                }
            } else {
                autosNormalNeg[i].transform.position = new Vector3(x, autosNormalNeg[i].transform.position.y, z + 0.25f);
            }
            
        }
    }
}
