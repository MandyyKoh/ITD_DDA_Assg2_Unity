using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public bool electricalSolved = false;
    public bool bookshelfSolved = false;
    public bool puzzleSolved = false;
    public bool drawerSolved = false;
    public bool paintingSolved = false;

    public GameObject player;
    public GameObject reportRoomTeleportPoint;
    public static DoorHandle instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void ExitRoom() 
    {
        if(electricalSolved && bookshelfSolved && puzzleSolved && drawerSolved && paintingSolved) 
        {
            player.transform.position = reportRoomTeleportPoint.transform.position;
        }
    }

}
