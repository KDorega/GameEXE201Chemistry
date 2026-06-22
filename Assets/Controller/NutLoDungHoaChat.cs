using UnityEngine;
using UnityEngine.InputSystem;

public class NutLoDungHoaChat : MonoBehaviour
{
    public GameObject oDungDoCongCu;

    public GameObject o_CocNuoc;

    public GameObject o_BaO;

    public GameObject o_Na2O;

    private SpriteRenderer sr;

    private bool isPressed = false;

    private Color32 darkColor =
        new Color32(45, 45, 45, 255);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.color = Color.white;
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
                ToggleButton();
            }
        }
    }

    void ToggleButton()
    {
        isPressed = !isPressed;

        if (isPressed)
        {
            sr.color = darkColor;

            oDungDoCongCu.SetActive(true);

            // ẨN COCNUOC
            o_CocNuoc.SetActive(false);

            // HIỆN HÓA CHẤT
            o_BaO.SetActive(true);

            o_Na2O.SetActive(true);
        }
        else
        {
            sr.color = Color.white;

            // Khi tắt tab hóa chất
            o_BaO.SetActive(false);

            o_Na2O.SetActive(false);
        }
    }
}