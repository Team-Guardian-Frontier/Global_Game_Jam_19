using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
    public DialogueTrigger mydialogue;

    private void OnMouseDown()
    {
        mydialogue.TriggerDialogue();
    }
}
