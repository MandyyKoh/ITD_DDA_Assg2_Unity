using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseBottom : MonoBehaviour
{
    public GameObject iFalseBottom;
    public GameObject falseBottom;
    public GameObject chalk;
    public GameObject key;
    public GameObject lockedDrawer;

    public void UnlockDrawer()
    {
        key.SetActive(false);
        lockedDrawer.SetActive(false);
        falseBottom.SetActive(true);
    }
    public void RemoveFalseBottom()
    {
        falseBottom.SetActive(false);
        iFalseBottom.SetActive(true);
        chalk.SetActive(false);
        Stopwatch.instance.StopStopwatch("drawer");
    }


}