using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Triggers dialogue
//if you need a specific character trigger, write it in that character's script. aka write another script.

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dmanager;
    [Space(20)]
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        try { 
            dmanager.StartDialogue(dialogue);
            dmanager.StartAnim();
        }
        catch
        {
            Debug.Log("dmanager is Empty!");
        }
    }

    public void ConcatDialogue()
    {
        if(dmanager != null)
        { 
        dmanager.ConcatDialogue(dialogue);
        }
        else
            Debug.Log("dmanager is Empty!");
    }


}
