using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dorf : MonoBehaviour
{
    List<Vector3> hVertices = new List<Vector3>();
    List<int> hTriangles = new List<int>();
    List<Vector2> hUvs = new List<Vector2>();

    Mesh hMesh;

    // Start is called before the first frame update
    void Start()
    {
        haeuser(); //erstellt Häuser von Dorf
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void haeuser(){
        gameObject.transform.Translate(-32, 0, 28);

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        
        Renderer dorfRend = this.GetComponent<MeshRenderer>();
        dorfRend.material = new Material(Shader.Find("Diffuse"));
        
        //erstes Haus
        hVertices.Add(new Vector3(0, 0, 0));
        hVertices.Add(new Vector3(1, 0, 0));
        hVertices.Add(new Vector3(1, 0, 1));
        hVertices.Add(new Vector3(0, 0, 1));
        hVertices.Add(new Vector3(0, 3, 0));
        hVertices.Add(new Vector3(1, 3, 0));
        hVertices.Add(new Vector3(1, 3, 1));
        hVertices.Add(new Vector3(0, 3, 1));

        hUvs.Add(new Vector2(0, 0));
        hUvs.Add(new Vector2(1, 1));
        hUvs.Add(new Vector2(0, 1));
        hUvs.Add(new Vector2(1, 0));
        hUvs.Add(new Vector2(0, 0));
        hUvs.Add(new Vector2(1, 1));
        hUvs.Add(new Vector2(0, 1));
        hUvs.Add(new Vector2(1, 0));

        hTriangles.Add(0);
        hTriangles.Add(4);
        hTriangles.Add(5);

        hTriangles.Add(0);
        hTriangles.Add(5);
        hTriangles.Add(1);
        
        hTriangles.Add(1);
        hTriangles.Add(5);
        hTriangles.Add(6);

        hTriangles.Add(1);
        hTriangles.Add(6);
        hTriangles.Add(2);

        hTriangles.Add(2);
        hTriangles.Add(6);
        hTriangles.Add(3);

        hTriangles.Add(3);
        hTriangles.Add(6);
        hTriangles.Add(7);

        hTriangles.Add(3);
        hTriangles.Add(7);
        hTriangles.Add(4);

        hTriangles.Add(3);
        hTriangles.Add(4);
        hTriangles.Add(0);

        hTriangles.Add(4);
        hTriangles.Add(7);
        hTriangles.Add(5);

        hTriangles.Add(7);
        hTriangles.Add(6);
        hTriangles.Add(5);

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
}
