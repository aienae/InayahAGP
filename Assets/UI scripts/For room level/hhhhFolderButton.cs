using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hhhhFolderButton : MonoBehaviour
{
    public GameObject downloadsFolderr;
    public GameObject downloadGifCanvass;
    public GameObject hhhhFolderStufff; 

    private void OnMouseDown()
    {
        downloadsFolderr.SetActive(false);
        downloadGifCanvass.SetActive(false);
        hhhhFolderStufff.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
