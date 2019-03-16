using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public GameObject[] lightSources;
    
    void Start()
    {
        lightSources = new GameObject[transform.childCount];
        
        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i] = transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLight(int index)
    {
        lightSources[index].SetActive(true);
    }

    public void KillLights()
    {
        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i] = transform.GetChild(i).gameObject;
        }

    }
}
