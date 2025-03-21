using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PressAnywhereToHideVid : MonoBehaviour
{
    public GameObject targetObject; // The object to show/hide
    public VideoPlayer videoPlayerr;
    private bool isObjectVisible = false;
    private float hideCooldownTime = 0.3f; // Short delay to prevent instant hiding
    private float lastShownTime;

    private void OnMouseDown()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
            isObjectVisible = true;
            lastShownTime = Time.time; // Record the time it was shown
        }
    }

    private void Update()
    {
        if (isObjectVisible && Input.GetMouseButtonDown(0))
        {
            // Introduce a short delay to prevent instant hiding
            if (Time.time - lastShownTime < hideCooldownTime)
                return;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider == null || (hit.collider.gameObject != targetObject && !targetObject.transform.IsChildOf(hit.collider.transform)))
            {
                videoPlayerr.Stop();
                targetObject.SetActive(false);
                isObjectVisible = false;
            }
        }
    }
}
