using UnityEngine;

public class NutDongController : MonoBehaviour
{
    [SerializeField] private GameObject oChucCacCongCu;
    [SerializeField] private GameObject oCocRong;
    [SerializeField] private GameObject oKhayDungHoaChat;
    [SerializeField] private GameObject oGangTay;
    [SerializeField] private TuDungCongCuController tuDungCongCu;
    private void OnMouseDown()
    {
        if (!TutorialManager.Instance.CoDuocBamNutX())
            return;

        if (oChucCacCongCu != null)
            oChucCacCongCu.SetActive(false);

        if (oCocRong != null)
            oCocRong.SetActive(false);

        if (oKhayDungHoaChat != null)
            oKhayDungHoaChat.SetActive(false);

        if (oGangTay != null)
            oGangTay.SetActive(false);
        
        if (tuDungCongCu != null)
            tuDungCongCu.DongTu();
        // Tắt chính nút X
        gameObject.SetActive(false);
    }
}