using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    /* Clips */
    /*
     * 0: Ambient
     * 1: Gasp
     * 2; Booo
     * 3: Clapping
     * 4: Hooray
     * 5: Oooh
     * 6: Amuse
     * 7: Laugh
     * 8: Murmur
     */ 

    public AudioSource[] soundClips;
    
    /* References */
    public GameController game;
   
    void Start()
    {
        soundClips = transform.GetComponentsInChildren<AudioSource>();
        endAllClips();
        
    }

    void Update()
    {
        
    }

    public void playClip(int index)
    {
        endAllClips();
        soundClips[index].Play();
    }
    
    public void playNoInterruptClip(int index)
    {
        soundClips[index].Play();
    }
    
    public void endAllClips()
    {

        for (int i = 0; i < soundClips.Length; i++)
        {
            if (soundClips[i].isPlaying)
            {
                StartCoroutine(FadeOut(soundClips[i], 1.0f));
            }
        }
    }

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
    
        
    public void RandomReaction()
    {
        playNoInterruptClip(Random.Range(2,7));
    }

    public bool checkIfPlay()
    {
        for (int i = 0; i < soundClips.Length; i++)
        {
            if (soundClips[i].isPlaying)
            {
                return true;
            }
        }

        return false;
    }
}
