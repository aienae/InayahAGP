using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterComputer : MonoBehaviour
{
    public GameObject neoRoom;
    public GameObject PCbg;
    public SpamFileMovement spamFilescript;
    public RandomVideo randomVideoScriptt;

    public GameObject fileexplorerEmptyy;
    public GameObject fileExplorerBG;
    public GameObject downloadsbutton;
    public GameObject documentsbutton;
    public GameObject privatebutton;
    public GameObject digidrugbutton;
    public GameObject downloadsFolder;
    public GameObject documentsFolder;
    public GameObject hhhhFolder;
    public GameObject IMGFolder;

    private void OnMouseDown()
    {
        neoRoom.SetActive(false);
        PCbg.SetActive(true);
        spamFilescript.ShowSprites();

        fileexplorerEmptyy.SetActive(true);
        downloadsbutton.SetActive(true);
        documentsbutton.SetActive(true);
        privatebutton.SetActive(true);
        digidrugbutton.SetActive(true);
        downloadsFolder.SetActive(false);
        documentsFolder.SetActive(false);
        hhhhFolder.SetActive(false);
        IMGFolder.SetActive(false);
        
        fileExplorerBG.GetComponent<Renderer>().enabled = false;
        downloadsbutton.GetComponent<Renderer>().enabled = false;
        documentsbutton.GetComponent<Renderer>().enabled = false;
        digidrugbutton.GetComponent<Renderer>().enabled = false;
        privatebutton.GetComponent<Renderer>().enabled = false;
        //IMGFolder.GetComponent<Renderer>().enabled = false;
        //hhhhFolder.GetComponent<Renderer>().enabled = false;
        
        randomVideoScriptt.ResumeObjectActivation();

        if (randomVideoScriptt != null)
        {
            randomVideoScriptt.StartRandomObjects(); // Start adding videos
        }
        else
        {
            Debug.LogError("RandomVideo script is not assigned!");
        }
    }
}


