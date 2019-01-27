using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLFlash : MonoBehaviour
{
    public DialogueTrigger mydialogue;
    // Start is called before the first frame update
    void Start()
    {
        mydialogue.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
