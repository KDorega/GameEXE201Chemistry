using UnityEngine;

public class DungDoManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject oDungDoCongCu;

    [Header("Items")]
    public GameObject o_CocNuoc;

    public GameObject o_BaO;

    public GameObject o_Na2O;

    [Header("Buttons")]
    public SpriteRenderer nutLoDungHoaChat;

    public SpriteRenderer nutLayLoOngNghiem;

    [Header("Tu Collider")]
    public BoxCollider2D tuCollider;

    private Color32 darkColor =
        new Color32(45, 45, 45, 255);

    // =========================
    // TAB DỤNG CỤ
    // =========================
    public void OpenDungCu()
    {
        // RESET
        ResetAll();

        // MỞ UI
        oDungDoCongCu.SetActive(true);

        // HIỆN item
        o_CocNuoc.SetActive(true);

        // Đổi màu nút
        nutLayLoOngNghiem.color = darkColor;

        // Tắt collider tủ
        tuCollider.enabled = false;
    }

    // =========================
    // TAB HÓA CHẤT
    // =========================
    public void OpenHoaChat()
    {
        // RESET
        ResetAll();

        // MỞ UI
        oDungDoCongCu.SetActive(true);

        // HIỆN hóa chất
        o_BaO.SetActive(true);

        o_Na2O.SetActive(true);

        // Đổi màu nút
        nutLoDungHoaChat.color = darkColor;

        // Tắt collider tủ
        tuCollider.enabled = false;
    }

    // =========================
    // RESET TOÀN BỘ
    // =========================
    void ResetAll()
    {
        // Ẩn toàn bộ item
        oDungDoCongCu.SetActive(false);

        o_CocNuoc.SetActive(false);

        o_BaO.SetActive(false);

        o_Na2O.SetActive(false);

        // Reset màu nút
        nutLayLoOngNghiem.color = Color.white;

        nutLoDungHoaChat.color = Color.white;
    }
}