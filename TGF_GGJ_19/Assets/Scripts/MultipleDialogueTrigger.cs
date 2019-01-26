using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDialogueTrigger : DialogueTrigger
{
    public Dialogue[] dialogues;
    protected int dialInd;

    public void TriggerDialogue(int index)
    {
        if (triggered == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[index]);
            triggered = true;
        }
    }
}
