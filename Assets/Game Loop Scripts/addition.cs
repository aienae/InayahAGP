using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class addition : MonoBehaviour
{
    public GameObject[] spritePrefabs; // array of prefabs added on the screen (the icons or whatvr)
    public GameObject[] targetObjects; // array corresponding target objects
    public float timee = 2f;
    public int numOfSprites = 20;
    public float verticalSpacing = 100f;
    public float horizontalSpacing = 100f;
    public float startingYPosition = 500f;
    public float startingXPosition = 100f;
    private float screenBottomY;

    public float columnOffset = 50f;

    private int currentCount = 0;
    private int currentColumn = 0;

    public GameObject visibilityControlObject;
    private List<GameObject> instantiatedSprites = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddSpritesOverTime());
        StartCoroutine(CheckVisibilityControlObj());
    }

    IEnumerator AddSpritesOverTime()
    {
        while (currentCount < numOfSprites)
        {
            // a random prefab and its corresponding object is chosen
            int randomIndex = Random.Range(0, spritePrefabs.Length);
            GameObject selectedPrefab = spritePrefabs[randomIndex];
            GameObject assignedTarget = targetObjects[randomIndex];

            // Instantiate sselected prefab
            GameObject newSprite = Instantiate(selectedPrefab, transform);

            // the position on the scren
            float yPosition = startingYPosition - (currentCount * verticalSpacing);

            if (yPosition < screenBottomY + columnOffset)
            {
                currentCount = 0;
                currentColumn++;
                yPosition = startingYPosition;
            }

            float xPosition = startingXPosition + (currentColumn * horizontalSpacing);

            newSprite.transform.position = new Vector3(xPosition, yPosition, 0);

            // the target object assigned to the prefab's script
            OpenImageFromDesktop prefabScript = newSprite.GetComponent<OpenImageFromDesktop>();
            if (prefabScript != null)
            {
                prefabScript.Initialize(assignedTarget);
            }
            else
            {
                Debug.LogError("Prefab does not contain OpenImageFromDesktop script!");
            }

            PlayVideUIButtonWithTag videoScript = newSprite.GetComponent<PlayVideUIButtonWithTag>();
            if (videoScript != null)
            {
                VideoPlayer assignedVideoPlayer = assignedTarget.GetComponentInChildren<VideoPlayer>();
                Canvas assignedCanvas = assignedTarget.GetComponentInChildren<Canvas>();
                
                if (assignedVideoPlayer != null && assignedCanvas != null)
                {
                    videoScript.Initialize(assignedVideoPlayer, assignedCanvas);
                }
                else
                {
                    Debug.LogError("Assigned target does not contain a VideoPlayer or Canvas component!");
                }
            }

            // added it to list for visibility control (IMPORTANT)
            instantiatedSprites.Add(newSprite);
            currentCount++;

            yield return new WaitForSeconds(timee);
        }
    }

    IEnumerator CheckVisibilityControlObj()
    {
        while (true)
        {
            if (visibilityControlObject != null)
            {
                if (visibilityControlObject.activeSelf)
                {
                    foreach (GameObject sprite in instantiatedSprites)
                    {
                        if (sprite != null)
                        {
                            sprite.SetActive(true);
                        }
                    }
                }
                else
                {
                    foreach (GameObject sprite in instantiatedSprites)
                    {
                        if (sprite != null)
                        {
                            sprite.SetActive(false);
                        }
                    }
                }
            }

            yield return new WaitForSeconds(0.1f); // delay to avoid problems ( i cant remember why just allo it)
        }
    }

    public void DeleteAllSprites()
    {
        foreach (GameObject sprite in instantiatedSprites)
        {
            if (sprite != null)
            {
                Destroy(sprite);
            }
        }

        instantiatedSprites.Clear();

        currentColumn = 0;
        currentCount = 0;

        StopCoroutine(AddSpritesOverTime());
        StartCoroutine(AddSpritesOverTime());
    }

    private void OnMouseDown()
    {
        DeleteAllSprites();
    }
}



