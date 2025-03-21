using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class antivirusExecuteButton : MonoBehaviour
{
    public addition additionScript;
    public SpamFileMovement spamFileMovementScript;
    public RandomVideo randomVideoScript;
    public float coolDownTime = 30f;
    private float nextAvailableTime = 0f;
    private bool isOnCooldown = false;
    public TMP_Text timerText;
    public GameObject timertextEmpty;
    public List<GameObject> loadingSprites;
    public List<GameObject> doneSprites;

    private void Start()
    {
        SetLoadingSprites(true);
        SetDoneSprites(false);
    }
    private void Update()
    {
        if (isOnCooldown)
        {
            float remainingTime = Mathf.Max(0f, nextAvailableTime - Time.time);
            timerText.text = Mathf.Ceil(remainingTime).ToString("0") +"s";
            
            if (remainingTime <= 0f)
            {
                isOnCooldown = false;
                timerText.text = "Ready";
                SetLoadingSprites(true);
                SetDoneSprites(false);
                timertextEmpty.SetActive(true);
            }
        }
    }

    private void OnMouseDown()
    {
        if (additionScript != null && Time.time >= nextAvailableTime)
        {
            additionScript.DeleteAllSprites();
            spamFileMovementScript.ResetSystem();
            randomVideoScript.ResetSystem();
            nextAvailableTime = Time.time + coolDownTime;
            isOnCooldown = true;
            SetLoadingSprites(false);
            SetDoneSprites(true);
            timertextEmpty.SetActive(true);

            StartCoroutine(ShowDoneSpritesTemporarily());
        }
        else
        {
            Debug.Log("button is on cooldown. please wait");
        }
    }
    private IEnumerator ShowDoneSpritesTemporarily()
    {
        yield return new WaitForSeconds(5f);
        SetDoneSprites(false);
        SetLoadingSprites(true);
    }

    private void SetLoadingSprites(bool isActive)
    {
        foreach (GameObject sprite in loadingSprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(isActive);
            }
        }
    }

    private void SetDoneSprites(bool isActive)
    {
        foreach (GameObject sprite in doneSprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(isActive);
            }
        }
    }
}
