using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class whaticlicked : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            GameObject clickedUI = GetClickedUI();
            if (clickedUI != null)
            {
                Debug.Log("UI Element clicked: " + clickedUI.name);
                return; // Exit if a UI element clicked
            }


            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Hit 2D Object: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("No 2D object detected at pointer position.");
            }
        }
    }

    private GameObject GetClickedUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0)
        {
            return results[0].gameObject;
        }

        return null; // No UI element was hit
    }
}


