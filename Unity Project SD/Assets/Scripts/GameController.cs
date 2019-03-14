using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is for controlling the overall game


public class GameController : MonoBehaviour
{
    
    /* Game States */
    private String gameState;
    
    /* References */
    public GameObject player;
    private PlayerController playerControl;

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject teleport3;

    public GameObject[] screens;

    /* Timers */
    public float timer;
    public float timer1;
    public float GameTimer;
   
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGameState();
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer1 > 0.0f)
        {
            timer1 -= Time.deltaTime;
        }
    }
    
    // Game States
        // Intro
            // Player has full movement, can climb the stairs
            // If they reach the center of the cylinder, enter Narration
        // Narration
            // Displays the audience stands and screens
            // Turns on the Lighting
            // Starts the music
                // Audience Applause
                // Bombastic Brass Intro 
            // Starts the audio Narration
            // Locks the player On Stage
            // Explains the Game
                // Times Audio in time with changed to the image on the main screen
        // Transition to Game
            // Podium Raises
            // Table on the Podium becomes a teleport node to send players to the Game Area
            // Audio 
        // Game
            // Hides the entire other room in a different layer
            // Plays the scary game music
            // Changes the Player's values according to the room
            // Audience Responses to different stimuli
        // Inbetween Game
            // More Audio
            // Another teleport
        // Game 2
            // See Above
        // Conclusion
            // See Above
    

    // Scripts
        // Game Controller
        // Player Controller
            // Controls player movement 
        // Announcer 
            // Controls the audio cues for the announcer, who has a fuckton of dialogue over the coarse of the game
        // Audience
            // Controls the audio cues for the audience, who will react randomly to player actions during the game
        // Teleporter
            // Teleports players between rooms

    private void CheckGameState()
    {
        if (gameState == "intro")
        {
            
        }
        
        if (gameState == "narrate")
        {
            // Narrator.activateAudio(1)
            // activate collider X
            // GameObject.transform.GetChild(3).layer = 0;
        }
        
        if (gameState == "narrateToGame1")
        {
            // teleportPad1.activate
            // Narrator.activateAudio(2)
        }
        
        if (gameState == "Game1")
        {
            // if gameFail then failure()
            // if gameSuccess then Success
        }
        
        if (gameState == "Game1toGame2")
        {
            
        }
        
        if (gameState == "Game2toConclusion")
        {
            
        }
        
        if (gameState == "Conclusion")
        {
            
        }
    }

    public void flash()
    {
        
    }

    public void failure()
    {
        
    }

    public void success()
    {
        
    }
}
