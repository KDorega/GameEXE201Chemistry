using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    private static BanGiaithichAnimation bangGiaiThich;

    private SpriteRenderer sr;
    private static InfoButton currentButton;
    private ReactionFrames reactionFrames;
    private HCLCupReaction hclReaction;
    private Color32 darkColor = new Color32(45, 45, 45, 255);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        reactionFrames = GetComponentInParent<ReactionFrames>();
        hclReaction =GetComponentInParent<HCLCupReaction>();
        sr.color = Color.white;

        if (bangGiaiThich == null)
        {
            bangGiaiThich =
                FindObjectOfType<BanGiaithichAnimation>(true);
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
        if (currentButton == this)
        {
            currentButton = null;

            sr.color = Color.white;

            bangGiaiThich.Toggle();

            return;
        }

        if (currentButton != null)
        {
            currentButton.sr.color = Color.white;
        }

        currentButton = this;

        sr.color = darkColor;

        // ======================
        // Cốc nước
        // ======================
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
            else if (type == "CaO")
            {
                ReactionInfoManager.instance.ShowCaOInfo();
            }
        }

        // ======================
        // Cốc HCl
        // ======================
        else if (hclReaction != null)
        {
            string type = hclReaction.GetReactionType();

            if (type == "BaCl2")
            {
                ReactionInfoManager.instance.ShowBaCl2Info();
            }
            else if (type == "NaCl")
            {
                ReactionInfoManager.instance.ShowNaClInfo();
            }
            else if (type == "CaCl2")
            {
                ReactionInfoManager.instance.ShowCaCl2Info();
            }
        }

        if (!bangGiaiThich.IsOpen())
        {
            bangGiaiThich.Toggle();
        }
    }
}