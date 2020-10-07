using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Canvas canvas;
    public Dropdown dropdown;
    void start(){
        canvas.GetComponent<Canvas>();
    }

    public void HandleInputData(int val){
        switch (val){
            case 0:
                break;
            case 1:
                switchScene("dorfScene");
                break;
            case 2:
                switchScene("City");
                break;
            case 3:
                switchScene("kanalisationScene");
                break;
            case 4:
                switchScene("PlayerHome");
                break;
            case 5:
                switchScene("AlexHome");
                break;
            case 6:
                switchScene("Woods");
                break;
            case 7:
                canvas.enabled = false;
                dropdown.value = 0;
                break;
            default:
                switchScene("dorfScene");
                break;
        }
    }

    public void switchScene(string name){
        GameObject.Find("Start_Skript").GetComponent<savedData>().saveGameTime();
        SceneManager.LoadScene(name);
        if (name == "PlayerHome"){
            Destroy(GameObject.Find ("Video"));
            Destroy(GameObject.Find ("Main Camera/Canvas/RawImage"));
        }
        GameObject.Find("Start_Skript").GetComponent<savedData>().setGameTime();
        
    }
}
