using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public Animator trinketBoxAnimator;
    public Animator paintingAnimator;
    public void OpenTrinketBox()
    {
        trinketBoxAnimator.SetBool("IsUnlocked", true);
    }

    public void PlayPaintingAnimation()
    {
        paintingAnimator.SetBool("isPlaced", true);
        Stopwatch.instance.StopStopwatch("painting");
    }
}
