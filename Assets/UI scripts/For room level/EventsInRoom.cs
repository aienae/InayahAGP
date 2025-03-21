using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventsInRoom : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pc;
    public GameObject setting;
    public GameObject antivirus;
    public GameObject internetapp;
    public GameObject timertext;
    public GameObject passwordEmptyyy;
    public GameObject meyenaPostEmpty;
    public GameObject startMenu;
    public GameObject codeBreakerPage;
    public GameObject puzzle1Pagee;
    public GameObject puzzle1Canvass;
    public GameObject UIPersonn;
    public GameObject UIbiopartss;
    public GameObject UIStimulantss;
    
    // Start is called before the first frame update
    void Start()
    {
        pc.SetActive(false);
        pauseMenu.SetActive(false);
        setting.SetActive(false);
        antivirus.SetActive(false);
        internetapp.SetActive(false);
        timertext.SetActive(false);
        passwordEmptyyy.SetActive(false);
        meyenaPostEmpty.SetActive(false);
        startMenu.SetActive(false);
        codeBreakerPage.SetActive(false);
        puzzle1Canvass.SetActive(false);
        puzzle1Pagee.SetActive(false);
        UIbiopartss.SetActive(false);
        UIPersonn.SetActive(false);
        UIStimulantss.SetActive(false);
    }
}
