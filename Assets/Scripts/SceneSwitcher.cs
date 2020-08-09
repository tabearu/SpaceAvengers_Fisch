using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void HandleInputData(int val){
        switch (val){
            case 0:
                switchScene("dorfScene");
                break;
            case 1:
                switchScene("City");
                break;
            case 2:
                switchScene("kanalisationScene");
                break;
            case 3:
                switchScene("PlayerHome");
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
