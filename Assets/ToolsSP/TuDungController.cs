using UnityEngine;
using UnityEngine.InputSystem;

public class TuDungController : MonoBehaviour
{
    public GameObject nutLayLoOngNghiem;
    public GameObject NutLoDungHoaChat;
    public GameObject oDungDoCongCu;

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
                hit.collider.gameObject == gameObject &&
                !oDungDoCongCu.activeSelf
            )
            {
                nutLayLoOngNghiem.SetActive(true);
                NutLoDungHoaChat.SetActive(true);
            }
        }
    }
}