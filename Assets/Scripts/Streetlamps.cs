using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streetlamps : MonoBehaviour {

    Mesh meshCity;
    float size;
    int height;
    int amount = 10;
    float[, ] pos = new float[10, 2] { //{x,y}
        { 0, 22f }, { 20, 22f }, { 40f, 22f }, { 60f, 22f }, { 80f, 22f }, { 100f, 22f }, { 120f, 22f }, { 135f, 22f }, { 185f, 22f }, { 205f, 22f } //10
    };

    void Start () {
        size = 0.5f;
        height = 9;
        CreateMesh ();
        buildCity ();
    }

    void CreateMesh () {
        gameObject.AddComponent<MeshFilter> ();
        gameObject.AddComponent<MeshRenderer> ();
        meshCity = GetComponent<MeshFilter> ().mesh;
        meshCity.Clear ();
    }

    Vector3[] addVert (Vector3[] vertices, float x, float z, int v) {
        vertices[v + 0] = new Vector3 (x, 0, z);
        vertices[v + 1] = new Vector3 (x - size, 0, z);
        vertices[v + 2] = new Vector3 (x - size, 0, z + size);
        vertices[v + 3] = new Vector3 (x, 0, z + size);
        vertices[v + 4] = new Vector3 (x, height, z);
        vertices[v + 5] = new Vector3 (x - size, height, z);
        vertices[v + 6] = new Vector3 (x - size, height, z + size);
        vertices[v + 7] = new Vector3 (x, height, z + size);
        vertices[v + 8] = new Vector3 (x - size, height, z + size + height / 3);
        vertices[v + 9] = new Vector3 (x, height, z + size + height / 3);
        vertices[v + 10] = new Vector3 (x - size, height + size, z + size);
        vertices[v + 11] = new Vector3 (x, height + size, z + size);
        vertices[v + 12] = new Vector3 (x - size, height + size, z + size + height / 3);
        vertices[v + 13] = new Vector3 (x, height + size, z + size + height / 3);

        return vertices;
    }

    int[] addTri (int[] triangles, int t, int v) {
        triangles[t + 0] = v + 9;
        triangles[t + 1] = v + 13;
        triangles[t + 2] = v + 8;
        triangles[t + 3] = v + 8;
        triangles[t + 4] = v + 13;
        triangles[t + 5] = v + 12;

        triangles[t + 6] = v + 0;
        triangles[t + 7] = v + 4;
        triangles[t + 8] = v + 7;
        triangles[t + 9] = v + 0;
        triangles[t + 10] = v + 7;
        triangles[t + 11] = v + 3;

        triangles[t + 12] = v + 3;
        triangles[t + 13] = v + 7;
        triangles[t + 14] = v + 6;
        triangles[t + 15] = v + 3;
        triangles[t + 16] = v + 6;
        triangles[t + 17] = v + 2;

        triangles[t + 18] = v + 2;
        triangles[t + 19] = v + 6;
        triangles[t + 20] = v + 1;
        triangles[t + 21] = v + 6;
        triangles[t + 22] = v + 5;
        triangles[t + 23] = v + 1;

        triangles[t + 24] = v + 1;
        triangles[t + 25] = v + 5;
        triangles[t + 26] = v + 4;
        triangles[t + 27] = v + 1;
        triangles[t + 28] = v + 4;
        triangles[t + 29] = v + 0;

        triangles[t + 30] = v + 4;
        triangles[t + 31] = v + 11;
        triangles[t + 32] = v + 7;
        triangles[t + 33] = v + 6;
        triangles[t + 34] = v + 10;
        triangles[t + 35] = v + 5;

        triangles[t + 36] = v + 5;
        triangles[t + 37] = v + 10;
        triangles[t + 38] = v + 4;
        triangles[t + 39] = v + 10;
        triangles[t + 40] = v + 11;
        triangles[t + 41] = v + 4;

        triangles[t + 42] = v + 11;
        triangles[t + 43] = v + 13;
        triangles[t + 44] = v + 7;
        triangles[t + 45] = v + 7;
        triangles[t + 46] = v + 13;
        triangles[t + 47] = v + 9;

        triangles[t + 48] = v + 11;
        triangles[t + 49] = v + 10;
        triangles[t + 50] = v + 12;
        triangles[t + 51] = v + 11;
        triangles[t + 52] = v + 12;
        triangles[t + 53] = v + 13;

        triangles[t + 54] = v + 8;
        triangles[t + 55] = v + 12;
        triangles[t + 56] = v + 6;
        triangles[t + 57] = v + 12;
        triangles[t + 58] = v + 10;
        triangles[t + 59] = v + 6;

        triangles[t + 60] = v + 9;
        triangles[t + 61] = v + 8;
        triangles[t + 62] = v + 7;
        triangles[t + 63] = v + 7;
        triangles[t + 64] = v + 8;
        triangles[t + 65] = v + 6;

        return triangles;
    }

    GameObject createLamp (float x, float z, int i) {
        GameObject lightGO = new GameObject ("Streetlamp" + i);
        Light light = lightGO.AddComponent<Light> ();
        light.type = LightType.Spot;
        light.range = 10;
        light.spotAngle = 75;
        light.intensity = 30;
        lightGO.transform.Rotate (90.0f, 0, 0);
        lightGO.transform.position = new Vector3 (x - (size / 2), height + (size / 2), z + size + (height / 3) / 0.75f);
        light.color = new Color (214.0f / 255f, 240.0f / 255f, 255.0f / 255f);
        
        return lightGO;
    }

    void buildCity () {
        int vertCount = 0;
        int triCount = 0;
        Vector3[] vertices; //pos
        int[] triangles; //verk    
        triangles = new int[66 * amount];
        vertices = new Vector3[14 * amount];
        GameObject lamps = new GameObject("Streetlamps");

        for (int i = 0; i < amount; i++) {
            vertices = addVert (vertices, pos[i, 0], pos[i, 1], vertCount);
            triangles = addTri (triangles, triCount, vertCount);
            GameObject lamp = createLamp (pos[i, 0], pos[i, 1], i);
            lamp.transform.parent = lamps.transform;
            vertCount += 14;
            triCount += 66;
        }

        meshCity.vertices = vertices;
        meshCity.triangles = triangles;

        meshCity.RecalculateNormals ();

        Renderer rend = gameObject.GetComponent<Renderer> ();
        rend.material.color = Color.grey;

    }

    void Update () { }
}