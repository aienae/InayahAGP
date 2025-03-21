using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class internettabs : MonoBehaviour
{
    public GameObject muteempty;
    public GameObject loveempty;
    public GameObject ytempty;
    public GameObject passwordEmptyy;
    public GameObject meyenasPostssEmpty;
    public GameObject UIpersonList;
    public GameObject UIStimulants;
    public GameObject UIbioparts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {

                switch (hit.collider.name)
                {
                    case "mute button empty":
                        Debug.Log("mute pressed");
                        DisplayObject(muteempty);
                        passwordEmptyy.SetActive(false);
                        meyenasPostssEmpty.SetActive(false);
                        UIbioparts.SetActive(false);
                        UIStimulants.SetActive(false);
                        UIpersonList.SetActive(false);
                        break;

                    case "loveface button empty":
                        Debug.Log("love pressed");
                        DisplayObject(loveempty);
                        passwordEmptyy.SetActive(true);
                        meyenasPostssEmpty.SetActive(true);
                        UIbioparts.SetActive(false);
                        UIStimulants.SetActive(false);
                        UIpersonList.SetActive(false);
                        break;
                        
                    case "yt button empty":
                        Debug.Log("yt pressed");
                        DisplayObject(ytempty);
                        passwordEmptyy.SetActive(false);
                        meyenasPostssEmpty.SetActive(false);
                        UIbioparts.SetActive(false);
                        UIStimulants.SetActive(false);
                        UIpersonList.SetActive(false);
                        break;
                }
            }
        }  
    }

    private void DisplayObject(GameObject objToShow)
    {
        muteempty.SetActive(false);
        loveempty.SetActive(false);
        ytempty.SetActive(false);

        objToShow.SetActive(true);
    }
}
