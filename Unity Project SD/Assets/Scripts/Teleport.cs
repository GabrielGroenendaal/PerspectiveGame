using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

// This code should handle the various teleporters 
public class Teleport : MonoBehaviour
{
    /* Locations */
    public GameObject destination; // Stores the teleporter's destination location
    public GameObject Player;
    public GameController game;
    public String sceneDestination;
    
    /* Audio Clips */
    public AudioSource teleportSound; // Bloop
    public AudioSource activationSound; // Bleep
    
    /* Timer */
    private float timer;

    void Start()
    {
        timer = 0.0f;
    }

    void FixedUpdate()
    {
        // This code raises the teleport pads upwards when activated
        if (timer > 0.0f)
        {
            transform.Translate(0.0f, .5f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            teleportPlayer();
        }
    }

    private void teleportPlayer()
    {
        Player.transform.position = destination.transform.position + new Vector3(0, 10f, 0); // Sets the player position to a little bit above the destination
        teleportSound.Play();
        game.update = false;
        game.gameState = sceneDestination;
    }

    public void Activate()
    {
        activationSound.Play();
        timer = 2.0f;
    }
}
