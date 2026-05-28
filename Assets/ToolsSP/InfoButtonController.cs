using UnityEngine;
using UnityEngine.InputSystem;

public class InfoButtonController : MonoBehaviour
{
    private GameObject banGiaithichDayDu;

    private SpriteRenderer sr;

    private Color32 darkColor =
        new Color32(45, 45, 45, 255);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.color = Color.white;

        // Tự tìm bảng
        banGiaithichDayDu =
            GameObject.Find("BanGiaithichDayDu");
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
        if (banGiaithichDayDu == null)
            return;

        // Nếu đang mở
        if (banGiaithichDayDu.activeSelf)
        {
            banGiaithichDayDu.SetActive(false);

            sr.color = Color.white;
        }

        // Nếu đang đóng
        else
        {
            banGiaithichDayDu.SetActive(true);

            sr.color = darkColor;
        }
    }
}   