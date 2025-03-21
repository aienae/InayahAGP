using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hover : MonoBehaviour
{
    public SpriteRenderer spriteRendeerer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendeerer.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        spriteRendeerer.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRendeerer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            spriteRendeerer.enabled = true;

        }

        else
        {
            spriteRendeerer.enabled = false;
        }
    }
}
