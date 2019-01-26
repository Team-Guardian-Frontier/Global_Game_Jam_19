using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Triggers dialogue

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
