using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDialogue : MonoBehaviour
{

    public DialogueManager dialogueManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            dialogueManager.DisplayNextSentence();
    }
}
