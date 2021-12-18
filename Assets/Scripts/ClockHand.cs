using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockHand : MonoBehaviour
{

    public GameObject clockHand;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectEntered()
    {
        Rigidbody cubeRigidbody = clockHand.GetComponent<Rigidbody>();
        cubeRigidbody.isKinematic = false;
    }




}
