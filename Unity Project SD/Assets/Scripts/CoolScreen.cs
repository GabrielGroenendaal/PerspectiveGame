using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// This code displays images on a screen, and in certain instances could be used to display multiple images in time with audio!

public class CoolScreen : MonoBehaviour
{

    public GameObject[] images;
    
    void Start()
    {
        images = new GameObject[transform.childCount];
        
        for (int i = 0; i < images.Length; i++)
        {
            images[i] = transform.GetChild(i).gameObject;
        }
       
    }

    void Update()
    {
        
    }

    public void setScreen(int index)
    {
        gameObject.layer = 0;
        HideAll();
        images[index].layer = 0;
    }


    private void HideAll()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].layer = 13;
        }
    }
}

