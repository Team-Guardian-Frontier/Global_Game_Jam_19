using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ATTACH DIALOGUEMANAGER
public class MultipleDialogueTrigger : MonoBehaviour
{
    public DialogueManager dmanager;

    [Space(20)]
    public DialogueChain[] dialogues;
    //Each row is a DT/Dialogue chain. Going up or down changes chains.

    protected int Index;
    private int Chain;
    

    //can trigger any old chain this way
        //index is a row
    public void TriggerDialogue(int index)
    {
        try
        {
            dmanager.StartDialogue(dialogues[index]);
            dmanager.StartAnim();
        }
        catch
        {
            Debug.Log("dmanager is Empty!");
        }

    }
    //array contains multiple rows to insert.
    public void TriggerDialogue(int[] indices)
    {

        try {
            dmanager.StartDialogue(dialogues[indices[0]]);

            for (int now = 1 ; now < indices.Length; now++)
            {
                dmanager.ConcatDialogue(dialogues[now]);
            }

            dmanager.StartAnim();
        }
        catch
        {
            Debug.Log("dmanager is Empty!");
        }
    }

    public void ConcatDialogue(int index)
    {
        try { 
            dmanager.ConcatDialogue(dialogues[index]);
        }
        catch
        {
            Debug.Log("dmanager is Empty!");
        }
    }

    public void ConcatDialogue(int[] indices)
    {
        try { 
            foreach (int now in indices)
            {
                dmanager.ConcatDialogue(dialogues[indices[now]]);
            }
        }
        catch
        {
            Debug.Log("dmanager is Empty!");
        }

    }

  
    
    
}
