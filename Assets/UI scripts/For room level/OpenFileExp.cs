using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFileExp : MonoBehaviour
{
    public GameObject fileExplorerBG;
    public GameObject fileExplorerEmptyyy;

    // these are the children of the file explorer bg
    public GameObject downloadsbutton;
    public GameObject documentsbutton;
    public GameObject privatebutton;
    public GameObject digidrugbutton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        fileExplorerEmptyyy.SetActive(true);

        fileExplorerBG.SetActive(true);
        downloadsbutton.SetActive(true);
        documentsbutton.SetActive(true);
        privatebutton.SetActive(true);
        digidrugbutton.SetActive(true);
        
        fileExplorerBG.GetComponent<Renderer>().enabled = true;
        downloadsbutton.GetComponent<Renderer>().enabled = true;
        documentsbutton.GetComponent<Renderer>().enabled = true;
        digidrugbutton.GetComponent<Renderer>().enabled = true;
        privatebutton.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
