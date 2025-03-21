using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class password : MonoBehaviour
{
    public string correctPassword = "myeyesonly";
    public TMP_InputField passwordField;
    public GameObject passwordEmptyObj;
    public GameObject lovefacePage;
    public GameObject loginpagebutton;
    public GameObject meyenasPostsEmpty;
    public GameObject InternetEmpty;
    public GameObject bubblePrefab; // bubble 11 prefab

    public GameObject lovefaceTab;
    public bool isPasswordCorrect = false;

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            // Converting screen position to world position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 2D raycast from the mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Checks if the clicked object is the login page button
                if (hit.collider.gameObject == loginpagebutton)
                {
                    Debug.Log("Login button clicked!");
                    HandleLoginButtonClick();
                }
            }
            else
            {
                
            }
        }
    }

    private void HandleLoginButtonClick()
    {
        string enteredPassword = passwordField.text;

        if (enteredPassword == correctPassword)
        {
            Debug.Log("Correct password!");
            lovefacePage.SetActive(true);
            loginpagebutton.SetActive(false);
            meyenasPostsEmpty.SetActive(true);
            isPasswordCorrect = true;
            BubbleManager.Instance.CreateBubble(bubblePrefab); // creates bubble 11
        }
        else
        {
            Debug.Log("Incorrect password!");
        }
    }

    void Start()
    {
        lovefacePage.SetActive(false);
    }

    void Update()
    {
        CheckMouseClick(); // Always check for mouse clicks v importan

        if (lovefaceTab.activeSelf && isPasswordCorrect && InternetEmpty.activeSelf)
        {
            meyenasPostsEmpty.SetActive(true);
        }
        else
        {
            meyenasPostsEmpty.SetActive(false);
        }
    }
}



