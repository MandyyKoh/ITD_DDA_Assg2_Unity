using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntHighlight : MonoBehaviour
{
    //Turn on emission property and highlight object
    public void OnHover()
    {
        // Get all Meshrenderers and store them.
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Look through all Meshrenderers and turn on the emission property.
        foreach(MeshRenderer renderer in meshRenderers)
        {
            // Turn on emission property of each renderer
            renderer.material.EnableKeyword("_EMISSION");
        } 
    }

    //Turn off emission property & stop highlight
    public void ExitHover()
    {
        // Get all Meshrenderers and store them.
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        //Look through all Meshrenderers and turn on the emission property.
        foreach (MeshRenderer renderer in meshRenderers)
        {
            // Turn off emission property of each renderer
            renderer.material.DisableKeyword("_EMISSION");
        }
    }
}
