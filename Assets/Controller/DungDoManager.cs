using UnityEngine;

public class DungDoManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject oDungDoCongCu;

    [Header("Items")]
    public GameObject o_CocNuoc;

    public GameObject o_BaO;

    public GameObject o_Na2O;
    public GameObject o_HCL;
    public GameObject o_CocRong;
    public GameObject o_CaO;
    public GameObject nutLayLoOngNghiemObject;

    public GameObject nutLoDungHoaChatObject;
    public GameObject o_KhayDungHoaChat;
    public GameObject nutBamX;
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
        o_KhayDungHoaChat.SetActive(true);
        o_CocRong.SetActive(true);
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

        o_HCL.SetActive(true);

        o_CaO.SetActive(true);

        // Đổi màu nút
        nutLoDungHoaChat.color = darkColor;

        // Tắt collider tủ
        tuCollider.enabled = false;


    }
    public void CloseInventory()
    {
        // Ẩn toàn bộ item
        ResetAll();

        // Ẩn 2 nút tab
        nutLayLoOngNghiemObject.SetActive(false);

        nutLoDungHoaChatObject.SetActive(false);

        nutBamX.SetActive(false);
        // Bật lại collider của tủ
        tuCollider.enabled = true;
    }
    // =========================
    // RESET TOÀN BỘ
    // =========================
    void ResetAll()
    {
        // Ẩn toàn bộ item
        oDungDoCongCu.SetActive(false);
        o_KhayDungHoaChat.SetActive(false);
        o_CocNuoc.SetActive(false);
        o_CocRong.SetActive(false);
        o_HCL.SetActive(false);
        o_BaO.SetActive(false);
        o_CaO.SetActive(false);
        o_Na2O.SetActive(false);

        // Reset màu nút
        nutLayLoOngNghiem.color = Color.white;

        nutLoDungHoaChat.color = Color.white;
    }
}