using UnityEngine;

public class TuDungCongCuController : MonoBehaviour
{
    [Header("Các object hiện khi mở")]
    [SerializeField] private GameObject oChucCacCongCu;
    [SerializeField] private GameObject oCocRong;
    [SerializeField] private GameObject oKhayDungHoaChat;
    [SerializeField] private GameObject oGangTay;
    [SerializeField] private GameObject oLoHCL;
    [SerializeField] private GameObject nutX;

    private bool daMo;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        if (!TutorialManager.Instance.CoDuocClick(gameObject))
            return;

        if (daMo)
            return;

        daMo = true;

        oChucCacCongCu.SetActive(true);
        oCocRong.SetActive(true);
        oKhayDungHoaChat.SetActive(true);
        oGangTay.SetActive(true);
        oLoHCL.SetActive(true);

        if (boxCollider != null)
            boxCollider.enabled = false;

        if (nutX != null)
            nutX.SetActive(true);

        TutorialManager.Instance.HoanThanhMoTu();

        Debug.Log("Đã mở tủ.");
    }

    public void DongTu()
    {
        daMo = false;

        oChucCacCongCu.SetActive(false);
        oCocRong.SetActive(false);
        oKhayDungHoaChat.SetActive(false);
        oGangTay.SetActive(false);
        oLoHCL.SetActive(false);

        if (boxCollider != null)
            boxCollider.enabled = true;
    }
}