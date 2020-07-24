using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public float FadeDuration = 2f;
    bool fadeaway;
    bool fadein;
    Text text;
    float t0;
    
    void Start()
    {
        t0 = Time.time;
        fadein = false;
        fadeaway = false;
        text = GetComponent<Text>();
    }

    void Update()
    {
        float time = Time.time - t0;
        if (fadeaway)
        {
            if (time > FadeDuration)
            {
               text.gameObject.SetActive(false);
            } else
            {
                Color myColor = text.color;
                float ratio = time/FadeDuration;
                myColor.a = Mathf.Lerp(1, 0, ratio);
                text.color = myColor;
            }
        }

        if (fadein)
        {
            if (time < FadeDuration)
            {
                text.gameObject.SetActive(true);
                Color myColor = text.color;
                float ratio = time / FadeDuration;
                myColor.a = Mathf.Lerp(0, 1, ratio);
                text.color = myColor;
            } else
            {
                fadein = false;
            }
            
        }
    }
    public void FadeAwayText() { t0 = Time.time; fadeaway = true; }

    public void FadeInText() { t0 = Time.time; fadein = true; }
}
