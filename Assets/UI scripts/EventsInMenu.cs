using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsInMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject creditPage;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
