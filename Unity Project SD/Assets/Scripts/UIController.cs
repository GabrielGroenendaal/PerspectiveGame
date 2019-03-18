using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject[] items;
    public bool menuOpen;

    
    // Start is called before the first frame update
    void Start()
    {
        hideAll();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
    }
    

    public void OpenMenu()
    {
        print("OpenMenu Works1");
        hideAll();
        items[0].GetComponent<CanvasGroup>().alpha = 1f;
        menuOpen = true;
        print("OpenMenu Works 2");
    }

    public void CloseMenu()
    {
        items[0].GetComponent<CanvasGroup>().alpha = 0.5f;
        menuOpen = false;
    }
    
    public void display(int index)
    {
        print("display is called");
        items[index].GetComponent<CanvasGroup>().alpha = 1f;
        print("display is performed");
    }
    
    public void hide(int index)
    {
        items[index].GetComponent<CanvasGroup>().alpha = 0.5f;
    }
    
    public void hideAll()
    {
        for (int i = 0; i < 4; i++)
        {
            items[i].GetComponent<CanvasGroup>().alpha = 0.5f;
        }
    }
 }

