using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Canvas canvas;
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
                canvas.gameObject.SetActive(false);
                break;
            default:
                switchScene("dorfScene");
                break;
        }
    }

    public void switchScene(string name){
        SceneManager.LoadScene(name);
    }
}
