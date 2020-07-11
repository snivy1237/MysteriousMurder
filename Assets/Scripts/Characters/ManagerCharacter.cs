using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacter : Interactable
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<string> CheckInteractConditions() {
        List<string> conversation = new List<string>();

        

        return conversation;
    }

    public override void OnInteract(GameObject objPlayer) {
        
        Dialogue.LoadDialogue(CheckInteractConditions());
    }
}
