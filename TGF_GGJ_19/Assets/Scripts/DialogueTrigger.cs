using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Triggers dialogue

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    private bool triggered = false;


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

    //Trigger collision detection for player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

}
