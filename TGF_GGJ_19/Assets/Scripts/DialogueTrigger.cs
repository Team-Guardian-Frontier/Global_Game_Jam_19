using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Triggers dialogue
//if you need a specific character trigger, write it in that character's script. aka write another script.

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dmanager;
    //dialogue chain
    [Space(20)]
    public DialogueChain dialogue;

    public void TriggerDialogue()
    {

            dmanager.StartDialogue(dialogue);
            dmanager.StartAnim();
    }

    public void ConcatDialogue()
    {
        dmanager.ConcatDialogue(dialogue);
        
    }


}
