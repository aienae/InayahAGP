using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Window : MonoBehaviour
{
    public float closeBoxSize = 27;
    static int minimumSort = 3;

    [SerializeField] private DragTab dragTab;
    [SerializeField] private OneHideForSprite closeBox;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SortingGroup group;
    [SerializeField] private Canvas canvas;
    static List<Window> windows = new List<Window>();

    void SetSortOrder(int order)
    {
        group.sortingOrder = order;
        if (canvas)
        {
            canvas.sortingOrder = order;
        }
    }

    void SortToTop()
    {
        Window topWindow = windows[windows.Count - 1];
        SetSortOrder(topWindow.group.sortingOrder + 1);
    }

    void OnEnable()
    {
        float windowWidth = spriteRenderer.sprite.bounds.size.x;
        float windowHeight = spriteRenderer.sprite.bounds.size.y;
        float barHeight = closeBoxSize / spriteRenderer.sprite.pixelsPerUnit;
        Vector2 offset = new Vector2(-barHeight / 2, (windowHeight - barHeight) / 2);
        Vector2 size = new Vector2(windowWidth - barHeight, barHeight);
        dragTab.SetPosition(offset, size);
        offset = new Vector2((windowWidth - barHeight) / 2, (windowHeight - barHeight) / 2);
        size = new Vector2(barHeight, barHeight);
        closeBox.SetPosition(offset, size);

        if (windows.Count > 0)
        {
            SortToTop();
        }
        else
        {
            SetSortOrder(minimumSort);
        }
        windows.Add(this);
    }

    void OnDisable()
    {
        windows.Remove(this);
    }

    public void BringToTop()
    {
        // move the current tab to the end
        windows.Remove(this);
        windows.Add(this);
        // renumber the sorting order
        int order = minimumSort;
        foreach (Window window in windows)
        {
            window.SetSortOrder(order);
            order++;
        }
    }

    public void Move(Vector3 position)
    {
        Camera cam = Camera.main;
        Vector3 minScreenBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)); // Bottom-left corner
        Vector3 maxScreenBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)); // Top-right corner

        float objectWidth = spriteRenderer.bounds.extents.x;  // Half-width of the object
        float objectHeight = spriteRenderer.bounds.extents.y; // Half-height of the object

        // Clamp X and Y positions within screen bounds
        float clampedX = Mathf.Clamp(position.x, minScreenBounds.x + objectWidth, maxScreenBounds.x - objectWidth);
        float clampedY = Mathf.Clamp(position.y, minScreenBounds.y + objectHeight, maxScreenBounds.y - objectHeight);

        transform.position = new Vector3(clampedX, clampedY, position.z);
    }
}
