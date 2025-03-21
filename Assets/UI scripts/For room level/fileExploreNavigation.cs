using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileExploreNavigation : MonoBehaviour
{
    public GameObject downloadsFolder;
    public GameObject downloadsGIFcanvas;
    public GameObject documentsFolder;
    public GameObject fileExplorerBG;
    public GameObject IMG07folder;
    public GameObject hhhhFolder;
    public GameObject hhhhFolderStuff;
    public GameObject IMG07FolderStuff;

    public GameObject PICknife;
    public GameObject TXTpassword;
    public GameObject TXTchatlog;
    public GameObject PICmuteScreenshot;
    public GameObject PICholdhands;

    void Start()
    {
        downloadsGIFcanvas.SetActive(false);
        downloadsFolder.SetActive(false);
        documentsFolder.SetActive(false);
        fileExplorerBG.SetActive(false);
        hhhhFolder.SetActive(false);
        hhhhFolderStuff.SetActive(false);
        IMG07folder.SetActive(false);
        IMG07FolderStuff.SetActive(false);


        PICknife.SetActive(false);
        TXTchatlog.SetActive(false);
        TXTpassword.SetActive(false);
        PICmuteScreenshot.SetActive(false);
        PICholdhands.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log("Button clicked: " + hit.collider.gameObject.name);

                // Check which button was pressed based on its name
                switch (hit.collider.gameObject.name)
                {
                    case "downloads button":
                        ShowDownloads();
                        break;

                    case "documents button":
                        ShowDocuments();
                        break;

                    case "digi drug button":
                        ShowDigiDrug();
                        break;

                    case "private button":
                    ShowPrivate();
                    break;

                    default:
                        break;
                }
            }
            else
            {
                // Debug.Log("No button was clicked.");
            }
        }
    }

    private void ShowDocuments()
    { // the documents folder contents only show after notification 10 appears
        if (notif10Script.Instance != null && notif10Script.Instance.notif10Triggered)
        {
            documentsFolder.SetActive(true);

            downloadsGIFcanvas.SetActive(false);
            downloadsFolder.SetActive(false);
            IMG07folder.SetActive(false);
            IMG07FolderStuff.SetActive(false);
            hhhhFolderStuff.SetActive(false);
            hhhhFolder.SetActive(false);
        }
        else
        {
            Debug.Log("notif10 has not been triggered yet. Documents folder remains hidden.");
        }
    }


    private void ShowDownloads()
    {
        downloadsGIFcanvas.SetActive(true);
        downloadsFolder.SetActive(true);

        documentsFolder.SetActive(false);
        IMG07folder.SetActive(false);
        IMG07FolderStuff.SetActive(false);
        hhhhFolderStuff.SetActive(false);
        hhhhFolder.SetActive(false);
    }

    private void ShowPrivate()
    {
        downloadsGIFcanvas.SetActive(false);
        downloadsFolder.SetActive(false);
        documentsFolder.SetActive(false);

        IMG07folder.SetActive(false);
        IMG07FolderStuff.SetActive(false);
        hhhhFolderStuff.SetActive(false);
        hhhhFolder.SetActive(false);
    }

    private void ShowDigiDrug()
    {
        downloadsGIFcanvas.SetActive(false);
        downloadsFolder.SetActive(false);
        documentsFolder.SetActive(false);

        IMG07folder.SetActive(false);
        IMG07FolderStuff.SetActive(false);
        hhhhFolderStuff.SetActive(false);
        hhhhFolder.SetActive(false);
    }
}


