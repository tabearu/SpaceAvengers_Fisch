using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dorf : MonoBehaviour
{
    List<Vector3> hVertices = new List<Vector3>();
    List<int> hTriangles = new List<int>();
    List<Vector2> hUvs = new List<Vector2>();
    List<Vector3> koordinaten = new List<Vector3>();

    Mesh hMesh;

    //Größe Häuser
    int a = 6;
    int b = 8;
    int y = 6;

    // Start is called before the first frame update
    void Start()
    {      
        gameObject.transform.Translate(-32, 0, -28);

        koordinatenHaeuser(); //Liste Startkoordinaten Häuser
        haeuser(); //erstellt Häuser von Dorf
    }
    
    void koordinatenHaeuser(){
        koordinaten.Add(new Vector3(16, 0, 1));
        koordinaten.Add(new Vector3(28, 0, 1));
        koordinaten.Add(new Vector3(2, 0, 20));
        koordinaten.Add(new Vector3(18, 0, 20));
        koordinaten.Add(new Vector3(46, 0, 15));
        koordinaten.Add(new Vector3(2, 0, 40));
        koordinaten.Add(new Vector3(16, 0, 35));
        koordinaten.Add(new Vector3(35, 0, 35));
        koordinaten.Add(new Vector3(48, 0, 37));
        koordinaten.Add(new Vector3(36, 0, 50));
        koordinaten.Add(new Vector3(45, 0, 50));
        koordinaten.Add(new Vector3(2, 0, 65));
        koordinaten.Add(new Vector3(18, 0, 53));
        koordinaten.Add(new Vector3(28, 0, 23));
        koordinaten.Add(new Vector3(35, 0, 64));
        koordinaten.Add(new Vector3(45, 0, 65));
        koordinaten.Add(new Vector3(55, 0, 67));
        koordinaten.Add(new Vector3(11, 0, 85));
        koordinaten.Add(new Vector3(10, 0, 85));
        koordinaten.Add(new Vector3(28, 0, 85));
        koordinaten.Add(new Vector3(40, 0, 85));
    }

    void haeuser(){
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        
        Renderer dorfRend = this.GetComponent<MeshRenderer>();
        dorfRend.material = new Material(Shader.Find("Diffuse"));
        
        //Häuser
        for(int i = 0; i < koordinaten.Count; i++){
            klotz(hVertices.Count, koordinaten[i]);
        }

        hMesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = hMesh;

        MeshCollider hCollider = gameObject.AddComponent<MeshCollider>();
        Rigidbody hBody = gameObject.AddComponent<Rigidbody>();
        hBody.isKinematic = true;

        hMesh.vertices = hVertices.ToArray();
        hMesh.triangles = hTriangles.ToArray();
        hMesh.uv = hUvs.ToArray();

        hCollider.sharedMesh = hMesh;
        hMesh.RecalculateNormals();
    }

    void klotz(int i, Vector3 vector){
        float x = vector.x;
        float z = vector.z;

        hVertices.Add(new Vector3(x, 0, z));
        hVertices.Add(new Vector3(x + a, 0, z));
        hVertices.Add(new Vector3(x + a, 0, z + b));
        hVertices.Add(new Vector3(x, 0, z + b));
        hVertices.Add(new Vector3(x, y, z));
        hVertices.Add(new Vector3(x + a, y, z));
        hVertices.Add(new Vector3(x + a, y, z + b));
        hVertices.Add(new Vector3(x, y, z + b));

        hUvs.Add(new Vector2(0, 0));
        hUvs.Add(new Vector2(1, 1));
        hUvs.Add(new Vector2(0, 1));
        hUvs.Add(new Vector2(1, 0));
        hUvs.Add(new Vector2(0, 0));
        hUvs.Add(new Vector2(1, 1));
        hUvs.Add(new Vector2(0, 1));
        hUvs.Add(new Vector2(1, 0));

        //A
        hTriangles.Add(i);
        hTriangles.Add(i + 4);
        hTriangles.Add(i + 1);

        //B
        hTriangles.Add(i + 4);
        hTriangles.Add(i + 5);
        hTriangles.Add(i + 1);

        //C
        hTriangles.Add(i + 1);
        hTriangles.Add(i + 5);
        hTriangles.Add(i + 2);

        //D
        hTriangles.Add(i + 5);
        hTriangles.Add(i + 6);
        hTriangles.Add(i + 2);
    
        //E
        hTriangles.Add(i + 2);
        hTriangles.Add(i + 6);
        hTriangles.Add(i + 3);

        //F
        hTriangles.Add(i + 6);
        hTriangles.Add(i + 7);
        hTriangles.Add(i + 3);

        //G
        hTriangles.Add(i + 3);
        hTriangles.Add(i + 7);
        hTriangles.Add(i + 4);

        //H
        hTriangles.Add(i + 3);
        hTriangles.Add(i + 4);
        hTriangles.Add(i);

        //I
        hTriangles.Add(i + 4);
        hTriangles.Add(i + 6);
        hTriangles.Add(i + 5);

        //J
        hTriangles.Add(i + 4);
        hTriangles.Add(i + 7);
        hTriangles.Add(i + 6);
    }
}
