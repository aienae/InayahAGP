using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        FindObjectOfType<ImageString>().AddImage(0);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
