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

    private Queue<Dialogue> dialogues;

    //name change

 
    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<Dialogue>();
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
    }

    //GET 
    public bool IsEmpty()
    {
        bool result = false;
        //if sentences has stuff, true, else false.
        if (dialogues.Count == 0)
            result = true;
        return result;
    }
    //make it wait etc. coroutine, or just wait for seconds.

    public void StartDialogue(DialogueChain dialoggies)
    {

        dialogues.Clear();

        foreach (Dialogue dialog in dialoggies.chain)
        {
            dialogues.Enqueue(dialog);
        }

        DisplayNextSentence();
    }

    public void ConcatDialogue(DialogueChain dialogue)
    {
        foreach (Dialogue dialog in dialogue.chain)
        {
            dialogues.Enqueue(dialog);
        }
    }

    //returns if there is no more sentences (if, true, load next)
    public void DisplayNextSentence()
    {
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue current = dialogues.Dequeue();
        string sentence = current.sentence;

        nameText.text = current.name;

        dialogueText.text = sentence;
        //coroutine lets you run a function along unity that can start, stop and pause at any moment.

        //needed to stop everything overlaying.
        //ONLY STOPS BEHAVIOURS ON THIS MONO
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        
    }

    //can have discrete display next that loads next sentence without animation if need be. idk.
    //might not even need animations. can have those be separate calls.

        
    //Causes problems with puttin gin more text. cuz lays more in.
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    
 
    
    
}
