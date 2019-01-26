using UnityEngine.Audio;
using UnityEngine;

    [System.Serializable]
public class Sound {
    //A class that holds all the information for a sound.
    

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    //the audiosource that actually plays sounds in game.
    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public Sound(Sound og)
    {
        this.name = og.name;
        this.clip = og.clip;
        this.volume = og.volume;
        this.pitch = og.pitch;
        this.loop = og.loop;
        //new source tho
    }
}
