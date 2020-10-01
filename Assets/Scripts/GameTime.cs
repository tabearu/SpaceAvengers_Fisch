using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{

    GameObject go;
    GameObject txt;

    void Start()
    {
        go  = GameObject.Find("LightByTime");
        txt  = GameObject.Find("Canvas/TimeString");
    }

    void Update()
    {
        string time  = go.GetComponent<LightByTime>().getTime();
        txt.GetComponent<UnityEngine.UI.Text>().text = time;
    }
}
