using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTab : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] BoxCollider2D dragRegion; // Assignni a specifc region for draging
    [SerializeField] Window window;

    void Awake()
    {
        dragRegion = GetComponent<BoxCollider2D>();
        if (!window)
        {
            Debug.LogWarning("Window not assigned to DragTab script. Assign it in the inspector.", gameObject);
        }
    }

    public void SetPosition(Vector2 offset, Vector2 size)
    {
        dragRegion.offset = offset;
        dragRegion.size = size;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPos() + offset;
        window.Move(newPosition);
    }

    private void OnMouseDown()
    {
        window.BringToTop();
        offset = window.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}



