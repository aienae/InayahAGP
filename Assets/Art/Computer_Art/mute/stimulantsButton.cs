using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stimulantsButton : MonoBehaviour
{
    public GameObject UIperson;
    public GameObject UIStimulants;
    public GameObject UIbioparts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        UIperson.SetActive(false);
        UIbioparts.SetActive(false);
        UIStimulants.SetActive(true);
    }
}
