using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexHome : MonoBehaviour
{
    Mesh mesh;
    float roomHeight;

    // Start is called before the first frame update
    void Start()
    {
        roomHeight = 4;
        CreateMesh();
        createWalls();
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
        Vector3 [] vertices  = new Vector3[14];
        int[] triangles = new int[42];

        //Raum
        vertices[0] = new Vector3(8, 0, -5);
        vertices[1] = new Vector3(8, 0, 5);
        vertices[2] = new Vector3(8, roomHeight, -5);
        vertices[3] = new Vector3(8, roomHeight, 5);
        vertices[4] = new Vector3(-8, 0, -5);
        vertices[5] = new Vector3(-8, 0, 5);
        vertices[6] = new Vector3(-8, roomHeight, -5);
        vertices[7] = new Vector3(-8, roomHeight, 5);

        //secret room
        vertices[8] = new Vector3(-2, 0, -11);
        vertices[9] = new Vector3(-2, 0, -5);
        vertices[10] = new Vector3(-2, roomHeight, -11);
        vertices[11] = new Vector3(-2, roomHeight, -5);
        vertices[12] = new Vector3(-8, 0, -11);
        vertices[13] = new Vector3(-8, roomHeight, -11);


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
        triangles[8] = 9;
        triangles[9] = 9;
        triangles[10] = 2;
        triangles[11] = 11;

        triangles[12] = 12;
        triangles[13] = 13;
        triangles[14] = 5;
        triangles[15] = 5;
        triangles[16] = 13;
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

        //Secret Room
            triangles[30] = 9;
            triangles[31] = 11;
            triangles[32] = 8;
            triangles[33] = 8;
            triangles[34] = 11;
            triangles[35] = 10;
    
            triangles[36] = 8;
            triangles[37] = 10;
            triangles[38] = 12;
            triangles[39] = 12;
            triangles[40] = 10;
            triangles[41] = 13;



        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        Renderer rend = gameObject.GetComponent<Renderer> ();
        rend.material = Resources.Load("Materials/ApartmentBuilding") as Material;
    }
}
