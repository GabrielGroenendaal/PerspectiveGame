using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public UIElement[] items;
    public bool menuOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        GetUIElements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetUIElements()
    {
        items = transform.GetComponentsInChildren<UIElement>();
    }

    public void OpenMenu()
    {
        hideAll();
        items[0].display();
        menuOpen = true;
    }

    public void CloseMenu()
    {
        items[0].display();
        menuOpen = false;
    }
    
    public void FadeInUIElement(int index)
    {
        items[index].fadeIn();
    }
    
    public void FadeOutUIElement(int index)
    {
        items[index].fadeOut();
    }
    
    public void hideAll()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].fadeOut();
        }
    }
 }

