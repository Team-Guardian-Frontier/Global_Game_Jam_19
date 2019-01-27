using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLScript_Sample : MonoBehaviour
{
    // copy trigger zone, load etc.
    public MultipleDialogueTrigger mydialogue;

    void Start()
    {
        StartCoroutine(LateStart(2));

        
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        
        int[] indices = { 0, 1 };
        mydialogue.TriggerDialogue(indices);

        StartCoroutine("Memery");
    }

    IEnumerator Memery()
    {
        while (!mydialogue.dmanager.IsEmpty())
        {
            yield return null;
        }
        mydialogue.ConcatDialogue(2);
    }
 
   
}
