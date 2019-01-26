using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * @author Justin Carrasquillo
 * Last Change: Justin - created script
 * ScriptSummary:
 *      - Gives the buttons on the main menu their respective feature
 * List of Fields:
 *      -
 * Notes:     
 *      - Debug.Log statement is temporary in order to confirm the application completes the task during testing
 */


public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        //Loads first level once clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Quits appliication once clicked
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
