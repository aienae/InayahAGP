using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 originalPos;

    private Collider2D binCollider;
    public float snapBackSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;

        GameObject binObject = GameObject.FindGameObjectWithTag("Bin");
        if (binObject != null)
        {
            binCollider = binObject.GetComponent<Collider2D>();
        }
        else
        {
            
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, screenPoint.z));

        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = cursorPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (binCollider != null && binCollider.bounds.Contains(transform.position))
        {
            Debug.Log("Object within bounds, being deleted");
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(SnapBackToOriginalPosition());
        }
    }

    IEnumerator SnapBackToOriginalPosition()
    {
        while (Vector3.Distance(transform.position, originalPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, originalPos, snapBackSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = originalPos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
