using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    Text timeText;
    public float starttime = 25000f;
    float timenow;
    public bool clockIsRunning = false;
    private float remainingtime;

    void Start()
    {
        timeText = GetComponent<Text>();
        clockIsRunning = true;
        timenow = starttime;
        remainingtime = 25200f - starttime;
    }

    void Update()
    {
        if (clockIsRunning)
        {
            timenow += Time.deltaTime;
            remainingtime -= Time.deltaTime;
            DisplayTime(timenow);
        }
    }

    public float getTime()
    {
        return timenow;
    }
    public float getRemainingTime()
    {
        return remainingtime;
    }


    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);
        float seconds = Mathf.FloorToInt((timeToDisplay % 3600) % 60);
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); ;
    }
}
