using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CloseComputerButton : MonoBehaviour
{   
    public GameObject PCempty;
    public GameObject antivirusWindow;
    public GameObject antiTimer;
    public GameObject passwordM;
    public GameObject mysPosts;
    public GameObject internetTab;
    public GameObject startPage;
    public GameObject codeBreakerPage;
    public GameObject neoRoom;

    public GameObject fileexplorerEmpty;
    public GameObject downloadsgifCanvas;
    public GameObject laughVID;
    public GameObject partyVID;


    public SpamFileMovement spamfileMovementScript;
    public RandomVideo randomVideoScript;

    private void OnMouseDown()
    {
        PCempty.SetActive(false);
        antivirusWindow.SetActive(false);
        antiTimer.SetActive(false);
        passwordM.SetActive(false);
        mysPosts.SetActive(false);
        internetTab.SetActive(false);
        startPage.SetActive(false);
        codeBreakerPage.SetActive(false);
        laughVID.SetActive(false);
        partyVID.SetActive(false);

        neoRoom.SetActive(true);

        fileexplorerEmpty.SetActive(false);
        downloadsgifCanvas.SetActive(false);
        
        spamfileMovementScript.HideSprites(); // hides the spam files when you leave the computer
        randomVideoScript.PauseObjectActivation();
    }
}
