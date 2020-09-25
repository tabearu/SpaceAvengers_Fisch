using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasser : MonoBehaviour
{
    List<Vector3> wVertices = new List<Vector3>();
    List<int> wTriangles = new List<int>();
    List<Vector2> wUvs = new List<Vector2>();
    Mesh mesh;
    
    //Größe Wasser
    int x = 10;
    int z = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        //erstes Quadrat
        wVertices.Add(new Vector3(-x, 0, -z));
        wVertices.Add(new Vector3(-x + 1, 0, -z));
        wVertices.Add(new Vector3(-x + 1, 0, -z + 1));
        wVertices.Add(new Vector3(-x, 0, -z + 1));

        wUvs.Add(new Vector2(0, 0));
        wUvs.Add(new Vector2(0, 1));
        wUvs.Add(new Vector2(1, 1));
        wUvs.Add(new Vector2(1, 0));

        //A
        wTriangles.Add(0);
        wTriangles.Add(2);
        wTriangles.Add(1);

        //B
        wTriangles.Add(2);
        wTriangles.Add(0);
        wTriangles.Add(3);

        //erste Reihe
        reihe();

        //dynamische Quadrate
        wasser();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void reihe(){
        for(int i = (-z + 1); i < z; i++){
            int vert = wVertices.Count -1 ;
            
            wVertices.Add(new Vector3(-x, 0, i + 1));
            wVertices.Add(new Vector3(-x + 1, 0, i + 1));

            wUvs.Add(new Vector2(1, 1));
            wUvs.Add(new Vector2(0, 0));

            //A
            wTriangles.Add(vert + 2);
            wTriangles.Add(vert);
            wTriangles.Add(vert + 1);

            //B
            /*wTriangles.Add(vert + 2);
            wTriangles.Add(vert);
            wTriangles.Add(vert + 1);*/
        }
    }
    void wasser(){
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshRenderer>();

        //Quadrat
        /*for(int i = (-x + 1); i <= x; i++){
            for(int j = (-z + 1 ); j <= z; j++){
                quadrat(wVertices.Count - 1, i, j);
                Debug.Log("x: " + i + " z: " + j);
            }
        }*/

        Renderer rend = this.GetComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Diffuse"));

        mesh = new Mesh();
        this.GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = wVertices.ToArray();
        mesh.triangles = wTriangles.ToArray();
        mesh.uv = wUvs.ToArray();

        mesh.RecalculateNormals();
    }
    
    void quadrat(int vert, int x, int z){
        wVertices.Add(new Vector3(x + 1, 0, z - 1));
        wVertices.Add(new Vector3(x + 1, 0, z));

        wUvs.Add(new Vector2(1, 0));
        wUvs.Add(new Vector2(0, 1));

        //A
        wTriangles.Add(vert);
        wTriangles.Add(vert - 1);
        wTriangles.Add(vert + 2);

        //B
        /*wTriangles.Add(vert);
        wTriangles.Add(vert + 2);
        wTriangles.Add(vert + 1);*/
    }

    float randomY(){
        return Random.Range(-1.35f, -1.0f);
    }
}
