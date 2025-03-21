using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Casette : MonoBehaviour
{
    public string[] requiredObjectNames; // Names of objects to track
    private HashSet<string> instantiatedObjectNames = new HashSet<string>(); // Tracks names of instantiated objects
    private bool hasExecuted = false;
    public GameObject bubblePrefab;       // Bubble 8 prefab
    public AudioClip tableSound;
    public AudioSource audioSource;
    public GameObject cassetteObject;     // Reference to the object with SpriteRenderer and BoxCollider2D
    public GameObject cassetteOverlay;      // Reference to the object with SpriteRenderer and BoxCollider2D
    private SpriteRenderer casetteOverlaySpriteRenderer ;
    private SpriteRenderer casetteSpriteRenderer;
    private BoxCollider2D cassetteBoxCollider2D;

    void Start()
    {
        if (cassetteObject != null)
        {
            casetteSpriteRenderer = cassetteObject.GetComponent<SpriteRenderer>();
            cassetteBoxCollider2D = cassetteObject.GetComponent<BoxCollider2D>();
        }

        if (cassetteOverlay != null)
        {
            casetteOverlaySpriteRenderer = cassetteOverlay.GetComponent<SpriteRenderer>();
        }
    }

    public void RegisterInstantiatedObject(GameObject obj)
    {
        if (IsRequiredObject(obj.name) && !instantiatedObjectNames.Contains(obj.name))
        {
            instantiatedObjectNames.Add(obj.name);  // Mark as instantiated
            Debug.Log(obj.name + " has been registered as instantiated.");

            // Check if all required objects were instantiated at least once
            if (AreAllObjectsInstantiated())
            {
                StartCoroutine(DelayedExecution(2f)); // 2-second delay before playing table sound
            }
        }
    }

    private bool IsRequiredObject(string objectName)
    {
        foreach (string requiredName in requiredObjectNames)
        {
            if (requiredName == objectName) // Check by name
            {
                return true;
            }
        }
        return false;
    }

    private bool AreAllObjectsInstantiated()
    {
        return instantiatedObjectNames.Count == requiredObjectNames.Length;
    }

    private IEnumerator DelayedExecution(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayTableSFX();

        // Enable SpriteRenderer and BoxCollider2D after the delay
        if (casetteSpriteRenderer != null)
            casetteSpriteRenderer.enabled = true;

        if (cassetteBoxCollider2D != null)
            cassetteBoxCollider2D.enabled = true;

        if (casetteOverlaySpriteRenderer != null)
            casetteOverlaySpriteRenderer.enabled = true;
    }

    private IEnumerator DelayedExecution2(float delay)
    {
        yield return new WaitForSeconds(delay);
        ExecuteCode();
    }

    private void PlayTableSFX()
    {
        audioSource.PlayOneShot(tableSound); // Plays the cassette placed on table SFX
        StartCoroutine(DelayedExecution2(2f)); // 2-second delay after audio plays to then show speech bubble
    }

    private void ExecuteCode()
    {
        if (!hasExecuted)
        {
            Debug.Log("All prefabs found; showing bubble 8");
            BubbleManager.Instance.CreateBubble(bubblePrefab);  // Create bubble 8
            hasExecuted = true;
        }
    }
}




