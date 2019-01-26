using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dillon Z - TGF
//ALL REFERENCES NEED TO REFERENCE SCENE INSTANCES

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
        //DON'T USE SINGLETON because of these object references. it's a pain. if you ever, make it a prefab, make it parent and child or some sorta relationship that's trackable.

    private Queue<string> sentences;

 
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log((sentences == null) + " 5");

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log((sentences == null) + " 1");
        if (sentences == null)
            EndDialogue();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Debug.Log((sentences == null) + " 2");

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //coroutine lets you run a function along unity that can start, stop and pause at any moment.
        Debug.Log((sentences == null) + " 3");

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        Debug.Log((sentences == null) + " 4");
    }

    //I don't know what this does.
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        Debug.Log((sentences == null) + " 6");

        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
    
    
}
