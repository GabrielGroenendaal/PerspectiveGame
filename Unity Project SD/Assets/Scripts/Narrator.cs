using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for managing the Narrator's audio, of which there will be a lot. Here we go

public class Narrator : MonoBehaviour
{
    /* Audio Clips */
    public AudioSource Narrate; // Narration
    public AudioSource NarrateToGame1; // Narrate to Game1
    public AudioSource Game1; // Reaction 1
    public AudioSource Game2; // Reaction 2
    public AudioSource Game3; // Reaction 3
    public AudioSource Game4; // Reaction 4
    public AudioSource Game5; // Reaction 5
    public AudioSource Game1toGame2; // Game1 to Game2
    public AudioSource Conclusion; // Conclusion
    
    /* References */
    public GameController game;
    public GameObject[] screens;
    
    void Start()
    {
   
    }

    void Update()
    {
        
    }

    public void playNarrate(AudioSource clip)
    {
        endAllClips();
        clip.Play();
    }

    public void endAllClips()
    {
        Narrate.Stop();
        NarrateToGame1.Stop();
        Game1.Stop();
        Game2.Stop();
        Game3.Stop();
        Game4.Stop();
        Game5.Stop();
        Game1toGame2.Stop();
        Conclusion.Stop();
    }
}
