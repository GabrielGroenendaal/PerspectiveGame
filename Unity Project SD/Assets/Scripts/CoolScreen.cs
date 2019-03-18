using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

// This code displays images on a screen, and in certain instances could be used to display multiple images in time with audio!

public class CoolScreen : MonoBehaviour
{

    public GameObject[] images;
    
    void Start()
    {
        Getimages();
       
    }

    void Update()
    {
        
    }

    public void setScreen(int index)
    {
        gameObject.layer = 9;
        HideAll();
        images[index].layer = 9;
    }


    private void HideAll()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].layer = 13;
        }
    }

    public void Getimages()
    {
        images = new GameObject[transform.childCount];
        
        for (int i = 0; i < images.Length; i++)
        {
            images[i] = transform.GetChild(i).gameObject;
        }
    }
}

