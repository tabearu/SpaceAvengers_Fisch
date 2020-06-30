using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{

    Mesh meshCity;
    int size;
    int distance;

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
        int noIdea = 0;
        for (int x = 0; x < 200; x += size+3){
            for (int z = 0; z < 200; z += (size+distance)){
                triangles = addTr(triangles, trCount, vtCount);
                trCount += 30;
                vertices = addVert(vertices, x, z, vtCount);
                vtCount += 8;
                noIdea++;
                if (noIdea == 4){
                    noIdea = 0;
                } else {
                    z+=1;
                }
            }
        }
        meshCity.vertices = vertices;
        meshCity.triangles = triangles;

        meshCity.RecalculateNormals();

        Renderer rend = gameObject.GetComponent<Renderer> ();
        rend.material = new Material(Shader.Find("Diffuse")); 
        rend.material.color = Color.grey;
    }

    Vector3 [] addVert(Vector3[] vertices, float x, float z, int i){
        float y = Random.Range(10.0f,60.0f);
        //Debug.Log("Rand: " + y);

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
