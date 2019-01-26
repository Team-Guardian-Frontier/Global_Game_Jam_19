using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public DialogueTrigger mydialogue;

    // Update is called once per frame
    void Start()
    {
        mydialogue = this.GetComponent<DialogueTrigger>();
    }

    //Trigger collision detection for player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player"))
        {
            mydialogue.TriggerDialogue();
        }
    }
}
