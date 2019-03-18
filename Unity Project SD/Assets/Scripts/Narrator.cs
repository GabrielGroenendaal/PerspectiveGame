using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for managing the Narrator's audio, of which there will be a lot. Here we go

public class Narrator : MonoBehaviour
{
    /* Audio Clips */
    /*
     * 0: Narration
     * 1: Narration to Game 1
     * 2: Oh God
     * 3: That's embarassing
     * 4: Your parents are watching
     * 5: Big Yikes
     * 6: Are you sure about that?
     * 7: You did it!
     * 8: Failure
     * 9: Game1 to Game2
     * 10: Conclusion
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

    public void endAllClips()
    {
        
        for (int i = 0; i < soundClips.Length; i++)
        {
            if (soundClips[i].isPlaying)
            {
                StartCoroutine(FadeOut(soundClips[i], 1.2f));
            }
        }
        
        /*Narrate.Stop();
        NarrateToGame1.Stop();
        Game1.Stop();
        Game2.Stop();
        Game3.Stop();
        Game4.Stop();
        Game5.Stop();
        Game1toGame2.Stop();
        Conclusion.Stop();*/
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
        playClip(Random.Range(2,7));
    }
}
