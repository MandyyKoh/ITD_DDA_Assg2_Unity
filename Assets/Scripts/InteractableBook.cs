using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractableBook : MonoBehaviour
{
    //Mandy helped me with the stuff cuz i had issues

    [Header("Socket Interactor")]
    public GameObject Book1_socket;
    public GameObject Book2_socket;
    public GameObject Book3_socket;
    public GameObject Book4_socket;

    [Header("Interactable Book")]
    public GameObject Book1_interact;
    public GameObject Book2_interact;
    public GameObject Book3_interact;
    public GameObject Book4_interact;

    [Header("Locked Book")]
    public GameObject Book1_lock;
    public GameObject Book2_lock;
    public GameObject Book3_lock;
    public GameObject Book4_lock;

    public Animator animator;

    public void LockBook1()
    {
        Book1_interact.SetActive(false);
        Book1_socket.SetActive(false);
        Book1_lock.SetActive(true);
        Book2_socket.SetActive(true);
        Debug.Log("Book1 locked, book2 socket available");
    }
    public void LockBook2()
    {
        Book2_interact.SetActive(false);
        Book2_socket.SetActive(false);
        Book2_lock.SetActive(true);
        Book3_socket.SetActive(true);
        Debug.Log("Book2 locked, book3 socket available");
    }
    public void LockBook3()
    {
        Book3_interact.SetActive(false);
        Book3_socket.SetActive(false);
        Book3_lock.SetActive(true);
        Book4_socket.SetActive(true);
        Debug.Log("Book3 locked, book4 socket available");
    }
    public void LockBook4()
    {
        Book4_interact.SetActive(false);
        Book4_socket.SetActive(false);
        Book4_lock.SetActive(true);
        Debug.Log("Book4 locked, shelf animation play");
    }

    public void MoveShelf()
    {
        animator.SetBool("isUnlocked", true);
        Stopwatch.instance.StopStopwatch("bookshelf");
    }
}
