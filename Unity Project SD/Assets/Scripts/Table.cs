using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private bool bulletDrop;
    public GameController game;

    public GameObject[] colliders;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletDrop = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (bulletDrop == false)
        {

            bulletDrop = true;
            game.update = false;
            game.gameState = "narrate";
        }
    }

}
