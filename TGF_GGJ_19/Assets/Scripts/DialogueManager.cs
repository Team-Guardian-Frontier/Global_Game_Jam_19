using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dillon Z - TGF
//ALL REFERENCES NEED TO REFERENCE SCENE INSTANCES
//start dialogue will load next dialogue, and stuff.

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    [SerializeField]
    private Animator animator;
        //DON'T USE SINGLETON because of these object references. it's a pain. if you ever, make it a prefab, make it parent and child or some sorta relationship that's trackable.

    private Queue<string> sentences;

 
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        animator = this.GetComponentInChildren<Animator>();
    }

    

    //animation
    public void StartAnim()
    {
        animator.SetBool("IsOpen", true);
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        sentences = null;
    }

    //GET (DOESN'T WORK)
    public bool IsPlaying()
    {
        bool result = false;
        //if sentences has stuff, true, else false.
        if (sentences != null)
            result = true;
        return result;
    }

    public void StartDialogue(Dialogue dialogue)
    {


        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void ConcatDialogue(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    //returns if there is no more sentences (if, true, load next)
    public void DisplayNextSentence()
    {

        if (sentences == null)
            EndDialogue();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //coroutine lets you run a function along unity that can start, stop and pause at any moment.

        StopCoroutine("TypeSentence");
        StartCoroutine(TypeSentence(sentence));

        
    }

    //can have discrete display next that loads next sentence without animation if need be. idk.
    //might not even need animations. can have those be separate calls.

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

 
    
    
}
