using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanalisationWasser : MonoBehaviour
{
    List<Vector3> wVertices = new List<Vector3>();
    List<int> wTriangles = new List<int>();
    List<Vector2> wUvs = new List<Vector2>();
    Mesh mesh;
    //Größe Wasser
    int x = 135;
    int z = 120;

    // Start is called before the first frame update
    void Start()
    {
        wasser();
    }

    void wasser(){
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshRenderer>();

        //Wasser
        for(int i = -z; i <= z; i++){
            for(int j = -x; j <= x; j++){
                //Debug.Log("z: " + i +  " x: " + j);
                wellen(wVertices.Count, j, i);
            }
        }
        
        Renderer rend = this.GetComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Diffuse"));

        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = wVertices.ToArray();
        mesh.triangles = wTriangles.ToArray();
        mesh.uv = wUvs.ToArray();

        mesh.RecalculateNormals();
    }

    void wellen(int vert, int x, int z){

        wVertices.Add(new Vector3(x, randomY(), z));
        wVertices.Add(new Vector3(x, randomY(), z + 1));
        wVertices.Add(new Vector3(x + 1, randomY(), z + 1));
        wVertices.Add(new Vector3(x + 1, randomY(), z));

        wUvs.Add(new Vector2(0,0));
        wUvs.Add(new Vector2(1,1));
        wUvs.Add(new Vector2(0,1));
        wUvs.Add(new Vector2(1,0));

        //A
        wTriangles.Add(vert);
        wTriangles.Add(vert + 2);
        wTriangles.Add(vert + 3);

        //B
        wTriangles.Add(vert + 2);
        wTriangles.Add(vert);
        wTriangles.Add(vert + 1);
    }

    float randomY(){
        return Random.Range(-1.35f, -1.0f);
    }
}
