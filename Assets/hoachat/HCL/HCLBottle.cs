using UnityEngine;

public class HCLBottle : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openedSprite;

    private SpriteRenderer sr;

    public bool isOpened = false;

    private float lastClickTime = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (Time.time - lastClickTime < 0.3f)
        {
            ToggleBottle();
        }

        lastClickTime = Time.time;
    }

    void ToggleBottle()
    {
        isOpened = !isOpened;

        if (isOpened)
        {
            sr.sprite = openedSprite;
        }
        else
        {
            sr.sprite = closedSprite;
        }
    }
}