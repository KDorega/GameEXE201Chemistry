using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    private static GameObject bangGiaiThich;

    private static CanvasGroup canvasGroup;

    private SpriteRenderer sr;

    private ReactionFrames reactionFrames;
    // STATIC
    private static bool isOpen = false;

    private Color32 darkColor = new Color32(45, 45, 45, 255);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        reactionFrames = GetComponentInParent<ReactionFrames>();
        sr.color = Color.white;

        if (bangGiaiThich == null)
        {
            bangGiaiThich = GameObject.Find("BanGiaithichDayDu");

            canvasGroup = bangGiaiThich.GetComponent<CanvasGroup>();
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos =
                Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            RaycastHit2D hit =
                Physics2D.Raycast(mousePos, Vector2.zero);

            if (
                hit.collider != null &&
                hit.collider.gameObject == gameObject
            )
            {
                ToggleInfo();
            }
        }
    }

    void ToggleInfo()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            // ĐỔI TEXT ĐÚNG THEO CỐC
            if (reactionFrames != null)
            {
                string type = reactionFrames.GetReactionType();

                if (type == "BaO")
                {
                    ReactionInfoManager.instance.ShowBaOInfo();
                }
                else if (type == "Na2O")
                {
                    ReactionInfoManager.instance.ShowNa2OInfo();
                }
            }

            sr.color = darkColor;

            canvasGroup.alpha = 1;

            canvasGroup.interactable = true;

            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            sr.color = Color.white;

            canvasGroup.alpha = 0;

            canvasGroup.interactable = false;

            canvasGroup.blocksRaycasts = false;
        }
    }
}