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

    private bool isActive;


    void Start()
    {
        transform.gameObject.layer = 13;
    }

    void FixedUpdate()
    {
        // This code raises the teleport pads upwards when activated

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player") && isActive)
        {
            teleportPlayer();
        }
    }

    private void teleportPlayer()
    {
        Player.transform.position = destination.transform.position + new Vector3(0, 10f, 0); // Sets the player position to a little bit above the destination
        teleportSound.Play();
        game.whitefading.WhiteFadeAnimation();
        game.UpdateTrue();
        game.gameState = sceneDestination;
    }

    public void Activate()
    {
        transform.gameObject.layer = 0;
        isActive = true;
    }
}
