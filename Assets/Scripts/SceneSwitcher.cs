using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
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
            default:
                switchScene("dorfScene");
                break;
        }
    }

    public void switchScene(string name){
        SceneManager.LoadScene(name);
    }
}
