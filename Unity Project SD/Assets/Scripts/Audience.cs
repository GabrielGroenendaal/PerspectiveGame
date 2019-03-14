using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    /* Clips */
    public AudioSource Applause; 
    public AudioSource Boo;
    public AudioSource Gasp; 
    public AudioSource Cheer; 
    public AudioSource Laugh; 
    public AudioSource Meh; 
    
    /* References */
    public GameController game;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playClip(AudioSource clip)
    {
        endAllClips();
        clip.Play();
    }
    
    public void endAllClips()
    {
        Applause.Stop();
        Boo.Stop();
        Gasp.Stop();
        Cheer.Stop();
        Laugh.Stop();
        Meh.Stop();
    }
}
