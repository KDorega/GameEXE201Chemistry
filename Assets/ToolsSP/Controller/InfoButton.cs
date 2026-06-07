using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    private static BanGiaithichAnimation bangGiaiThich;

    private SpriteRenderer sr;
    private static InfoButton currentButton;
    private ReactionFrames reactionFrames;
    
    private Color32 darkColor = new Color32(45, 45, 45, 255);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        reactionFrames = GetComponentInParent<ReactionFrames>();
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
        // Bấm lại chính nút đang mở
        if (currentButton == this)
        {
            currentButton = null;

            sr.color = Color.white;

            bangGiaiThich.Toggle();

            return;
        }

        // Nếu có nút khác đang mở
        if (currentButton != null)
        {
            currentButton.sr.color = Color.white;
        }

        currentButton = this;

        sr.color = darkColor;

        string type =
            reactionFrames.GetReactionType();

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

        // Chỉ mở bảng nếu bảng đang đóng
        if (!bangGiaiThich.IsOpen())
        {
            bangGiaiThich.Toggle();
        }
    }
}