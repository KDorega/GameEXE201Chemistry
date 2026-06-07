using System.Collections;
using UnityEngine;

public class BanGiaithichAnimation : MonoBehaviour
{
    public Sprite[] openFrames;

    private SpriteRenderer sr;

    private bool isOpen = false;

    private bool isAnimating = false;
    public GameObject textThongTin;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        sr.sprite = openFrames[0];

        if (textThongTin != null)
        {
            textThongTin.SetActive(false);
        }
    }
    public void Toggle()
    {
        if (isAnimating)
            return;

        if (isOpen)
        {
            StartCoroutine(CloseAnimation());
        }
        else
        {
            gameObject.SetActive(true);

            StartCoroutine(OpenAnimation());
        }
    }

    IEnumerator OpenAnimation()
    {
        isAnimating = true;

        for (int i = 0; i < openFrames.Length; i++)
        {
            sr.sprite = openFrames[i];

            yield return new WaitForSeconds(0.05f);
        }
        if (textThongTin != null)
        {
            textThongTin.SetActive(true);
        }
        isOpen = true;

        isAnimating = false;
    }

    IEnumerator CloseAnimation()
    {
        isAnimating = true;
        if (textThongTin != null)
        {
            textThongTin.SetActive(false);
        }
        for (int i = openFrames.Length - 1; i >= 0; i--)
        {
            sr.sprite = openFrames[i];

            yield return new WaitForSeconds(0.05f);
        }

        isOpen = false;

        isAnimating = false;

        
    }
    public bool IsOpen()
    {
        return isOpen;
    }
}