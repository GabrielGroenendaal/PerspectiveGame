using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just a simple script for rotating and spinning the cameras

public class Spin : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 1f, 1f);
        
    }
}
