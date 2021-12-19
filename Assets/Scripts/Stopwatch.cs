using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private bool electricalStopWatchActive = false;
    private bool bookshelfStopWatchActive = false;
    private bool puzzleStopWatchActive = false;
    private bool drawerStopWatchActive = false;
    private bool paintingStopWatchActive = false;

    private float electricalCurrentTimeElapsed = 0;
    private float bookshelfCurrentTimeElapsed = 0;
    private float puzzleCurrentTimeElapsed = 0;
    private float drawerCurrentTimeElapsed = 0;
    private float paintingCurrentTimeElapsed = 0;

    public static Stopwatch instance;

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        CheckActiveStopwatches();
    }

    private void CheckActiveStopwatches()
    {
        if (electricalStopWatchActive)
        {
            electricalCurrentTimeElapsed += Time.deltaTime;
        }
        if (bookshelfStopWatchActive)
        {
            bookshelfCurrentTimeElapsed += Time.deltaTime;
        }
        if (puzzleStopWatchActive)
        {
            puzzleCurrentTimeElapsed += Time.deltaTime;
        }
        if (drawerStopWatchActive)
        {
            drawerCurrentTimeElapsed += Time.deltaTime;
        }
        if (paintingStopWatchActive)
        {
            paintingCurrentTimeElapsed += Time.deltaTime;
        }
    }

    public void StartStopwatch(string stopwatch) 
    {
        if(stopwatch == "electrical") 
        {
            electricalStopWatchActive = true;
        }
        else if(stopwatch == "bookshelf") 
        {
            bookshelfStopWatchActive = true;
        }
        else if(stopwatch == "puzzle") 
        {
            puzzleStopWatchActive = true;
        }
        else if(stopwatch == "drawer") 
        {
            drawerStopWatchActive = true;
        }
        else if(stopwatch == "painting") 
        {
            paintingStopWatchActive = true;
        }
    }

    public void StopStopwatch(string stopwatch) 
    {
        if (stopwatch == "electrical")
        {
            electricalStopWatchActive = false;
            Debug.Log(electricalCurrentTimeElapsed);
        }
        else if (stopwatch == "bookshelf")
        {
            bookshelfStopWatchActive = false;
            Debug.Log(bookshelfCurrentTimeElapsed);
        }
        else if (stopwatch == "puzzle")
        {
            puzzleStopWatchActive = false;
            Debug.Log(puzzleCurrentTimeElapsed);
        }
        else if (stopwatch == "drawer")
        {
            drawerStopWatchActive = false;
            Debug.Log(drawerCurrentTimeElapsed);
        }
        else if (stopwatch == "painting")
        {
            paintingStopWatchActive = false;
            Debug.Log(paintingCurrentTimeElapsed);
        }
    }
}
