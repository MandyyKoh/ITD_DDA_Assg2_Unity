using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    public int connectedWires = 0;
    public Light indicatorLight;

    public Animator safeDoorAnimator;
    public GameObject blankDocument;
    public GameObject clueDocument;

    public GameObject doorHandle;
    public void AddConnectedWire() 
    {
        connectedWires += 1;

        CheckConnectedWires();
    }

    public void CheckConnectedWires() 
    {
        if (connectedWires >= 4) 
        {
            indicatorLight.enabled = true;
            blankDocument.SetActive(false);
            clueDocument.SetActive(true);
            doorHandle.GetComponent<DoorHandle>().electricalSolved = true;
            Stopwatch.instance.StopStopwatch("electrical");
            safeDoorAnimator.SetBool("ElectricalDone", true);
            AudioManager.instance.Play("SafeOpen");
        }
    }
}
