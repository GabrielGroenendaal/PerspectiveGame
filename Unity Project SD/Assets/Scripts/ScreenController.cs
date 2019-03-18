using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    // Contains all the screens, and also references the monitor
    public CoolScreen[] screenimages;
    
    /*
     * 0 "Welcome to the Show"
     * 1 "Your Anxiety"
     * 2 "You are a failure"
     * 3 "Everyone is Watching"
     * 4 "You failed"
     * 5 "Try Harder"
     * 6 "Don't be Garbage"
     * 7 "Eat the Pills"
     * 8 "You SUCK"
     * 9 "Good Job"
     */
    // Populated the Screens Array
    void Start()
    {
        GetScreens();
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

    public void GetScreens()
    {
        screenimages = new CoolScreen[transform.childCount];
        
        for (int i = 0; i < screenimages.Length; i++)
        {
            screenimages[i] = transform.GetChild(i).GetComponent<CoolScreen>();
            screenimages[i].Getimages();
        }
    }

    public void RandomScreen()
    {
        for (int i = 0; i < screenimages.Length; i++)
        {
            screenimages[i].setScreen(Random.Range(0,9));
        }
    }
}
