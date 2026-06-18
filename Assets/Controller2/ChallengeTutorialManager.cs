using System.Collections;
using TMPro;
using UnityEngine;

public class ChallengeTutorialManager : MonoBehaviour
{
    public static ChallengeTutorialManager Instance;

    [Header("UI")]
    [SerializeField]
    private GameObject khungThoai;

    [SerializeField]
    private TMP_Text textThoai;

    [Header("Mui Ten")]
    [SerializeField]
    private GameObject muiTenHuongDan;

    [Header("Arrow Point")]
    [SerializeField]
    private Transform baloArrowPoint;

    [SerializeField]
    private Transform bangNhiemVuArrowPoint;

    [SerializeField]
    private Transform bangThoiGianArrowPoint;

    [SerializeField]
    private Transform nutIArrowPoint;
    [SerializeField]
    private GameObject nutPlay;
    private enum BuocTutorial
    {
        GioiThieu,
        ChoMoBalo,
        ChoDeoGangTay,
        ChoXemBangNhiemVu,
        ChoXemBangThoiGian,
        ChoBamNutI,
        HoanTat
    }

    private BuocTutorial buocHienTai;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        khungThoai.SetActive(false);

        muiTenHuongDan.SetActive(false);
        nutPlay.SetActive(false);
        buocHienTai =
            BuocTutorial.GioiThieu;

        StartCoroutine(
            BatDauTutorial()
        );
    }

    private IEnumerator BatDauTutorial()
    {
        yield return new WaitForSeconds(1f);

        HienThoai(
            "Cánh đồng đang bị đất chua (có tính axit).\n" +
            "Nếu không xử lý kịp thời cây trồng sẽ chết dần."
        );

        yield return new WaitForSeconds(2f);

        HienThoai(
            "Hãy mở balo để lấy dụng cụ.\n"+
            "Hãy bấm vào để xem"
        );

        HienMuiTen(
            baloArrowPoint
        );

        buocHienTai =
            BuocTutorial.ChoMoBalo;
    }

    public void HoanThanhMoBalo()
    {
        if (buocHienTai !=
            BuocTutorial.ChoMoBalo)
            return;

        muiTenHuongDan.SetActive(false);

        HienThoai(
            "Trước khi thao tác với hóa chất, hãy đeo găng tay bảo hộ.\n" +
            "Hãy bấm vào để xem"

        );

        buocHienTai =
            BuocTutorial.ChoDeoGangTay;
    }

    public void BaoChuaDeoGangTay()
    {
        if (buocHienTai !=
            BuocTutorial.ChoDeoGangTay)
            return;

        HienThoai(
            "Bạn nên đeo găng tay như đã làm ở phần hướng dẫn.\n" +
            "Hãy bấm vào để xem"
        );
    }

    public void HoanThanhDeoGangTay()
    {
        if (buocHienTai !=
            BuocTutorial.ChoDeoGangTay)
            return;

        HienThoai(
            "Đây là bảng nhiệm vụ. Hãy bấm vào để xem."
        );

        HienMuiTen(
            bangNhiemVuArrowPoint
        );

        buocHienTai =
            BuocTutorial.ChoXemBangNhiemVu;
    }

    public void HoanThanhXemBangNhiemVu()
    {
        if (buocHienTai !=
            BuocTutorial.ChoXemBangNhiemVu)
            return;

        HienThoai(
            "Đây là bảng thời gian. Bạn chỉ có 30 giây để hoàn thành thử thách.\n" +
            "Hãy bấm vào để xem"
        );

        HienMuiTen(
            bangThoiGianArrowPoint
        );

        buocHienTai =
            BuocTutorial.ChoXemBangThoiGian;
    }

    public void HoanThanhXemBangThoiGian()
    {
        if (buocHienTai !=
            BuocTutorial.ChoXemBangThoiGian)
            return;

        HienThoai(
            "Nếu quên luật chơi, hãy nhấn vô i để xem lại hướng dẫn.\n" +
            "Hãy bấm vào để xem"
        );

        HienMuiTen(
            nutIArrowPoint
        );

        buocHienTai =
            BuocTutorial.ChoBamNutI;
    }

    public void HoanThanhBamNutI()
    {
        if (buocHienTai !=
            BuocTutorial.ChoBamNutI)
            return;

        HienThoai(
            "Rất tốt! Bây giờ hãy bắt đầu cứu cánh đồng."
        );

        muiTenHuongDan.SetActive(false);
        nutPlay.SetActive(true);
        if (ChallengeGameManager.Instance != null)
        {
            ChallengeGameManager.Instance
                .BatDauDemNguoc();
        }

        buocHienTai =
            BuocTutorial.HoanTat;

        StartCoroutine(
            KetThucTutorial()
        );
    }

    private IEnumerator KetThucTutorial()
    {
        yield return new WaitForSeconds(3f);

        khungThoai.SetActive(false);
    }

    private void HienThoai(
        string noiDung)
    {
        khungThoai.SetActive(true);

        textThoai.text =
            noiDung;
    }

    private void HienMuiTen(
        Transform arrowPoint)
    {
        muiTenHuongDan.SetActive(true);

        muiTenHuongDan.transform.position =
            arrowPoint.position;
    }
    public bool CoDuocClick(GameObject obj)
    {
        // Sau khi hoàn thành tutorial thì click gì cũng được
        if (buocHienTai == BuocTutorial.HoanTat)
            return true;

        // Nút Exit luôn được phép
        if (obj.CompareTag("NutExit"))
            return true;

        switch (buocHienTai)
        {
            case BuocTutorial.ChoMoBalo:
                return obj.CompareTag("Balo");

            case BuocTutorial.ChoDeoGangTay:
                return obj.CompareTag("O_GangTay");

            case BuocTutorial.ChoXemBangNhiemVu:
                return obj.CompareTag("BangNhiemVu");

            case BuocTutorial.ChoXemBangThoiGian:
                return obj.CompareTag("BangThoiGian");

            case BuocTutorial.ChoBamNutI:
                return obj.CompareTag("NutThongtinE");
        }

        return false;
    }
}