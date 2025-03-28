using UnityEngine;

public class OneHideForSprite : MonoBehaviour
{
    public GameObject objectttohide;
    BoxCollider2D boxCollider;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void SetPosition(Vector2 offset, Vector2 size)
    {
        if (boxCollider)
        {
            boxCollider.offset = offset;
            boxCollider.size = size;
        }
        else
        {
            Debug.LogWarning($"BoxCollider2D is missing for '{objectttohide.name}'");
        }
    }

    private void OnMouseDown()
    {
        objectttohide.SetActive(false);
    }
}
