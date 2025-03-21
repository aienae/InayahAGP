using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFileExplorer : MonoBehaviour
{
    public GameObject fileexplorerBG;
    public GameObject downloadsFolder;
    public GameObject documentsFolder;
    public GameObject PICknife;
    public GameObject PIChands;
    public GameObject PICmuteSS;
    public GameObject TXTpass;
    public GameObject TXTchatlog;
    public GameObject IMG07folder;
    public GameObject hhhhFolder;
    public GameObject downloadGIFcanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        fileexplorerBG.SetActive(false);
        downloadsFolder.SetActive(false);
        documentsFolder.SetActive(false);
        PIChands.SetActive(false);
        PICknife.SetActive(false);
        PICmuteSS.SetActive(false);
        TXTchatlog.SetActive(false);
        IMG07folder.SetActive(false);
        hhhhFolder.SetActive(false);
        downloadGIFcanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        fileexplorerBG.SetActive(false);
        downloadsFolder.SetActive(false);
        documentsFolder.SetActive(false);
        PIChands.SetActive(false);
        PICknife.SetActive(false);
        PICmuteSS.SetActive(false);
        TXTchatlog.SetActive(false);
        IMG07folder.SetActive(false);
        hhhhFolder.SetActive(false);
        downloadGIFcanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
