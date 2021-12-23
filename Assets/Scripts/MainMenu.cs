using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenu : MonoBehaviour
{
    public GameObject player;

    public GameObject barbarossaTeleportPoint;

    public GameObject sealionTeleportPoint;

    public GameObject barbarossaReport;

    public GameObject sealionReport;

    public GameObject loginMenu;

    public GameObject applicationForm;

    public GameObject applicationFormResetPoint;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton() 
    {
        FirebaseManager.instance.StartCheckMap();
        StartCoroutine(TeleportPlayer());
    }

    public void QuitButton() 
    {
        Application.Quit();
    }

    public void LogoutButton() 
    {
        FirebaseManager.instance.auth.SignOut();
        loginMenu.GetComponent<LoginMenu>().ClearLoginInput();
        loginMenu.GetComponent<LoginMenu>().ClearRegisterInput();

    }

    private IEnumerator TeleportPlayer() 
    {
        string setMap = FirebaseManager.instance.currentMap;

        applicationForm.GetComponent<XRGrabInteractable>().enabled = false;
        yield return new WaitForSeconds(2f);
        if(setMap == "Barbarossa") 
        {
            player.transform.position = barbarossaTeleportPoint.transform.position;
            barbarossaReport.SetActive(true);
        }
        else if(setMap == "Sealion") 
        {
            player.transform.position = sealionTeleportPoint.transform.position;
            sealionReport.SetActive(true);
        }
        applicationForm.GetComponent<XRGrabInteractable>().enabled = true;
        applicationForm.transform.position = applicationFormResetPoint.transform.position;

    }
}
