using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public GameObject Key_socket;
    public GameObject Paintingtable1_socket;
    //public GameObject Paintingtable2_socket;


    public GameObject Key_interact;
    public GameObject Painting1_noninteract;
    public GameObject Painting1_interact;
    //public GameObject Painting2_noninteract;
    //public GameObject Painting2_interact;


    public GameObject Key_lock;
    public GameObject Painting1_lock1;
    //public GameObject Painting2_lock;


    public Animator LidMovement;
    public Animator Painting1_Movement;



    public void ToggleKey()
    {
        Key_interact.SetActive(false);
        Key_socket.SetActive(false);
        Key_lock.SetActive(true);
        LidMovement.SetBool("IsUnlocked", true);

        //turns painting 1 on wall interactable
        Painting1_noninteract.SetActive(false);
        Painting1_interact.SetActive(true);
        Debug.Log("painting true");
        //Painting2_noninteract.SetActive(false);
        //Painting2_interact.SetActive(true);
        Paintingtable1_socket.SetActive(true);
        //Paintingtable2_socket.SetActive(true);
    }

    public void Painting1()
    {
        Painting1_lock1.SetActive(true);
        Paintingtable1_socket.SetActive(false);
        Painting1_interact.SetActive(false);
        //play animation here
        Painting1_Movement.SetBool("isPlaced", true);
        //Painting1_interact1.SetActive(false);
        //Painting1_interact2.SetActive(true);
        Stopwatch.instance.StopStopwatch("painting");
    }

    public void Painting2()
    {
        //Painting2_interact1.SetActive(false);
        //    Paintingtable2_socket.SetActive(false);
        //play animation here
        //Painting2_interact2.SetActive(true);
    }

}
