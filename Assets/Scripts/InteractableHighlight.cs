using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHighlight : MonoBehaviour
{
    // This function will turn on emission property and highlight the object
    public void OnHover()
    {
        //Get all meshrenderers and store them
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Look through all the meshrenderers and turn on property
        foreach(MeshRenderer renderer in meshRenderers)
        {
            //Turn on the emissoin property of each renderer

            renderer.material.EnableKeyword("_EMISSION");
        }
    }

    public void ExitHover()
    {
        //Get all meshrenderers and store them
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Look through all the meshrenderers and turn on property
        foreach (MeshRenderer renderer in meshRenderers)
        {
            //Turn off the emissoin property of each renderer

            renderer.material.DisableKeyword("_EMISSION");
        }

    }
}
