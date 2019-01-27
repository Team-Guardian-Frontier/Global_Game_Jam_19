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

    private void Update()
    {
        Debug.Log(mydialogue.dmanager.IsEmpty());
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        
        int[] indices = { 0, 1 };
        mydialogue.TriggerDialogue(indices);

        //works, cuz waited to concat? Idk. dunno if it works
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
