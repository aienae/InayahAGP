using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteSiteButtons : MonoBehaviour
{
    public GameObject UIperson;
    public GameObject UIStimulants;
    public GameObject UIbioparts;

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
                    case "Person":
                        ShowPersonView();
                        break;

                    case "Stimulants":
                        ShowStimulantsView();
                        break;

                    case "Bioparts":
                        ShowBiopartsView();
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

    private void ShowPersonView()
    {
        Debug.Log("Showing Person view");
        UIperson.SetActive(true);
        UIStimulants.SetActive(false);
        UIbioparts.SetActive(false);
    }

    private void ShowStimulantsView()
    {
        Debug.Log("Showing Stimulants view");
        UIperson.SetActive(false);
        UIStimulants.SetActive(true);
        UIbioparts.SetActive(false);
    }

    private void ShowBiopartsView()
    {
        Debug.Log("Showing Bioparts view");
        UIperson.SetActive(false);
        UIStimulants.SetActive(false);
        UIbioparts.SetActive(true);
    }
}

