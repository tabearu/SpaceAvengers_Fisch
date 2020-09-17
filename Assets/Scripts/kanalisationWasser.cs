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
    int x = 30;
    int y = 30;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Translate(-x, 0, -y);
        wasser();
    }

    void wasser(){
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshRenderer>();

        Renderer rend = this.GetComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Diffuse"));

        //Wasser
        for(int i = -x; i <= x; i++){
            wellen(wVertices.Count, i);
        }

        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = wVertices.ToArray();
        mesh.triangles = wTriangles.ToArray();
        mesh.uv = wUvs.ToArray();

        mesh.RecalculateNormals();
    }

    void wellen(int vert, int bla){
        
    }
}
