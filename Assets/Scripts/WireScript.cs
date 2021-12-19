using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    public int connectedWires = 0;
    public Light indicatorLight;
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
            Stopwatch.instance.StopStopwatch("electrical");
        }
    }
}
