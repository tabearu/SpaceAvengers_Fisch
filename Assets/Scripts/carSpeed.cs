using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpeed : MonoBehaviour
{

    public float speed;
    public bool standing;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.25f;
        standing = false;
    }

}
