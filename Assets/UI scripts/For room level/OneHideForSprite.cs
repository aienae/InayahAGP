using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHideForSprite : MonoBehaviour
{
    public GameObject objectttohide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        objectttohide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
