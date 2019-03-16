using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    // Contains all the screens, and also references the monitor
    public CoolScreen[] screenimages;
    
    // Populated the Screens Array
    void Start()
    {
        screenimages = new CoolScreen[transform.childCount];
        
        for (int i = 0; i < screenimages.Length; i++)
        {
            screenimages[i] = transform.GetChild(i).GetComponent<CoolScreen>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void revealScreens()
    {
        for (int i = 0; i < screenimages.Length; i++)
        {
            screenimages[i].setScreen(0);
        }
    }
    
    public void setScreen(int index)
    {   
        for (int i = 0; i < screenimages.Length; i++)
        {
            screenimages[i].setScreen(index);
        }
    }

}
