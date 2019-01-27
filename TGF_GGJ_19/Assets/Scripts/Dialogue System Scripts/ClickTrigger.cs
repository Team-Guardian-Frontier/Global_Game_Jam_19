using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
    public DialogueTrigger mydialogue;
    private bool triggered = false;

    private void OnMouseDown()
    {
        if (!triggered)
        {
            mydialogue.TriggerDialogue();
            triggered = true;
        }
    }
}
