using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDesktopPicForSpam : MonoBehaviour
{
    public string objectTag; 
    public static GameObject TargetObject { get; private set; }

    void Start()
    {
        // Find the target object by tag and hide it
        TargetObject = GameObject.FindGameObjectWithTag(objectTag);
        if (TargetObject != null)
        {
            TargetObject.SetActive(false);
            Debug.Log($"Target object '{TargetObject.name}' found and hidden");
        }
        else
        {
            Debug.LogWarning($"No GameObject with tag '{objectTag}' found in scene");
        }
    }
}


