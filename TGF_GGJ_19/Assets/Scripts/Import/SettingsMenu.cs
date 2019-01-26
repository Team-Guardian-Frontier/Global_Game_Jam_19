using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 * @author Justin Carrasquillo
 * Last Change: Justin - created script
 * ScriptSummary:
 *      - Gives the volume slider in the options menu its respective feature
 * List of Fields:
 *      - audioMixer: allows us to attach an audio mixer to the script
 * Notes:     
 *   
 */


public class SettingsMenu : MonoBehaviour {

    //Allows for the addition of an audio mixer
    public AudioMixer audioMixer;

    //Allows the Master Volume to take in input
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}
