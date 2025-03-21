using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruction1 : MonoBehaviour
{
    public static instruction1 Instance;
    public GameObject instruction1Prefab;
    public Vector3 spawnPosition = new Vector3(955f, 80f, 0f); // Hardcoded position
    public GameObject bubblePrefab; // bubble 3 prefab

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

    public void CreateInstruction1()
    {
        if (instruction1Prefab != null)
        {
            // Instantiate the bubble prefab at the hardcoded position
            GameObject instructionn1 = Instantiate(instruction1Prefab, spawnPosition, Quaternion.identity);

            // Start the fade-out process
            StartCoroutine(FadeOutAndDestroy(instructionn1));
        }
        else
        {
            Debug.LogError("Bubble prefab is null! Please assign a valid prefab.");
        }
    }

    private IEnumerator FadeOutAndDestroy(GameObject instructionn1)
    {
        SpriteRenderer spriteRenderer = instructionn1.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Destroy(instructionn1);
            yield break;
        }

        float fadeDuration = 0.5f; // Duration of fade-out effect
        float elapsedTime = 0f;
        Color originalColor = spriteRenderer.color;

        yield return new WaitForSeconds(4f); // Wait before starting fade

        // Fade out process
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Call method in another script after fade is complete
        BubbleManager.Instance.CreateBubble(bubblePrefab);

        // Destroy the bubble after fade and method call
        Destroy(instructionn1);
    }
}
