using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private bool stopWatchActive = false;

    private float currentTimeElapsed = 0;

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive) 
        {
            currentTimeElapsed += Time.deltaTime;
        }
    }

    public void StartStopwatch() 
    {
        stopWatchActive = true;
    }

    public float StopStopwatch() 
    {
        stopWatchActive = false;
        return currentTimeElapsed;
    }

    public void RestartStopwatch() 
    {
        stopWatchActive = false;
        currentTimeElapsed = 0;
    }
}
