using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sibling1 : InteractTrigger
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inside && !triggered)
        {
            mydialogue.TriggerDialogue();
            Debug.Log("you gotem");
            triggered = true;
            Destroy(this.gameObject);
        }
    }
}
