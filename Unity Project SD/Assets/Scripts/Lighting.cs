using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public GameObject[] lightSources;

    void Start()
    {
       GetLights();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateLight(int index)
    {
        lightSources[index].GetComponent<Light>().enabled = true;
    }

    public void KillLights()
    {
        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i] = transform.GetChild(i).gameObject;
        }

    }

    public void ActivateAllLights()
    {
        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i].GetComponent<Light>().enabled = true;

        }
    }

    
    public void GetLights()
    {
        lightSources = new GameObject[transform.childCount];

        for (int i = 0; i < lightSources.Length; i++)
        {
            lightSources[i] = transform.GetChild(i).gameObject;
            lightSources[i].GetComponent<Light>().enabled = false;
        }

    }

}
