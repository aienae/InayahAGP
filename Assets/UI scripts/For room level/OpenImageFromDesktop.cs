using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenImageFromDesktop : MonoBehaviour
{
    private GameObject targetObject;
    private bool isMouseOverPrefab = false; // Tracks if the mouse is over the prefab

public void Initialize(GameObject assignedTarget)
{
    targetObject = assignedTarget; // Assign the target object when prefab is instantiated

    if (targetObject != null)
    {
        // Only hide the target if it's not already active
        if (!targetObject.activeSelf)
        {
            targetObject.SetActive(false); // Ensure the target is hidden initially
        }
        else
        {
            Debug.Log($"{targetObject.name} is already active, so it won't be hidden.");
        }
    }
    else
    {
        Debug.LogError("Assigned target is null during initialization!");
    }
}

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true); // Show the target object
            Debug.Log($"{targetObject.name} is now visible.");
        }
        else
        {
            Debug.LogError("No target object to show on click.");
        }
    }

    private void OnMouseOver()
    {
        isMouseOverPrefab = true; // Set flag to true when mouse is over the prefab
    }

    private void OnMouseExit()
    {
        isMouseOverPrefab = false; // Set flag to false when mouse leaves the prefab
    }

    private void Update()
    {
        // Detect clicks anywhere on the screen
        if (Input.GetMouseButtonDown(0) && !isMouseOverPrefab)
        {
            if (targetObject != null && targetObject.activeSelf)
            {
                //targetObject.SetActive(false); // Hide the target object
                //Debug.Log($"{targetObject.name} is now hidden.");
            }
        }
    }
}




