using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchKey : MonoBehaviour
{
    public GameObject paperClip;
    public GameObject key;
    public GameObject keyAnimation;
    public GameObject interactiveKey;

    public Animator anim;

    public void RetrieveKey()
    {
        paperClip.SetActive(false);
        key.SetActive(false);
        keyAnimation.SetActive(true);
        StartCoroutine("InteractKey");
    }

    IEnumerator InteractKey()
    {
        anim.SetBool("isRetrieving", true);
        yield return new WaitForSeconds(0.8f);
        keyAnimation.SetActive(false);
        interactiveKey.SetActive(true);
    }
}
