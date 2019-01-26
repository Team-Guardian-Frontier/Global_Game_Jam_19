using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Triggers dialogue
//if you need a specific character trigger, write it in that character's script. aka write another script.

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    protected bool triggered = false;


    public void TriggerDialogue()
    {
        if (triggered == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            triggered = true;
        }
    }

    void ResetTrigger()
    {
        triggered = false;
    }



}
