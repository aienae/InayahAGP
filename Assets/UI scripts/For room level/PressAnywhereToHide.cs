using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnywhereToHide : MonoBehaviour
{
    public GameObject targetObject; // object to show/hide
    private bool isObjectVisible = false;
    private float hideCooldownTime = 0.3f; // Short delay to stop instant hiding
    private float lastShownTime;

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
            isObjectVisible = true;
            lastShownTime = Time.time; // Record the time it shown
        }
    }

    private void Update()
    {
        if (isObjectVisible && Input.GetMouseButtonDown(0))
        {
            // short delay to stop instantly hiding
            if (Time.time - lastShownTime < hideCooldownTime)
                return;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider == null || (hit.collider.gameObject != targetObject && !targetObject.transform.IsChildOf(hit.collider.transform)))
            {
                targetObject.SetActive(false);
                isObjectVisible = false;
            }
        }
    }
}
