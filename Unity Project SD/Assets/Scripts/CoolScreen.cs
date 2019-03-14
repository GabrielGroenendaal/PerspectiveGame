using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code displays images on a screen, and in certain instances could be used to display multiple images in time with audio!

public class CoolScreen : MonoBehaviour
{

    public GameObject[] images;
    public Boolean zooming;
    
    void Start()
    {
        images = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++)
        {
            images[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        
    }

    public void setScreen(int index)
    {
        HideAll();
        images[index].SetActive(true);
    }

    public void setZoom(bool boolean)
    {
  
    }

    public void setSuccess()
    {
        HideAll();
        images[2].SetActive(true);
    }

    public void setFailure()
    {
        HideAll();
        images[1].SetActive(true);
    }

    public void SetIntro()
    {
        HideAll();
        images[0].SetActive(true);
    }

    private void HideAll()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
    }
}

