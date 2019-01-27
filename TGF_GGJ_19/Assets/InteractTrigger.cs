using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UPDATE KEYCODE TO WHAT YOU WANT.
public class InteractTrigger : MonoBehaviour
{
    public DialogueTrigger mydialogue;
    private bool inside = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inside)
        {
            mydialogue.TriggerDialogue();
            Debug.Log("you hit it");
        }
    }

    //Trigger collision detection for player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dat boy");
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dat boy");
            inside = false;
        }
    }
}
