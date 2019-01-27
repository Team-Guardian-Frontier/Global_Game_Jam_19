using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sibling2 : InteractTrigger
{
    public GameObject Player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inside && !triggered)
        {
            mydialogue.TriggerDialogue();
            Debug.Log("you gotem");
            triggered = true;
            StartCoroutine("Cliffjumping");
        }
    }

    IEnumerator Cliffjumping()
    {
        while (!mydialogue.dmanager.IsEmpty())
        {
            yield return null;
        }
        Destroy(Player);
        Destroy(this.gameObject);

        //Transition to next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
