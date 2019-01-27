using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public DialogueTrigger mydialogue;
    private bool triggered = false;


    //Trigger collision detection for player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            mydialogue.TriggerDialogue();
            triggered = true;
        }
    }
}
