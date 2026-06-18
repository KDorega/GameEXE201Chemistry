using UnityEngine;

public class KhayDungHoaChatController : MonoBehaviour
{
    private float lastClickTime;
    private float doubleClickTime = 0.3f;

    private void Start()
    {
        Transform viTri = transform.Find("ViTriDatHoaChat");

        if (viTri != null)
        {
            HoaChatSpawnManager.Instance.viTriDatHoaChat = viTri;
        }
    }

    private void OnMouseDown()
    {
        if (Time.time - lastClickTime < doubleClickTime)
        {
            BatTatKhayHoaChat();
        }

        lastClickTime = Time.time;
    }

    private void BatTatKhayHoaChat()
    {
        bool trangThaiMoi =
            !HoaChatUIManager.Instance.oCacHoaChat.activeSelf;

        HoaChatUIManager.Instance.oCacHoaChat.SetActive(trangThaiMoi);
        HoaChatUIManager.Instance.oBaO.SetActive(trangThaiMoi);
        HoaChatUIManager.Instance.oCaO.SetActive(trangThaiMoi);
        HoaChatUIManager.Instance.oNa2O.SetActive(trangThaiMoi);

        // Báo Tutorial rằng đã mở khay
        TutorialManager.Instance.HoanThanhMoKhay();
    }
}