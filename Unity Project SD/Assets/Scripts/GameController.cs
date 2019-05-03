﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Math;

// This code is for controlling the overall game


public class GameController : MonoBehaviour
{
    
    /* Game States */
    public String gameState = "intro";
    private bool update;
    private bool Slideshow;
    
    /* References */
    public GameObject player;
    private PlayerController playerControl;
    // public UIController UIControl;

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;
    public GameObject Room4;
    public GameObject Room5;
    public GameObject Room6;
    public GameObject Room7;

    public Teleport teleport1;
    public Teleport teleport2;
    public Teleport teleport3;
    public Teleport teleport4;
    public Teleport teleport5;
    public Teleport teleport6;

    private Audience audience;
    private Narrator narrator;
    private ScreenController screens;
    public Lighting lighting;
    public WhiteFade whitefading;

    /* Timers */
    private float timer;
    private float timer1;
    private float timer2;
   

    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = player.GetComponent<PlayerController>();
        screens = Room1.transform.GetChild(3).GetComponent<ScreenController>();
        lighting = Room1.transform.GetChild(1).GetComponent<Lighting>();
        audience = transform.GetChild(0).GetComponent<Audience>();
        narrator = transform.GetChild(1).GetComponent<Narrator>();
        lighting.ActivateLight(3); 
        lighting.ActivateLight(4);
        audience.playClip(9);
        Room2.SetActive(false);
        Room3.SetActive(false);
        Room4.SetActive(false);
        Room5.SetActive(false);
        Room6.SetActive(false);
        Room7.SetActive(false);
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

        if (Slideshow)
        {
            if (timer2 > 0)
            {
                timer2 -= Time.deltaTime;
            }
            else
            {
                timer2 = 5.0f;
                screens.RandomScreen();
            }
        }
        
        if (Input.GetKey(KeyCode.CapsLock))
        {
            playerControl.UpdateAnalytics();
            Application.Quit();
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
                whitefading.WhiteFadeAnimation();
                narrator.playClip(0);
                audience.playClip(1);
                lighting.ActivateLight(1);
                lighting.ActivateLight(2);
                update = true;
                Slideshow = true;
            }

            if (audience.checkIfPlay() == false)
            {
                audience.playClip(9);
                print("test audio");
            }

        // Moves on to the next game state when the clip ends
            if (narrator.soundClips[0].isPlaying == false || Input.GetKey(KeyCode.Backspace))
            {
                update = false;
                gameState = "narrateToGame1";
                lighting.ActivateLight(5);
                Slideshow = false;
                screens.setScreen(7);
                print("Test 1");
            }
        }
        
        if (gameState == "narrateToGame1")
        {
            if (update == false)
            {
                screens.setScreen(1);
                narrator.playClip(1);
                teleport1.Activate();
                update = true;
                playerControl.velocityModifier = 10;
            }
        }
        
        if (gameState == "Game1")
        {
            if (update == false)
            {
                Room1.SetActive(false);
                Room2.SetActive(true);
                screens = Room2.transform.GetChild(2).GetComponent<ScreenController>();
                screens.GetScreens();
                screens.setScreen(2);
                lighting = Room2.transform.GetChild(3).GetComponent<Lighting>();
                lighting.GetLights();
                lighting.ActivateAllLights();
                playerControl.setRoom1();
                update = true;
                Slideshow = true;
                narrator.playClip(11);
                audience.playClip(9);
            }

            if (playerControl.victory)
            {
                gameState = "Game1toGame2";
                Slideshow = false;
                screens.setScreen(9);
                audience.playNoInterruptClip(4);
                narrator.playClip(12);
                update = false;
            }
        }
        
        if (gameState == "Game1toGame2")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                teleport2.Activate();
                update = true;
            }
        }
        
        if (gameState == "Game2")
        {
            if (update == false)
            {
                Debug.Log("This is Room 2");
                Room2.SetActive(false);
                Room3.SetActive(true);
                screens = Room3.transform.GetChild(2).GetComponent<ScreenController>();
                screens.GetScreens();
                screens.setScreen(2);
                lighting = Room3.transform.GetChild(3).GetComponent<Lighting>();
                lighting.GetLights();
                lighting.ActivateAllLights();
                playerControl.setRoom2();
                
                update = true;
                Slideshow = true;
            }
            
            if (playerControl.victory)
            {
                gameState = "Game2toGame3";
                Slideshow = false;
                screens.setScreen(9);
                audience.playNoInterruptClip(4);
                narrator.playClip(7);
                update = false;
            }
        }
        
        if (gameState == "Game2toGame3")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                screens.setScreen(0);
                update = true;
                teleport3.Activate();
            }
        }
        
                
        if (gameState == "Game3")
        {
            if (update == false)
            {
                Debug.Log("This is Room 3");
                Room3.SetActive(false);
                Room4.SetActive(true);
                
                screens = Room4.transform.GetChild(2).GetComponent<ScreenController>();
                screens.GetScreens();
                screens.setScreen(2);
                
                lighting = Room4.transform.GetChild(3).GetComponent<Lighting>();
                lighting.GetLights();
                lighting.ActivateAllLights();
                
                playerControl.setRoom3();
                
                update = true;
                Slideshow = true;
            }
            
            if (playerControl.victory)
            {
                gameState = "Game3toGame4";
                Slideshow = false;
                screens.setScreen(9);
                audience.playNoInterruptClip(4);
                narrator.playClip(9);
                update = false;
            }
        }
        
        if (gameState == "Game3toGame4")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                screens.setScreen(0);
                update = true;
                teleport4.Activate();
            }
        }
        
        if (gameState == "Game4")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                Room4.SetActive(false);
                Room5.SetActive(true);
                
                screens = Room5.transform.GetChild(2).GetComponent<ScreenController>();
                screens.GetScreens();
                screens.setScreen(2);
                
                lighting = Room5.transform.GetChild(3).GetComponent<Lighting>();
                lighting.GetLights();
                lighting.ActivateAllLights();
                
                playerControl.setRoom4();
                
                update = true;
                Slideshow = true;
            }
            
            if (playerControl.victory)
            {
                gameState = "Game4toGame5";
                Slideshow = false;
                screens.setScreen(9);
                audience.playNoInterruptClip(4);
                narrator.playClip(13);
                update = false;
            }
        }
        
        if (gameState == "Game4toGame5")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                screens.setScreen(0);
                update = true;
                teleport5.Activate();
            }
        }
        
        if (gameState == "Game5")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                Room5.SetActive(false);
                Room6.SetActive(true);
                
                screens = Room6.transform.GetChild(2).GetComponent<ScreenController>();
                screens.GetScreens();
                screens.setScreen(2);
                
                lighting = Room6.transform.GetChild(3).GetComponent<Lighting>();
                lighting.GetLights();
                lighting.ActivateAllLights();
                
                playerControl.setRoom5();
                
                update = true;
                Slideshow = true;
            }
            
            if (playerControl.victory)
            {
                gameState = "Game5toConclusion";
                Slideshow = false;
                screens.setScreen(9);
                audience.playNoInterruptClip(4);
                narrator.playClip(7);
                update = false;
            }
        }
        
        if (gameState == "Game5toConclusion")
        {
            if (update == false)
            {
                Debug.Log("This is " + gameState);
                screens.setScreen(0);
                update = true;
                teleport6.Activate();
            }
        }
        
        if (gameState == "Conclusion")
        {
            if (update == false)
            {
                Room4.SetActive(true);
                Room3.SetActive(false);
                screens = Room4.transform.GetChild(0).GetComponent<ScreenController>();
                lighting = Room4.transform.GetChild(1).GetComponent<Lighting>();
                screens.GetScreens();
                screens.setScreen(0);

                lighting.GetLights();
                lighting.ActivateAllLights();
                update = true;
                Slideshow = false;
                screens.setScreen(9);
                audience.playClip(9);
                narrator.playClip(10);
                
            }

            if (Input.GetKey(KeyCode.Backspace))
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }

        }
    }

    public void UpdateTrue()
    {
        update = false;
    }
}
