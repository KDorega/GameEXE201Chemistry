using UnityEngine;

public class TooltipObject : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string noiDung;
    [SerializeField]
    private bool ketThucTutorial;
    private ChaiNuocController chaiNuoc;
    
    private void Awake()
    {
        chaiNuoc =
            GetComponent<ChaiNuocController>();
    }
    private void OnMouseEnter()
    {
        string textHienThi = noiDung;

        if (chaiNuoc != null)
        {
            textHienThi =
                "Chai nước\n" +
                "Số lần sử dụng còn lại: " +
                chaiNuoc.SoLanSuDung;
        }

        BangGiaiThichNhoController.Instance
            .HienBang(textHienThi);

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance
                .HoanThanhXemThongTin();
        }
    }

    private void OnMouseExit()
    {
        BangGiaiThichNhoController.Instance.AnBang();
    }
    public void SetNoiDung(string noiDungMoi)
    {
        noiDung = noiDungMoi;
    }
}