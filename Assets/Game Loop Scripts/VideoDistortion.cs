using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDistortion : MonoBehaviour
{
    Material videoDistortion;
    Vector3 clickPosition;
    Vector3 focusPosition;
    public float maxDistortion = 0.25f;
    public float minDistortion = 0.05f;
    public float tuningScale = 100.0f;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            videoDistortion = spriteRenderer.material;
        }
        focusPosition = new Vector3(maxDistortion, 0, 0);
        focusPosition = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward) * focusPosition;
        videoDistortion.SetFloat("_Noise", focusPosition.magnitude);
    }

    private void OnMouseDown()
    {
        clickPosition = GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        if (focusPosition.magnitude > minDistortion)
        {
            Vector3 mousePosition = GetMouseWorldPos();
            Vector3 offset = (mousePosition - clickPosition) / tuningScale;
            clickPosition = mousePosition;
            focusPosition.x = Mathf.Clamp(focusPosition.x - offset.x, -maxDistortion, maxDistortion);
            focusPosition.y = Mathf.Clamp(focusPosition.y - offset.y, -maxDistortion, maxDistortion);
            videoDistortion.SetFloat("_Noise", focusPosition.magnitude);
        }
        else
        {
            videoDistortion.SetFloat("_Noise", 0.0f);
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

}
