using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    /* State Tracking */
    public Boolean isActive;
    
    /* References */
    public GameObject parent;
    
    void Start()
    {
        isActive = true;
    }

    void FixedUpdate()
    {
        transform.Rotate(0f,0f,2f);
    }

    public void reset()
    {
        isActive = true;
        parent.layer = 0;
    }

    public void deactivate()
    {
        isActive = false;
        parent.layer = 13;
    }
}
