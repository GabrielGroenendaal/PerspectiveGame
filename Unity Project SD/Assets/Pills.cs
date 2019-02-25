using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    public Boolean isActive;
    public Material currentMaterial;
    public Material regularColor;
    public Material newColor;
    
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        currentMaterial = regularColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f,0f,2f);
    }

    public void reset()
    {
        Material save = currentMaterial;
        currentMaterial = regularColor;
        newColor = save;
        isActive = true;
    }

    public void deactivate()
    {
        isActive = false;
        
    }
}
