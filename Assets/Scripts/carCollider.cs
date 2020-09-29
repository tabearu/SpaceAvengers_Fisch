using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCollider : MonoBehaviour
{
    
    void OnCollisionEnter(Collision col){
        Debug.Log("Crash: " + col.gameObject.name);
        
    }

    void OnCollisionExit(Collision col)
    {
        print("No longer in contact with " + col.gameObject.name);
        gameObject.GetComponent<carSpeed>().speed = 0.25f;
    }

    void OnTriggerEnter(Collider col){
        if ((col.gameObject.name == "auto")){ 
            col.gameObject.GetComponent<carSpeed>().speed = 0;
            col.gameObject.GetComponent<carSpeed>().standing = true;

            StartCoroutine(waiter());       
        } else if(col.gameObject.name == "Main Camera"){
            gameObject.GetComponent<carSpeed>().speed = 0;
        }
    }

    void OnTriggerExit(Collider col)
    {
        //print("Trigger no longer in contact with " + col.gameObject.name);
        if ((col.gameObject.name == "auto")){   
            col.gameObject.GetComponent<carSpeed>().speed = 0.25f;
            col.gameObject.GetComponent<carSpeed>().standing = false;
        } else if(col.gameObject.name == "Main Camera"){
            gameObject.GetComponent<carSpeed>().speed = 0.25f;
        }
    }

    IEnumerator waiter(){ 
        yield return new WaitForSeconds(2);

        gameObject.GetComponent<carSpeed>().speed = 0.25f;
        gameObject.GetComponent<carSpeed>().standing = false;
    }
}
