using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("--- 4 Frame Thu Phóng ---")]
    [SerializeField] private Sprite[] animationFrames;

    [Header("--- UI Dấu Tích & Canvas Group ---")]
    [SerializeField] private CanvasGroup canvasGroupChue;

    [SerializeField] private GameObject tickBaO;
    [SerializeField] private GameObject tickNa2O;
    [SerializeField] private GameObject tickCaO;

    [HideInInspector] public bool isBaODone = false;
    [HideInInspector] public bool isNa2ODone = false;
    [HideInInspector] public bool isCaODone = false;

    private SpriteRenderer spriteRenderer;
    private QuestPanelMover mover;

    private bool isExpanded = false;
    private bool isAnimating = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        mover = GetComponent<QuestPanelMover>();
    }

    void Start()
    {
        if (animationFrames.Length >= 4)
        {
            spriteRenderer.sprite = animationFrames[3];
        }

        if (canvasGroupChue != null)
        {
            canvasGroupChue.alpha = 0f;
            canvasGroupChue.interactable = false;
            canvasGroupChue.blocksRaycasts = false;
        }

        UpdateTickDisplay();
    }

    void OnMouseUpAsButton()
    {
        if (isAnimating)
            return;

        if (
            mover != null &&
            mover.IsDragging()
        )
            return;

        isExpanded = !isExpanded;

        StartCoroutine(
            PlayFoldAnimation(isExpanded)
        );
    }

    IEnumerator PlayFoldAnimation(bool expand)
    {
        isAnimating = true;

        if (expand)
        {
            for (int i = 3; i >= 0; i--)
            {
                spriteRenderer.sprite =
                    animationFrames[i];

                yield return new WaitForSeconds(0.04f);
            }

            if (canvasGroupChue != null)
            {
                canvasGroupChue.alpha = 1f;
                canvasGroupChue.interactable = true;
                canvasGroupChue.blocksRaycasts = true;
            }

            UpdateTickDisplay();
        }
        else
        {
            if (canvasGroupChue != null)
            {
                canvasGroupChue.alpha = 0f;
                canvasGroupChue.interactable = false;
                canvasGroupChue.blocksRaycasts = false;
            }

            for (int i = 0; i <= 3; i++)
            {
                spriteRenderer.sprite =
                    animationFrames[i];

                yield return new WaitForSeconds(0.04f);
            }
        }

        isAnimating = false;
    }

    public void UpdateTickDisplay()
    {
        if (tickBaO)
            tickBaO.SetActive(isBaODone);

        if (tickNa2O)
            tickNa2O.SetActive(isNa2ODone);

        if (tickCaO)
            tickCaO.SetActive(isCaODone);
    }

    public void CompleteChemical(string name)
    {
        if (PracticeManager.instance == null)
            return;

        switch (name.ToUpper())
        {
            case "BAO":
                isBaODone = true;
                PracticeManager.instance.CompleteBaCl2();
                break;

            case "NA2O":
                isNa2ODone = true;
                PracticeManager.instance.CompleteNaCl();
                break;

            case "CAO":
                isCaODone = true;
                PracticeManager.instance.CompleteCaCl2();
                break;
        }

        UpdateTickDisplay();
    }
}