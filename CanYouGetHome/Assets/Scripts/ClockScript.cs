using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    Text timeText;
    public float starttime = 10;
    float timenow;
    public bool clockIsRunning = false;

    void Start()
    {
        timeText = GetComponent<Text>();
        clockIsRunning = true;
        timenow = starttime;
    }

    void Update()
    {
        if (clockIsRunning)
        {
            timenow += Time.deltaTime;
            DisplayTime(timenow);
        }
    }

    public float getTime()
    {
        return timenow;
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);
        float seconds = Mathf.FloorToInt((timeToDisplay % 3600) % 60);

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
