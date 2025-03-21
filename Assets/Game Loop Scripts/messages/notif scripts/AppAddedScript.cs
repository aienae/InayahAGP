using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AppAddedScript : MonoBehaviour
{   
    // this entire script is just notif manager copy and pasted again but changed the sound to application added
    
    public AudioClip bubbleSound; // this will be the application added sfx instead
    public AudioSource audioSource;

    public static AppAddedScript Instance; // Singleton for global access

    public delegate void notif1Script();
    public event notif1Script OnBubbleDestroyed;

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
    /// Instantiates a dialogue bubble prefab at the specified position and fades it out after 5 seconds.
    /// </summary>
    /// <param name="bubblePrefab">The prefab of the bubble to instantiate.</param>
    public void CreateBubble(GameObject bubblePrefab)
    {
        if (bubblePrefab != null)
        {
            audioSource.PlayOneShot(bubbleSound);
        
            // Define the hardcoded position for the bubble
            Vector3 bubblePosition = new Vector3(954f, 176f, 0f);

            // Instantiate the bubble prefab at the hardcoded position
            GameObject bubble = Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);

            // Start fading out and destroying the bubble after 5 seconds
            StartCoroutine(FadeOutAndDestroy(bubble));
        }
        else
        {
            Debug.LogError("Bubble prefab is null! Please assign a valid prefab.");
        }
    }

    private IEnumerator FadeOutAndDestroy(GameObject bubble)
    {
        SpriteRenderer spriteRenderer = bubble.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Destroy(bubble);
            OnBubbleDestroyed?.Invoke();
            yield break;
        }

        float duration = 1f; // Duration of fade-out effect
        float elapsedTime = 0f;
        Color originalColor = spriteRenderer.color;

        yield return new WaitForSeconds(4f); // Wait before fading out

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Destroy(bubble);
        OnBubbleDestroyed?.Invoke();
    }
}
