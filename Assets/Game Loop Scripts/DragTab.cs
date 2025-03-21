using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTab : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public Collider2D dragRegion; // Assignni a specifc region for draging
    public SpriteRenderer spriteRenderer;

    private void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPos() + offset;
        if (spriteRenderer)
        {
            spriteRenderer.transform.position = ClampToScreenBounds(newPosition); // Keep it within screen limits
        }
    }

    private void OnMouseDown()
    {
        offset = spriteRenderer.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private Vector3 ClampToScreenBounds(Vector3 position)
    {
        Camera cam = Camera.main;
        Vector3 minScreenBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)); // Bottom-left corner
        Vector3 maxScreenBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)); // Top-right corner

        float clampedX = position.x;
        float clampedY = position.y;
        if (spriteRenderer)
        {
            float objectWidth = spriteRenderer.bounds.extents.x;  // Half-width of the object
            float objectHeight = spriteRenderer.bounds.extents.y; // Half-height of the object

            // Clamp X and Y positions within screen bounds
            clampedX = Mathf.Clamp(position.x, minScreenBounds.x + objectWidth, maxScreenBounds.x - objectWidth);
            clampedY = Mathf.Clamp(position.y, minScreenBounds.y + objectHeight, maxScreenBounds.y - objectHeight);
        }

        return new Vector3(clampedX, clampedY, position.z);
    }
}



