using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public Animator trinketBoxAnimator;
    public Animator paintingAnimator;

    public GameObject doorHandle;
    public void OpenTrinketBox()
    {
        AudioManager.instance.Play("ChestOpen");
        trinketBoxAnimator.SetBool("IsUnlocked", true);
    }

    public void PlayPaintingAnimation()
    {
        paintingAnimator.SetBool("isPlaced", true);
        doorHandle.GetComponent<DoorHandle>().paintingSolved = true;
        Stopwatch.instance.StopStopwatch("painting");
    }
}
