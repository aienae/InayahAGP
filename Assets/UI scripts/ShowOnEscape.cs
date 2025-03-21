using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOnEscape : MonoBehaviour
{
    public Canvas settingsPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPage != null)
            {
                settingsPage.gameObject.SetActive(true);
            }
        }
    }
}
