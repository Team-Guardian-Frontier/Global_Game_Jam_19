﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UPDATE KEYCODE TO WHAT YOU WANT.
public class InteractTrigger : MonoBehaviour
{
    public DialogueTrigger mydialogue;
    protected bool inside = false;
    protected bool triggered = false;
    //only script I can really get a trigggered deal on. unless, single use.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inside && !triggered)
        {
            mydialogue.TriggerDialogue();
            Debug.Log("you hit it");
                triggered = true;
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
            triggered = false;
        }
    }
}
