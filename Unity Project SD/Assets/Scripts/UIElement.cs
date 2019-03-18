using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public bool isActive;
    public bool fading;
    public bool fadingIn;
    public Image image;
    public float alpha;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        hide();
        alpha = image.color.a;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fading)
        {
            alpha -= 0.005f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            
            if (alpha <= 0.0f)
            {
                fading = false;
                hide();
                alpha = 1;
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            }
        }

        if (fadingIn)
        {
            alpha += 0.005f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            
            if (alpha >= 1.0f)
            {
                fadingIn = false;
            }
        }
    }

    public void display()
    {
        image.enabled = true;
        isActive = true;
    }

    public void hide()
    {
        image.enabled = false;
        isActive = false;
    }

    public void fadeOut()
    {
        fading = true;
    }

    public void fadeIn()
    {
        fadingIn = true;
        alpha = 0;
        display();
    }
}
