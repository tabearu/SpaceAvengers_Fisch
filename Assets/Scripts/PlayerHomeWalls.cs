using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomeWalls : MonoBehaviour
{

    Mesh mesh;
    float roomHeight;

    // Start is called before the first frame update
    void Start()
    {
        roomHeight = 5;
        CreateMesh();
        createWalls();
        
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    void CreateMesh(){
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createWalls(){
        Vector3 [] vertices  = new Vector3[8];
        int[] triangles = new int[30];

        //Raum
        vertices[0] = new Vector3(8, 0, -5);
        vertices[1] = new Vector3(8, 0, 5);
        vertices[2] = new Vector3(8, roomHeight, -5);
        vertices[3] = new Vector3(8, roomHeight, 5);
        vertices[4] = new Vector3(-8, 0, -5);
        vertices[5] = new Vector3(-8, 0, 5);
        vertices[6] = new Vector3(-8, roomHeight, -5);
        vertices[7] = new Vector3(-8, roomHeight, 5);


        mesh.vertices = vertices;




        //Raum
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        triangles[6] = 0;
        triangles[7] = 2;
        triangles[8] = 4;
        triangles[9] = 4;
        triangles[10] = 2;
        triangles[11] = 6;

        triangles[12] = 4;
        triangles[13] = 6;
        triangles[14] = 5;
        triangles[15] = 5;
        triangles[16] = 6;
        triangles[17] = 7;

        triangles[18] = 5;
        triangles[19] = 7;
        triangles[20] = 3;
        triangles[21] = 5;
        triangles[22] = 3;
        triangles[23] = 1;

        //Decke
        triangles[24] = 2;
        triangles[25] = 3;
        triangles[26] = 6;
        triangles[27] = 3;
        triangles[28] = 7;
        triangles[29] = 6;


        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        Renderer rend = gameObject.GetComponent<Renderer> ();
        rend.material = Resources.Load("Materials/ApartmentBuilding") as Material;
    }

    
}
