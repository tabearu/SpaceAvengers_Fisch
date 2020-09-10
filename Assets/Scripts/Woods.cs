using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woods : MonoBehaviour {

    Mesh mesh;
    int amount = 20;

    int[] treeSize = {
        4,
        5,
        5,
        8,
        7,
        9,
        6,
        6,
        7,
        9,
        5,
        7,
        6,
        5,
        6,
        7,
        6,
        7,
        8,
        7
    };
    float[] treeWidth = {
        0.5f,
        0.3f,
        0.5f,
        1f,
        0.7f,
        1f,
        0.8f,
        0.8f,
        0.5f,
        1f,
        0.8f,
        0.7f,
        0.8f,
        0.8f,
        0.8f,
        0.5f,
        1f,
        0.8f,
        0.7f,
        0.8f,
    };
    float[, ] treePos = new float[20, 2] { //{x,y}
        { 1f, 1f }, { 5f, 3f }, { 21f, 2f }, { 2f, 10f }, { 37f, 5f }, { 41f, 12f }, { 14f, 41f }, { 20f, 27f }, //7
        { 34f, 18f }, { 39f, 28f }, { 7f, 45f }, { 5f, 48f }, { 3f, 43f }, { 18f, 23f }, { 14f, 21f }, { 11f, 20f }, { 9f, 21f }, { 1f, 26f }, { 3f, 20f }, { 2f, 23f } //20
    };

    // Start is called before the first frame update
    void Start () {
        CreateMesh ();
        createWood ();
    }

    void CreateMesh () {
        gameObject.AddComponent<MeshFilter> ();
        gameObject.AddComponent<MeshRenderer> ();
        mesh = GetComponent<MeshFilter> ().mesh;
        mesh.Clear ();
    }

    // Update is called once per frame
    void Update () {

    }

    void createWood () {
        int vertCount = 0;
        int triCount = 0;
        Vector3[] vertices; //pos
        int[] triangles; //verk    
        triangles = new int[48 * amount];
        vertices = new Vector3[16 * amount];

        for (int i = 0; i < amount; i++) {
            vertices = addVert (vertices, treePos[i, 0], treePos[i, 1], vertCount, treeWidth[i], treeSize[i]);
            triangles = addTri (triangles, triCount, vertCount);
            createLeaves (treePos[i, 0], treePos[i, 1], i, treeWidth[i], treeSize[i]);
            vertCount += 16;
            triCount += 48;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals ();

        Renderer rend = gameObject.GetComponent<Renderer> ();
        rend.material.color = new Color (102.0f / 255f, 51.0f / 255f, 0f / 255f);
    }

    Vector3[] addVert (Vector3[] vertices, float x, float z, int v, float width, int height) {
        //Stamm
        vertices[v + 0] = new Vector3 (x, 0, z);
        vertices[v + 1] = new Vector3 (x + width, 0, z);
        vertices[v + 2] = new Vector3 (x + width * 2, 0, z + width * 1);
        vertices[v + 3] = new Vector3 (x + width * 2, 0, z + width * 2);
        vertices[v + 4] = new Vector3 (x + width, 0, z + width * 3);
        vertices[v + 5] = new Vector3 (x, 0, z + width * 3);
        vertices[v + 6] = new Vector3 (x - width, 0, z + width * 2);
        vertices[v + 7] = new Vector3 (x - width, 0, z + width);

        vertices[v + 8] = new Vector3 (x, height, z);
        vertices[v + 9] = new Vector3 (x + width, height, z);
        vertices[v + 10] = new Vector3 (x + width * 2, height, z + width * 1);
        vertices[v + 11] = new Vector3 (x + width * 2, height, z + width * 2);
        vertices[v + 12] = new Vector3 (x + width, height, z + width * 3);
        vertices[v + 13] = new Vector3 (x, height, z + width * 3);
        vertices[v + 14] = new Vector3 (x - width, height, z + width * 2);
        vertices[v + 15] = new Vector3 (x - width, height, z + width);

        return vertices;
    }

    int[] addTri (int[] triangles, int t, int v) {
        triangles[t + 0] = v + 0;
        triangles[t + 1] = v + 8;
        triangles[t + 2] = v + 9;
        triangles[t + 3] = v + 9;
        triangles[t + 4] = v + 1;
        triangles[t + 5] = v + 0;

        triangles[t + 6] = v + 1;
        triangles[t + 7] = v + 9;
        triangles[t + 8] = v + 10;
        triangles[t + 9] = v + 10;
        triangles[t + 10] = v + 2;
        triangles[t + 11] = v + 1;

        triangles[t + 12] = v + 2;
        triangles[t + 13] = v + 10;
        triangles[t + 14] = v + 11;
        triangles[t + 15] = v + 11;
        triangles[t + 16] = v + 3;
        triangles[t + 17] = v + 2;

        triangles[t + 18] = v + 3;
        triangles[t + 19] = v + 11;
        triangles[t + 20] = v + 12;
        triangles[t + 21] = v + 12;
        triangles[t + 22] = v + 4;
        triangles[t + 23] = v + 3;

        triangles[t + 24] = v + 4;
        triangles[t + 25] = v + 12;
        triangles[t + 26] = v + 13;
        triangles[t + 27] = v + 13;
        triangles[t + 28] = v + 5;
        triangles[t + 29] = v + 4;

        triangles[t + 30] = v + 5;
        triangles[t + 31] = v + 13;
        triangles[t + 32] = v + 14;
        triangles[t + 33] = v + 14;
        triangles[t + 34] = v + 6;
        triangles[t + 35] = v + 5;

        triangles[t + 36] = v + 6;
        triangles[t + 37] = v + 14;
        triangles[t + 38] = v + 15;
        triangles[t + 39] = v + 15;
        triangles[t + 40] = v + 7;
        triangles[t + 41] = v + 6;

        triangles[t + 42] = v + 7;
        triangles[t + 43] = v + 15;
        triangles[t + 44] = v + 8;
        triangles[t + 45] = v + 8;
        triangles[t + 46] = v + 0;
        triangles[t + 47] = v + 7;

        return triangles;
    }

    void createLeaves (float x, float z, int i, float width, int height) {

        //Aeste bzw blaetter
        var name = "baum" + i;
        GameObject blaetter = new GameObject (name);

        GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3 (width * 3f, width * 3f, width * 3f);
        sphere.transform.Translate (x - (width / 2f), height, z + width / 2f);

        GameObject sphereZ = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphereZ.transform.localScale = new Vector3 (3f, 3f, 3f);
        sphereZ.transform.Translate (x + width + width / 2f, height, z + width / 2f);

        GameObject sphereD = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphereD.transform.localScale = new Vector3 (3f, 3f, 3f);
        sphereD.transform.Translate (x - (width / 2f), height, z + width * 2 + width / 2f);

        GameObject sphereV = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphereV.transform.localScale = new Vector3 (3f, 3f, 3f);
        sphereV.transform.Translate (x + width + width / 2f, height, z + width * 2f + width / 2f);

        GameObject sphereF = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphereF.transform.localScale = new Vector3 (3f, 3f, 3f);
        sphereF.transform.Translate (x + width / 2f, height + 1.5f, z + width + width / 2f);

        var sphereRend = sphere.GetComponent<Renderer> ();
        sphereRend.material.SetColor ("_Color", new Color (0f / 255f, 102.0f / 255f, 0f / 255f));
        sphereRend = sphereZ.GetComponent<Renderer> ();
        sphereRend.material.SetColor ("_Color", new Color (0f / 255f, 102.0f / 255f, 0f / 255f));
        sphereRend = sphereD.GetComponent<Renderer> ();
        sphereRend.material.SetColor ("_Color", new Color (0f / 255f, 102.0f / 255f, 0f / 255f));
        sphereRend = sphereV.GetComponent<Renderer> ();
        sphereRend.material.SetColor ("_Color", new Color (0f / 255f, 102.0f / 255f, 0f / 255f));
        sphereRend = sphereF.GetComponent<Renderer> ();
        sphereRend.material.SetColor ("_Color", new Color (0f / 255f, 102.0f / 255f, 0f / 255f));

        sphere.transform.parent = blaetter.transform;
        sphereZ.transform.parent = blaetter.transform;
        sphereD.transform.parent = blaetter.transform;
        sphereV.transform.parent = blaetter.transform;
        sphereF.transform.parent = blaetter.transform;

        var col = sphereF.AddComponent<BoxCollider>();
        col.size = new Vector3(width, height/2, width);
        col.center = new Vector3(0, -1, 0);
        
    }


}