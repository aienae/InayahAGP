using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BubbleManager : MonoBehaviour
{
    public AudioClip bubbleSound;
    public AudioSource audioSource;

    public static BubbleManager Instance; // Singleton for global access

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Instantiates a dialogue bubble prefab
    /// </summary>
    /// <param name="bubblePrefab">The prefab of the bubble to instantiate.</param>
    /// <param name="position">The position where the bubble should appear.</param>
    public void CreateBubble(GameObject bubblePrefab)
    {
        if (bubblePrefab != null)
        {
            audioSource.PlayOneShot(bubbleSound);
            
            // hardcoded position for the bubble
            Vector3 bubblePosition = new Vector3(632f, 150f, 0f); // Adjust this as needed

            // Instantate bbubble prefab at the hardcoded position
            GameObject bubble = Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);

            // method to destroy the bubble when the button is pressed
            ButtonHandler buttonHandler = bubble.GetComponentInChildren<ButtonHandler>();
            if (buttonHandler != null)
            {
                buttonHandler.Setup(() => Destroy(bubble));
            }
        }
        else
        {
            Debug.LogError("Bubble prefab is null! Please assign a valid prefab.");
        }
    }
}

