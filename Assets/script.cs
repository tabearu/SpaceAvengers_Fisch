using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    GameObject city;
    GameObject boden;
    GameObject mensch;
    List<Vector3> cVertices = new List<Vector3>();
    List<int> cTriangles = new List<int>();
    float y = 0;
    float x;
    float z;
    int i;
    Mesh cMesh;
    Quaternion dRot = Quaternion.AngleAxis(0, Vector3.up);
    Vector3 dPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Überraschung!");
        testStadt();

        fussgaenger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fussgaenger(){
        mensch = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mensch.transform.localScale = new Vector3(1, 3, 1);
        var menschRenderer = mensch.GetComponent<Renderer>();
        menschRenderer.material = new Material(Shader.Find("Diffuse"));
        menschRenderer.material.SetColor("_Color", Color.red);

        mensch.transform.Translate(23, 1, 5);

        i = Random.Range(5, 10);
        for(int j = 0; j <= i; j++){
            x = Random.Range(-33.0f, 33.0f);
            z = Random.Range(-33.0f, 33.0f);
            dPos = new Vector3(x, 0, z);
        
            Instantiate(mensch, dPos, dRot);
        }
    }
    void testStadt(){
        city = new GameObject("city");
        city.transform.Translate(0, 0, 0);

        city.AddComponent<MeshFilter>();
        city.AddComponent<MeshRenderer>();
        Renderer cityRenderer = city.GetComponent<MeshRenderer>();
        cityRenderer.material = new Material(Shader.Find("Specular"));
        Texture tex = Resources.Load("haus") as Texture;
        cityRenderer.material.mainTexture = tex;

        //erster Klotz
        cVertices.Add(new Vector3(0, 0, 0));
        cVertices.Add(new Vector3(1, 0, 0));
        cVertices.Add(new Vector3(1, 0, 1));
        cVertices.Add(new Vector3(0, 0, 1));
        cVertices.Add(new Vector3(0, 3, 0));
        cVertices.Add(new Vector3(1, 3, 0));
        cVertices.Add(new Vector3(1, 3, 1));
        cVertices.Add(new Vector3(0, 3, 1));
        
        for(int x = -33; x <= 34; x = x + 5){
            for(int z = -33; z <= 33; z = z + 5){
                y = Random.Range(1, 10);
                klotz(cVertices.Count, x, y, z);
            }
        }
        
        cMesh = new Mesh();
        city.GetComponent<MeshFilter>().mesh = cMesh;

        MeshCollider cCollider = city.AddComponent<MeshCollider>();
        Rigidbody cBody = city.AddComponent<Rigidbody>();
        cBody.isKinematic = true;

        cMesh.vertices = cVertices.ToArray();
        cMesh.triangles = cTriangles.ToArray();

        cCollider.sharedMesh = cMesh;

        cMesh.RecalculateBounds();
        cMesh.RecalculateNormals();
    }

    void klotz(int i, int x, float y, int z){
        cVertices.Add(new Vector3(x, 0, z));
        cVertices.Add(new Vector3(x + 1, 0, z));
        cVertices.Add(new Vector3(x + 1, 0, z + 1));
        cVertices.Add(new Vector3(x, 0, z + 1));
        cVertices.Add(new Vector3(x, y, z));
        cVertices.Add(new Vector3(x + 1, y, z));
        cVertices.Add(new Vector3(x + 1, y, z + 1));
        cVertices.Add(new Vector3(x, y, z + 1));

        //A
        cTriangles.Add(i);
        cTriangles.Add(i + 4);
        cTriangles.Add(i + 5);

        //B
        cTriangles.Add(i);
        cTriangles.Add(i + 5);
        cTriangles.Add(i + 1);
        
        //C
        cTriangles.Add(i + 1);
        cTriangles.Add(i + 5);
        cTriangles.Add(i + 6);

        //D
        cTriangles.Add(i + 1);
        cTriangles.Add(i + 6);
        cTriangles.Add(i + 2);

        //E
        cTriangles.Add(i + 2);
        cTriangles.Add(i + 6);
        cTriangles.Add(i + 3);

        //F
        cTriangles.Add(i + 3);
        cTriangles.Add(i + 6);
        cTriangles.Add(i + 7);

        //G
        cTriangles.Add(i + 3);
        cTriangles.Add(i + 7);
        cTriangles.Add(i + 4);

        //H
        cTriangles.Add(i + 3);
        cTriangles.Add(i + 4);
        cTriangles.Add(i + 0);

        //I
        cTriangles.Add(i + 4);
        cTriangles.Add(i + 7);
        cTriangles.Add(i + 5);

        //J
        cTriangles.Add(i + 7);
        cTriangles.Add(i + 6);
        cTriangles.Add(i + 5);
    }
}
