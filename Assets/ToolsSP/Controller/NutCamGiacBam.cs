using UnityEngine;
using UnityEngine.InputSystem;

public class NutCamGiacBam : MonoBehaviour
{
    public GameObject oDungDoCongCu;

    public GameObject o_CocNuoc;

    public GameObject o_BaO;

    public GameObject o_Na2O;

    public BoxCollider2D tuCollider;

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

            // HIỆN COCNUOC
            o_CocNuoc.SetActive(true);

            // ẨN HÓA CHẤT
            o_BaO.SetActive(false);

            o_Na2O.SetActive(false);

            tuCollider.enabled = false;
        }
        else
        {
            sr.color = Color.white;

            oDungDoCongCu.SetActive(false);

            tuCollider.enabled = true;
        }
    }
}