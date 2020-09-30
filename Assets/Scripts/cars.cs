using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour {

    public GameObject auto;
    GameObject[] autosHighwayPos;
    GameObject[] autosHighwayNeg;
    GameObject[] autosNormalPos;
    GameObject[] autosNormalNeg;
    GameObject autos;

    // Start is called before the first frame update
    void Start () {
        autos = new GameObject ("Autos");

        autosHighwayPos = new GameObject[2];
        autosHighwayNeg = new GameObject[2];
        autosNormalPos = new GameObject[3];
        autosNormalNeg = new GameObject[3];
        int j = 0;
        for (int i = 0; i < 10; i++) {
            if (i < 2) {
                //highwayPos
                float z = 72.5f;
                float x = Random.Range (0f, 200.0f);
                autosHighwayPos[i] = createCars (x, z, 0f, i);
            } else if (i < 4) {
                //highwayNeg
                float z = 53f;
                float x = Random.Range (0f, 200.0f);
                autosHighwayNeg[j] = createCars (x, z, 180f, i);
                j++;
            } else if (i < 7) {
                j = i == 4 ? 0 : j;
                float x;
                float z;
                if (i < 5) {
                    x = 152f;
                    z = Random.Range (0f, 200.0f);
                } else {
                    x = 61f;
                    z = Random.Range (72f, 200.0f);
                }
                autosNormalPos[j] = createCars (x, z, -90, i);
                j++;
            } else if (i < 10) {
                j = i == 7 ? 0 : j;
                float x;
                float z;
                if (i < 9) {
                    x = 165f;
                    z = Random.Range (0f, 200.0f);
                    autosNormalNeg[j] = createCars (x, z, 90f, i);
                } else {
                    x = Random.Range (70f, 200.0f);
                    z = 72.5f;
                    autosNormalNeg[j] = createCars (x, z, 0f, i);
                }
                j++;
            }
        }

    }

    GameObject createCars (float x, float z, float r, int m) {

        GameObject car = Instantiate<GameObject> (auto);
        car.transform.position = new Vector3 (x, 1f, z);
        car.transform.localScale = new Vector3 (2f, 2f, 3f);
        car.transform.Rotate (0.0f, r, 0.0f);
        car.name = "auto " + m;

        GameObject left = new GameObject ("Left-Col");
        left.transform.position = new Vector3 (x, 1f, z);
        left.transform.localScale = new Vector3 (2f, 2f, 3f);
        left.transform.Rotate (0.0f, r, 0.0f);
        var colleft = left.AddComponent<BoxCollider> ();
        colleft.isTrigger = true;
        colleft.size = new Vector3 (8f, 3f, 1f);
        colleft.center = new Vector3 (0f, 1f, -1.5f);

        GameObject right = new GameObject ("Right-Col");
        right.transform.position = new Vector3 (x, 1f, z);
        right.transform.localScale = new Vector3 (2f, 2f, 3f);
        right.transform.Rotate (0.0f, r, 0.0f);
        var rightcol = right.AddComponent<BoxCollider> ();
        rightcol.isTrigger = true;
        rightcol.size = new Vector3 (8f, 3f, 1f);
        rightcol.center = new Vector3 (0f, 1f, 1.5f);

        GameObject back = new GameObject ("Back-Col");
        back.transform.position = new Vector3 (x, 1f, z);
        back.transform.localScale = new Vector3 (2f, 2f, 3f);
        back.transform.Rotate (0.0f, r, 0.0f);
        var backcol = back.AddComponent<BoxCollider> ();
        backcol.isTrigger = true;
        backcol.size = new Vector3 (2f, 3f, 2f);
        backcol.center = new Vector3 (3f, 1f, 0);

        GameObject front = new GameObject ("Front-Col");
        front.transform.position = new Vector3 (x, 1f, z);
        front.transform.localScale = new Vector3 (2f, 2f, 3f);
        front.transform.Rotate (0.0f, r, 0.0f);
        var frontcol = front.AddComponent<BoxCollider> ();
        frontcol.isTrigger = true;
        frontcol.size = new Vector3 (2f, 3f, 2f);
        frontcol.center = new Vector3 (-3f, 1f, 0);

        left.transform.parent = car.transform;
        right.transform.parent = car.transform;
        back.transform.parent = car.transform;
        front.transform.parent = car.transform;

        Renderer[] component = car.GetComponentsInChildren<Renderer> ();
        Color color = getCarColor ();

        for (int i = 0; i < component.Length; i++) {
            if (component[i].name == "Dach" || component[i].name == "Unterbau") {
                component[i].material.color = color;
            } else {
                component[i].material.color = Color.black;
            }
        }
        car.AddComponent<carSpeed> ();
        var rig = car.AddComponent<Rigidbody> ();
        rig.isKinematic = true;
        rig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        car.AddComponent<carCollider> ();

        var audio = car.AddComponent<AudioSource>();
        audio.clip = Resources.Load("Sounds/car") as AudioClip;
        audio.loop = true;
        audio.volume = 0.001f;
        audio.Play();
        

        car.transform.parent = autos.transform;

        return car;
    }

    Color getCarColor () {
        Color c;
        int rand = Random.Range (0, 3);
        if (rand == 0) {
            c = Color.red;
        } else if (rand == 1) {
            c = Color.blue;
        } else {
            c = Color.yellow;
        }
        return c;
    }

    // Update is called once per frame
    void Update () {
        movement();
        
        //turn car lights on/off 
        bool day = gameObject.transform.parent.GetComponent<LightByTime>().day;
        if (day){
            for (int i = 0; i < autos.transform.childCount; i++){
                autos.transform.GetChild(i).transform.GetChild(1).GetComponent<Light>().intensity = 0;
                autos.transform.GetChild(i).transform.GetChild(2).GetComponent<Light>().intensity = 0;
            }
        } else {
            for (int i = 0; i < autos.transform.childCount; i++){
                autos.transform.GetChild(i).transform.GetChild(1).GetComponent<Light>().intensity = 10f;
                autos.transform.GetChild(i).transform.GetChild(2).GetComponent<Light>().intensity = 10f;
            }
        }
    }

    void movement(){
        for (int i = 0; i < autosHighwayPos.Length; i++) {
            var speed = autosHighwayPos[i].GetComponent<carSpeed> ().speed;
            var x = autosHighwayPos[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayPos[i].transform.position = new Vector3 (x - speed, autosHighwayPos[i].transform.position.y, autosHighwayPos[i].transform.position.z);
        }
        for (int i = 0; i < autosHighwayNeg.Length; i++) {
            var speed = autosHighwayNeg[i].GetComponent<carSpeed> ().speed;
            var x = autosHighwayNeg[i].transform.position.x;
            x = x > 200 ? 0 : x;
            x = x < 0 ? 200 : x;
            autosHighwayNeg[i].transform.position = new Vector3 (x + speed, autosHighwayNeg[i].transform.position.y, autosHighwayNeg[i].transform.position.z);
        }

        for (int i = 0; i < autosNormalPos.Length; i++) {
            var speed = autosNormalPos[i].GetComponent<carSpeed> ().speed;
            var z = autosNormalPos[i].transform.position.z;
            var x = autosNormalPos[i].transform.position.x;
            //z = z > 200 ? 0 : z;
            z = z < 0 ? 200 : z;

            if (z <= 74f && z > 72f && x == 61f) {
                autosNormalPos[i].transform.Rotate (0.0f, 90f, 0.0f);
                autosNormalPos[i].transform.position = new Vector3 (x - speed, autosNormalPos[i].transform.position.y, 72.1f);
            } else if (x == 152f || x == 61f) {
                autosNormalPos[i].transform.position = new Vector3 (x, autosNormalPos[i].transform.position.y, z - speed);
            } else if (x < 0) {
                autosNormalPos[i].transform.Rotate (0.0f, -90f, 0.0f);
                autosNormalPos[i].transform.position = new Vector3 (61f, autosNormalPos[i].transform.position.y, 200f);
            } else {
                autosNormalPos[i].transform.position = new Vector3 (x - speed, autosNormalPos[i].transform.position.y, z);
            }
        }

        for (int i = 0; i < autosNormalNeg.Length; i++) {
            var speed = autosNormalNeg[i].GetComponent<carSpeed> ().speed;
            var z = autosNormalNeg[i].transform.position.z;
            var x = autosNormalNeg[i].transform.position.x;
            if (x == 71f && z > 200) {
                z = 72.5f;
                autosNormalNeg[i].transform.Rotate (0.0f, -90f, 0.0f);
                x = 200f;
            } else if (z > 200) {
                z = 0;
            }
            if (z == 72.5f && x != 165f) {
                autosNormalNeg[i].transform.position = new Vector3 (x - 0.251f, autosNormalNeg[i].transform.position.y, z);
                if (x < 70f && x > 69.7f) {
                    autosNormalNeg[i].transform.Rotate (0.0f, 90f, 0.0f);
                    autosNormalNeg[i].transform.position = new Vector3 (71f, autosNormalNeg[i].transform.position.y, z + speed);
                }
            } else {
                autosNormalNeg[i].transform.position = new Vector3 (x, autosNormalNeg[i].transform.position.y, z + speed);
            }

        }
    }
}