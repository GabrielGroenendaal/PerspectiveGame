using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is for controlling the overall game


public class GameController : MonoBehaviour
{
    
    /* Game States */
    public String gameState = "intro";
    public bool update;
    
    /* References */
    public GameObject player;
    private PlayerController playerControl;

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    public Teleport teleport1;
    public Teleport teleport2;
    public Teleport teleport3;

    public Audience audience;
    public Narrator narrator;
    public ScreenController screens;
    public Lighting lighting;

    /* Timers */
    public float timer;
    public float timer1;
   
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = player.GetComponent<PlayerController>();
        screens = Room1.transform.GetChild(3).GetComponent<ScreenController>();
        lighting = Room1.transform.GetChild(1).GetComponent<Lighting>();
        Room2.SetActive(false);
        Room3.SetActive(false);
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

    private void CheckGameState()
    {
        // Populates the arrays properly 
        if (gameState == "intro")
        {
            if (update == false)
            {
                update = true;
            }
        }
        
        // Begins the opening narrations
        if (gameState == "narrate")
        {
            if (update == false)
            {
                screens.setScreen(0);
                narrator.playNarrate(narrator.Narrate);
                audience.playClip(audience.Applause);
                update = true;
                playerControl.velocityModifier = 14;
            }
            
            // Moves on to the next game state when the clip ends
            if (narrator.Narrate.isPlaying == false)
            {
                update = false;
                gameState = "narrateToGame1";
            }
        }
        
        // 
        if (gameState == "narrateToGame1")
        {
            if (update == false)
            {
                screens.setScreen(1);
                narrator.playNarrate(narrator.NarrateToGame1);
                teleport1.Activate();
                update = false;
            }
        }
        
        if (gameState == "Game1")
        {
            if (update == false)
            {
                Room1.SetActive(false);
                Room2.SetActive(true);
                screens = Room2.transform.GetChild(3).GetComponent<ScreenController>();
                lighting = Room2.transform.GetChild(1).GetComponent<Lighting>();
                playerControl.setRoom1();
                update = true;
            }

            if (playerControl.victory)
            {
                gameState = "Game1toGame2";
            }
        }
        
        if (gameState == "Game1toGame2")
        {
            if (update == false)
            {
                teleport2.Activate();
                narrator.playNarrate(narrator.Game1toGame2);
                update = true;
            }

        }
        
        if (gameState == "Game2")
        {
            if (update == false)
            {
                Room3.SetActive(true);
                Room2.SetActive(false);
                screens = Room3.transform.GetChild(3).GetComponent<ScreenController>();
                lighting = Room3.transform.GetChild(1).GetComponent<Lighting>();
                screens.setScreen(0);
                playerControl.setRoom2();
                update = true;
            }
            
            if (playerControl.victory)
            {
                gameState = "Game2toConclusion";
            }
        }
        
        if (gameState == "Game2toConclusion")
        {
            if (update == false)
            {
                screens.setScreen(0);
                update = true;
            }

        }
        
        if (gameState == "Conclusion")
        {
            if (update == false)
            {
                screens.setScreen(0);
                update = true;
            }

        }
    }

    public void failure()
    {
        // Audience Boos
        // Screens say aweful
    }

    public void success()
    {
        // Audience Cheers
        // Screens say YAY
    }
    
    // This is the code that is called when the player reaches the main podium
    public void Reveal()
    {
        // Move all Screens to Layer 0
        // SetScreens to X
        // Start Audio
        // Flash Screen White then Fade in
    }
}
