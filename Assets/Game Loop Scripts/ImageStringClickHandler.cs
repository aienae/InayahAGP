using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class ImageStringClickHandler : MonoBehaviour
{
    public ImageString imageString; 
    public AudioSource clickAudioSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag("Synbol Image Added"))
                {
                    clickAudioSource.Play();
                    Debug.Log("Image clicked: " + result.gameObject.name);
                    
                    // Get image index from objectz name or component 
                    int imageIndex = result.gameObject.GetComponent<ImageIndex>().index; 
                    
                    imageString.RemoveImage(result.gameObject, imageIndex); // method calledd in ImageString
                    break;
                }
            }
        }
    }
}

