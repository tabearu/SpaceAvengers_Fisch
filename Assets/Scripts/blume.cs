using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blume : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int maxDepth;
    public float childScale;
    private int currentDepth;
    
    private void Start()
    {
        maxDepth = Random.Range(4, 8);
        childScale = Random.Range(0.2f, 1f);
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (currentDepth < maxDepth){
            StartCoroutine(AddChild());
        }
    }

    private IEnumerator AddChild()
    {
        yield return new WaitForSeconds(0);
        new GameObject("Child Up").AddComponent<blume>().
            Initialize(this, Vector3.up, Quaternion.identity);
        new GameObject("Child Right").AddComponent<blume>().
            Initialize(this, Vector3.right, Quaternion.Euler(0f, 0f, -randomDegree()));
        new GameObject("Child Left").AddComponent<blume>().
            Initialize(this, Vector3.left, Quaternion.Euler(0f, 0f, randomDegree()));
    }

    private void Initialize(blume parent, Vector3 direction, Quaternion orientation)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        currentDepth = parent.currentDepth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = direction * (0.1f + 0.5f * childScale);
        transform.localRotation = orientation;
    }

    public float randomDegree(){
        return Random.Range(60, 100);
    }
}
