﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        myDialogue.TriggerAllDialogue();

        /*
        int[] indices = { 0, 1, 3 };
        myDialogue.TriggerDialogue(indices);
        */
        StartCoroutine("NextScene");
    }

    IEnumerator NextScene()
    {
        while (!myDialogue.dmanager.IsEmpty())
        {
            Debug.Log("Meme");
            yield return null;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
