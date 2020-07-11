using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialogue : MonoBehaviour
{
    static Dialogue singleton;

    public TMP_Text curDialogueText;
    public List<string> dialogues;

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        NextDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            if(dialogues.Count > 0) {
                NextDialogue();
             } else { 
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public static void LoadDialogue(List<string> newDialogues) {
        singleton.dialogues = newDialogues;
        singleton.canvas.gameObject.SetActive(true);
    }

    public static Dialogue getDialogueBox() {
        return singleton;
    }

    void NextDialogue() {
        singleton.canvas.gameObject.SetActive(true);
        curDialogueText.text = dialogues[0];
        dialogues.RemoveAt(0);
    }
}
