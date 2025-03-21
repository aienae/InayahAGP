using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RandomVideo : MonoBehaviour
{
    [System.Serializable]
    public class ObjectSlot
    {
        public GameObject objectToShow; // The GameObject to activate
        public float minDelayBeforeShowing = 1f; // Minimum delay
        public float maxDelayBeforeShowing = 5f; // Maximum delay
    }

    public ObjectSlot[] objectSlots; // Array of objects
    private Coroutine objectCoroutine;
    private bool hasStarted = false; // Ensures StartRandomObjects() runs once
    private HashSet<GameObject> previouslyActiveObjects = new HashSet<GameObject>(); // Store objects that were active before pausing

    /// <summary>
    /// Called from another script to start showing objects randomly.
    /// </summary>
    public void StartRandomObjects()
    {
        if (!hasStarted)
        {
            objectCoroutine = StartCoroutine(ShowObjectsAtRandomIntervals());
            hasStarted = true;
        }
    }

    /// <summary>
    /// Pauses the object activation process and hides all active objects.
    /// </summary>
    public void PauseObjectActivation()
    {
        if (objectCoroutine != null)
        {
            StopCoroutine(objectCoroutine);
            objectCoroutine = null;
        }

        previouslyActiveObjects.Clear(); // Reset the tracking set

        foreach (var slot in objectSlots)
        {
            if (slot.objectToShow != null && slot.objectToShow.activeSelf)
            {
                previouslyActiveObjects.Add(slot.objectToShow); // Store objects that were active
                slot.objectToShow.SetActive(false); // Hide them
            }
        }
    }

    /// <summary>
    /// Resumes showing objects that were active before pausing.
    /// </summary>
    public void ResumeObjectActivation()
    {
        foreach (var obj in previouslyActiveObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true); // Restore visibility
            }
        }

        previouslyActiveObjects.Clear(); // Clear the list after restoring

        if (objectCoroutine == null && hasStarted)
        {
            objectCoroutine = StartCoroutine(ShowObjectsAtRandomIntervals());
        }
    }

    private IEnumerator ShowObjectsAtRandomIntervals()
    {
        foreach (var slot in objectSlots)
        {
            float delayBeforeShowing = Random.Range(slot.minDelayBeforeShowing, slot.maxDelayBeforeShowing);
            yield return new WaitForSeconds(delayBeforeShowing);

            if (slot.objectToShow != null)
            {
                slot.objectToShow.SetActive(true); // Activate the GameObject
                Debug.Log($"Activated GameObject: {slot.objectToShow.name}");
            }
            else
            {
                Debug.LogError("Missing GameObject in ObjectSlot!");
            }
        }
    }

    /// <summary>
    /// Resets the system by deactivating all objects and restarting the random activation.
    /// </summary>
    public void ResetSystem()
    {
        PauseObjectActivation(); // Stop coroutine and hide all objects
        previouslyActiveObjects.Clear(); // Clear stored active objects
        ResumeObjectActivation(); // Restart random activation
    }
}

