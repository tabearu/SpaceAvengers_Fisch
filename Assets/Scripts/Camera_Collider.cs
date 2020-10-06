using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Collider : MonoBehaviour
{
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.name == "bett" && Input.GetKey(KeyCode.Q)) {
            Debug.Log("Schlafen?");

        }
    }
}
