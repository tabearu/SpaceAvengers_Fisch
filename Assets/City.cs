   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{

    Mesh meshCity;
    int size;
    int distance;

    //groesse der gebauede
    //0 = strasse
    int[,] buildingSize = new int[9,11] {
        {1, 0, 5, 4, 5, 5, 3, 2, 0, 0, 2},
        {1, 0, 1, 4, 5, 5, 5, 3, 0, 0, 2},
        {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {4, 0, 3, 4, 5, 5, 3, 2, 0, 0, 3},
        {3, 0, 2, 3, 5, 4, 4, 3, 0, 0, 2},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 1, 3, 2, 2, 1, 3, 0, 0, 2}
    };

    // Start is called before the first frame update
    void Start()
    {   
        size = 20;
        distance = 20;
        CreateMesh();
        buildCity();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void CreateMesh(){
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        meshCity = GetComponent<MeshFilter>().mesh;
        meshCity.Clear();        
    }


    void buildCity(){       
        meshCity.subMeshCount = 100;
        Vector3 [] vertices  = new Vector3[8*100];
        int[] triangles = new int[30*100];
        int vtCount = 0;
        int trCount = 0;
        int i = 0;
        int j = 0;

        for (int x = 0; x < 200 && i < 10; x += size+3){
            for (int z = 0; z < 200 && j < 11; z += (size+distance)){
                if (buildingSize[i, j] != 0){
                    triangles = addTr(triangles, trCount, vtCount);
                    trCount += 30;
                    vertices = addVert(vertices, x, z, vtCount, (float)buildingSize[i,j]);
                    vtCount += 8;
                    //Debug.Log("Building: " + i +  " " + j);
                } else {
                    z+=distance;
                }
                j++;
            }
            j = 0;
            i++;
        }
        meshCity.vertices = vertices;
        meshCity.triangles = triangles;

        meshCity.RecalculateNormals();

        Vector2[] uvs = new Vector2[vertices.Length];
        for (i = 0; i < uvs.Length; i++){
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
            
        }
        meshCity.uv = uvs;

        Renderer rend = gameObject.GetComponent<Renderer> ();
        //rend.material = new Material(Shader.Find("Specular")); 
        //Texture texture = Resources.Load("Textures/Tower") as Texture;
        //rend.material.mainTexture = texture;
        rend.material = Resources.Load("Materials/ApartmentBuilding") as Material;

        //rend.material.color = Color.grey;
    }

    Vector3 [] addVert(Vector3[] vertices, float x, float z, int i, float y){
        //Debug.Log("Rand: " + y);
        y *= size;

        Vector3 a = new Vector3(x,0,z);
        Vector3 b = new Vector3(x,y,z);
        Vector3 c = new Vector3(x,y,z+size);
        Vector3 d = new Vector3(x,0,z+size);
        Vector3 e = new Vector3(x+size,y,z+size);
        Vector3 f = new Vector3(x+size,0,z+size);
        Vector3 g = new Vector3(x+size,0,z);
        Vector3 h = new Vector3(x+size,y,z);

        vertices[i+0] = a;
        vertices[i+1] = b;
        vertices[i+2] = c;
        vertices[i+3] = d;
        vertices[i+4] = e;
        vertices[i+5] = f;
        vertices[i+6] = g;
        vertices[i+7] = h;

        return vertices;
    }

    int[] addTr(int[] triangles, int trCount, int vtCount){
        //ABC + ACD rechts
        triangles[trCount+0] = vtCount+3;
        triangles[trCount+1] = vtCount+1;
        triangles[trCount+2] = vtCount+0;
        triangles[trCount+3] = vtCount+1;
        triangles[trCount+4] = vtCount+3;
        triangles[trCount+5] = vtCount+2;   

        //BCH + HCE oben
        triangles[trCount+6] = vtCount+1;
        triangles[trCount+7] = vtCount+2;
        triangles[trCount+8] = vtCount+7;
        triangles[trCount+9] = vtCount+7;
        triangles[trCount+10] = vtCount+2;
        triangles[trCount+11] = vtCount+4;   
        
        //HEF + GHF vorne
        triangles[trCount+12] = vtCount+7;
        triangles[trCount+13] = vtCount+4;
        triangles[trCount+14] = vtCount+5;
        triangles[trCount+15] = vtCount+6;
        triangles[trCount+16] = vtCount+7;
        triangles[trCount+17] = vtCount+5; 

        //DCE + CEF hinten
        triangles[trCount+18] = vtCount+5;
        triangles[trCount+19] = vtCount+4;
        triangles[trCount+20] = vtCount+2;
        triangles[trCount+21] = vtCount+5;
        triangles[trCount+22] = vtCount+2;
        triangles[trCount+23] = vtCount+3;  

        //ABH + AHG links
        triangles[trCount+24] = vtCount+0;
        triangles[trCount+25] = vtCount+1;
        triangles[trCount+26] = vtCount+7;
        triangles[trCount+27] = vtCount+0;
        triangles[trCount+28] = vtCount+7;
        triangles[trCount+29] = vtCount+6; 

        return triangles;
    }

}
