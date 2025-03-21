using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ImageString : MonoBehaviour
{
    public GameObject imagePrefab;            // Prefab of the image (with Button comp)
    public Transform parentContainer;         // image container
    public Sprite[] buttonSprites;            // sprites to choose from
    public float imageOffsetX = 100f;         // horizon offset between images
    public int maxImages = 4;                // max num images
    public List<int> correctCombination;      // List of correct images
    public GameObject bubblePrefab;
    
    //public VideoPlayer urMutedVideoPlayer;
    //public GameObject UrMutedVideoPlayerCanvas;
    public GameObject urMutedGameObj;
    public AudioSource errorSoundEffect;    
    public GameObject insideMute;
    public GameObject UIpersonnlist;
    public GameObject UIbiopartss;
    public GameObject UIStimulantss;
    public GameObject internetEmpty;
    public GameObject codebreakerPage;
    public GameObject puzzle1Canvas;

    public GameObject muteTabs;
    public GameObject internetEmptyy;
    public GameObject youtubeTab;
    public GameObject lovefaceTab;
    public GameObject muteWarning;
    public bool isCorrect = false;

    private List<int> selectedCombination = new List<int>(); // Track selected images

    public void AddImage(int index)
    {
        int currentImageCount = parentContainer.childCount;

        if (currentImageCount >= maxImages)
        {
            Debug.Log("Maximum image limit reached.");
            return;
        }

        if (index >= 0 && index < buttonSprites.Length)
        {
            GameObject newImage = Instantiate(imagePrefab, parentContainer);
            newImage.GetComponent<Image>().sprite = buttonSprites[index];

            ImageIndex imageIndexComponent = newImage.GetComponent<ImageIndex>();
            if (imageIndexComponent != null)
            {
                imageIndexComponent.index = index;
            }
            

            // Adjust position manually 
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(imageOffsetX * currentImageCount, 0);

            // Adding click-to-remove functionality
            Button button = newImage.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => RemoveImage(newImage, index));
            }
            else
            {
                Debug.LogError("Button component missing on image prefab.");
            }

            selectedCombination.Add(index); // Track the added image index
            Debug.Log($"Selected combination after adding: {string.Join(", ", selectedCombination)}");
            CheckCombination(); // Check the combination after adding
        }
    }

    public void RemoveImage(GameObject imageToRemove, int index)
    {
        Destroy(imageToRemove);

        if (selectedCombination.Contains(index))
        {
            selectedCombination.Remove(index);
        }
        
        RepositionImages();
        CheckCombination();
    }

    private void RepositionImages()
    {
        int count = 0;
        foreach (Transform child in parentContainer)
        {
            RectTransform rectTransform = child.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(imageOffsetX * count, 0);
            count++;
        }

        Debug.Log("Repositioned images. Current count: " + count);
    }

    private void CheckCombination()
    {
        Debug.Log($"Checking combination. Current selected combination: {string.Join(", ", selectedCombination)}");

        if (selectedCombination.Count == maxImages)
        {
            isCorrect = true;

            for (int i = 0; i < maxImages; i++)
            {
                if (selectedCombination[i] != correctCombination[i])
                {
                    isCorrect = false;
                    Debug.Log("Incorrect combination.");
                    break;
                }
            }

            if (isCorrect)
            {
                Debug.Log("Correct combination!");
                urMutedGameObj.SetActive(true);
                
                // show mute after 5 seconds
                Invoke(nameof(ShowMuteHideBreaker), 5f);
            }
            else
            {
                errorSoundEffect.Play(); 
            }
        }
        else
        {
            Debug.Log("check skipped; not at max capacity");
        }
    }

    private void ShowMuteHideBreaker()
    {
        Debug.Log("inside mute");
        Invoke(nameof(HideWarning), 5f);
        
        internetEmpty.SetActive(true);
        insideMute.SetActive(true);
        muteTabs.SetActive(true);
        muteWarning.SetActive(true);
        lovefaceTab.SetActive(false);
        youtubeTab.SetActive(false);

        codebreakerPage.SetActive(false);
        puzzle1Canvas.SetActive(false);
        urMutedGameObj.SetActive(false);
        //UrMutedVideoPlayerCanvas.SetActive(false);

        UIpersonnlist.SetActive(false);
        UIStimulantss.SetActive(false);
        UIbiopartss.SetActive(false);
    }

    private void HideWarning()
    {
        muteWarning.SetActive(false);
        NotifManager.Instance.CreateBubble(bubblePrefab); // create notif 14
    }

    // this method occurs when the notif above fades out

    public void RemoveImageFromCombination(int index)
    {
    // Remove the image index from the selectedCombination list
        if (selectedCombination.Contains(index))
        {
            selectedCombination.Remove(index);
            Debug.Log("index removed");
        }
    
        // Recheck the combination after removal shits still broken tho ofc
        CheckCombination();
    }   

    void Update()
    {
        if (muteTabs.activeSelf && isCorrect && internetEmptyy.activeSelf)
        {
            insideMute.SetActive(true);
        }
        else
        {
            insideMute.SetActive(false);
        }
    }
}
