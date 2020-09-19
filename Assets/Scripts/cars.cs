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
        autosEinbahn = new GameObject[4];
        int j = 0;
        for (int i = 0; i < 20; i++){
            if (i < 4){
                //highwayPos
                float z = Random.Range(60f, 85.0f);
                float x = Random.Range(0f, 200.0f);
                autosHighwayPos[i] = createCars(x,z,0f);
            } else if(i < 8){
                //highwayNeg
                float z = Random.Range(35f, 60.0f);
                float x = Random.Range(0f, 200.0f);
                autosHighwayNeg[j] = createCars(x,z,180f);
                j++;
            } else if(i < 12){
                j = i == 8 ? 0 : j;
                var h = Random.Range(-1f, 1f);
                if (h <= 0){
                    float z = 130f;
                    float x = Random.Range(0f, 200.0f);
                    autosEinbahn[j] = createCars(x,z,0);
                } else {
                    float z = 170f;
                    float x = Random.Range(0f, 200.0f);
                    autosEinbahn[j] = createCars(x,z,0);
                }
                j++;
            } else {
                //normal
            } 
            //GameObject car = createCars(Random.Range(0f, 200.0f), Random.Range(0f, 200.0f));
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
            autosHighwayPos[i].transform.position = new Vector3(x - 0.5f, autosHighwayPos[i].transform.position.y, autosHighwayPos[i].transform.position.z);
        }
        for (int i = 0; i < autosHighwayNeg.Length; i++){
            var x = autosHighwayNeg[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayNeg[i].transform.position = new Vector3(x + 0.5f, autosHighwayNeg[i].transform.position.y, autosHighwayNeg[i].transform.position.z);
        }
        for (int i = 0; i < autosEinbahn.Length; i++){
            var x = autosEinbahn[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosEinbahn[i].transform.position = new Vector3(x - 0.5f, autosEinbahn[i].transform.position.y, autosEinbahn[i].transform.position.z);
        }
    }
}
