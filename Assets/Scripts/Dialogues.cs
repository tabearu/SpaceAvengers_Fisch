using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{

    GameObject txt;
    GameObject hintTxt;
    GameObject btn1;
    GameObject btn2;
    GameObject btn3;
    public bool dialogueIsDisplayed;

    string [] dialoge = new string[11] {
        "Der Brief beschäftigt mich immer noch, aber ich sollte wirklich erst arbeiten.",
        "Mist. Zu spät. Jetzt gibt es bestimmt wieder Stress mit dem Chef.",
        "Okay ich bin bei Alex… aber nach was genau soll ich jetzt suchen? Vielleicht gibt es irgendwo einen Hinweis.",
        "Hey, wie geht’s? Habt ihr Alex gesehen? Ich habe sie eine Weile nicht gesehen und mache mir Sorgen.",
        "Nein, seit letzter Woche nicht mehr, aber sie meinte sie hat wohl irgendeinen neuen Auftrag bekommen. Muss wohl interessant sein, so wie sie sich damit beschäftigt hat.",
        "Ich denke eher sie ist bei Ihrem neuen Freund.",
        "Sie hat einen neuen Freund",
        "Ich habe Sie letzte Woche mit einem Typen gesehen. Groß, schwarze Haare, Anzug, mit Sonnenbrille. Bisschen gruselig. Als ich sie darauf angesprochen habe meinte sie, sie hätte ihn auf der Arbeit kennengelernt. Ich glaube sein Name war NAME-AGENT. ",
        "Ein neuer Auftrag?",
        "Ja, muss wohl sehr wichtig sein, denn der Chef persönlich hat ihr den Auftrag gegeben. Allerdings fand ich es etwas seltsam. Sie sollte dafür jemanden treffen, in diesem neuen Café… ähm… CAFÉ-NAME, glaube ich?",
        "Alles klar. Danke"
    };

    void Start()
    {
        txt  = GameObject.Find("Main Camera/Canvas/Dialog");
        hintTxt  = GameObject.Find("Main Camera/Canvas/DialogueOption");
        btn1 = GameObject.Find("Main Camera/Canvas/Option1");
        btn2 = GameObject.Find("Main Camera/Canvas/Option2");
        btn3 = GameObject.Find("Main Camera/Canvas/Option3");
        var s = btn3.AddComponent<UI_Buttons>();
        s.dialogueNumber = -1;
        disappear();
        deleteHintText();
    }

    //aufrufen durch collider oder buttons
    // -1 = Dialogfeld schliessen
    public void setDialog(int i){
        if (i < dialoge.Length && i != -1){
            txt.GetComponent<UnityEngine.UI.Text>().text = dialoge[i];
            dialogueIsDisplayed = true;
            btn3.GetComponent<Button>().interactable = true;    
            btn3.SetActive(true);
            btn3.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Beenden";
        } else if (i == -1){
            disappear();
        } else {
            Debug.Log("Fehler");
        }
        
    }

    //loescht die funktion der buttons 1 und 2 und versteckt Textfeld und Buttons
    void disappear(){
        txt.GetComponent<UnityEngine.UI.Text>().text = "";
        dialogueIsDisplayed = false;
        btn1.GetComponent<Button>().interactable = false;
        btn2.GetComponent<Button>().interactable = false;
        btn3.GetComponent<Button>().interactable = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        btn1.gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
        btn2.gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
        btn3.gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
        if (btn1.GetComponent<UI_Buttons>()){
            Destroy(btn1.GetComponent<UI_Buttons>());
        }
        if (btn2.GetComponent<UI_Buttons>()){
            Destroy(btn2.GetComponent<UI_Buttons>());
        }
    }

    //setzt einen klickbaren Button mit entsprechender Dialogfunktion
    //wenn es keinen folgedialog gibt, dann followingDialogueNumber selbe Nummer wie dialogueNumber
    public void setButton(int dialogueNumber, int buttonNumber, int followingDialogueNumber){
        if (buttonNumber == 1 && dialogueNumber < dialoge.Length){
            btn1.gameObject.transform.GetChild(0).GetComponent<Text>().text = dialoge[dialogueNumber];
            btn1.SetActive(true);
            var sc = btn1.AddComponent<UI_Buttons>();
            sc.dialogueNumber = followingDialogueNumber;

        } else if (buttonNumber == 2 && dialogueNumber < dialoge.Length){
            btn2.gameObject.transform.GetChild(0).GetComponent<Text>().text = dialoge[dialogueNumber];
            btn2.SetActive(true);
            var sc = btn2.AddComponent<UI_Buttons>();
            sc.dialogueNumber = followingDialogueNumber;
        }
        
    }

    public void showHintText(){
        hintTxt.GetComponent<UnityEngine.UI.Text>().text = "Leertaste drücken";
    }

    public void deleteHintText(){
        hintTxt.GetComponent<UnityEngine.UI.Text>().text = "";
    }

}
