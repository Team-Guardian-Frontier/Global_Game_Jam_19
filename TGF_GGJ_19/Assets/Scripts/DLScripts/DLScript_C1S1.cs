using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLScript_C1S1 : DLScript
{

    void Start()
    {
        StartCoroutine(LateStart(2));
    }

    void Update()
    {
    }


    //COROUTINES
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        myDialogue.TriggerDialogue(0);

        /*
        int[] indices = { 0, 1, 3 };
        myDialogue.TriggerDialogue(indices);
        */
    }
    }
