using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class WhiteFade : MonoBehaviour
{
    // Start is called before the first frame update

    public Image whiteScreen;
    public float alpha;
    public bool WhiteFading;
    public AudioSource boom;

    void Start()
    {
        alpha = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (WhiteFading)
        {
            alpha -= 0.005f;
            whiteScreen.color = new Color(whiteScreen.color.r, whiteScreen.color.g, whiteScreen.color.b, alpha);
                 }
        
        if (alpha <= 0.0f)
        {
            WhiteFading = false;
        }
    }

    public void WhiteFadeAnimation()
    {
        alpha = 1.0f;
        whiteScreen.color = new Color(whiteScreen.color.r, whiteScreen.color.g, whiteScreen.color.b, alpha);
        WhiteFading = true;
        print("WhiteFadeAnimation");
        boom.Play();
    }

}
