using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLScript_Sample : MonoBehaviour
{
    // copy trigger zone, load etc.
    public MultipleDialogueTrigger mydialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Trigger collision detection for player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player"))
        {
            int[] indices = { 0, 1, 2 };
            mydialogue.TriggerDialogue(indices);
        }
    }
   
}
