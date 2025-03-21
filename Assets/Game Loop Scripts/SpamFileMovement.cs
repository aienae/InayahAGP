using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamFileMovement : MonoBehaviour
{
    public GameObject spritePrefab; // Prefab for the sprite
    public int initialSpriteCount = 5; // Number of sprites at the start
    public int maxSprites = 20; // Maximum number of sprites
    public float spawnInterval = 5f; // Time interval to add a new sprite
    public float speedMin = 1f; // Minimum movement speed
    public float speedMax = 5f; // Maximum movement speed

    private Vector2 screenBounds = new Vector2(1920 / 2f, 1080 / 2f); // Fixed screen bounds for 1920x1080 resolution
    private List<SpriteMover> spriteMovers = new List<SpriteMover>();
    private Coroutine spawnCoroutine;
    private bool areSpritesHidden = false; // State to track if sprites should be hidden

    private void Start()
    {
        Initialize();
        HideSprites();
    }

    private void Initialize()
    {
        // Spawn initial sprites
        for (int i = 0; i < initialSpriteCount; i++)
        {
            SpawnSprite();
        }

        // Start adding more sprites over time
        spawnCoroutine = StartCoroutine(AddSpritesOverTime());
    }

    private void SpawnSprite()
    {
        if (spriteMovers.Count >= maxSprites) return;

        // Instantiate a new sprite and add it to the list
        GameObject newSprite = Instantiate(spritePrefab);
        newSprite.transform.position = GetRandomPosition();

        // Respect the hidden state
        newSprite.SetActive(!areSpritesHidden);

        SpriteMover mover = newSprite.AddComponent<SpriteMover>();
        mover.Initialize(screenBounds, Random.Range(speedMin, speedMax));
        spriteMovers.Add(mover);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-screenBounds.x, screenBounds.x),
            Random.Range(-screenBounds.y, screenBounds.y),
            0
        );
    }

    private IEnumerator AddSpritesOverTime()
    {
        while (spriteMovers.Count < maxSprites)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnSprite();
        }
    }

    /// <summary>
    /// Resets the entire system, removing all sprites and restarting the process.
    /// </summary>
    public void ResetSystem()
    {
        // Stop the current spawning coroutine
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

        // Destroy all existing sprites
        foreach (SpriteMover mover in spriteMovers)
        {
            if (mover != null)
            {
                Destroy(mover.gameObject);
            }
        }
        spriteMovers.Clear();

        // Restart the initialization process
        Initialize();
    }

    /// <summary>
    /// Hides all sprites, including new ones being spawned.
    /// </summary>
    public void HideSprites()
    {
        areSpritesHidden = true;

        foreach (SpriteMover mover in spriteMovers)
        {
            if (mover != null)
            {
                mover.gameObject.SetActive(false); // Disable the sprite GameObject
            }
        }
    }

    /// <summary>
    /// Shows all sprites, including new ones being spawned.
    /// </summary>
    public void ShowSprites()
    {
        areSpritesHidden = false;

        foreach (SpriteMover mover in spriteMovers)
        {
            if (mover != null)
            {
                mover.gameObject.SetActive(true); // Enable the sprite GameObject
            }
        }
    }
}

public class SpriteMover : MonoBehaviour
{
    private Vector2 screenBounds;
    private float speed;
    private Vector3 direction;

    public void Initialize(Vector2 bounds, float moveSpeed)
    {
        screenBounds = bounds;
        speed = moveSpeed;

        // Choose a random initial direction
        direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
        ).normalized;
    }

    private void Update()
    {
        // Move the sprite in the current direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Check for screen bounds and bounce off edges
        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
        {
            direction.x = -direction.x; // Reverse X direction
            ClampPositionX(); // Keep the sprite within bounds
        }

        if (transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
        {
            direction.y = -direction.y; // Reverse Y direction
            ClampPositionY(); // Keep the sprite within bounds
        }
    }

    private void ClampPositionX()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void ClampPositionY()
    {
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}


