using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [Header("UI")]
    [SerializeField] private GameObject thoaiChoAI;
    [SerializeField] private TMP_Text textThoai;
    [SerializeField] private GameObject muiTenHuongDan;

    [Header("Button")]
    [SerializeField] private GameObject nutThuThach;
    [SerializeField] private GameObject nutExit;

    [Header("Tutorial")]
    [SerializeField] private Transform tuDungCongCu;
    [SerializeField] private Transform tuDungCongCuArrowPoint;
    [SerializeField] private Transform gangTay;
    [SerializeField] private Transform gangTayArrowPoint;

    [SerializeField] private Transform oKhayDungHoaChat;
    [SerializeField] private Transform oKhayDungHoaChatArrowPoint;
    [SerializeField] private Transform viTriDatKhayDung;
    [SerializeField] private Transform viTriDatKhayDungArrowPoint;
    [SerializeField] private Transform oBaO;
    [SerializeField] private Transform oBaOArrowPoint;

    [SerializeField] private Transform oCocRong;
    [SerializeField] private Transform oCocRongArrowPoint;

    [SerializeField] private Transform viTriDatCoc;
    [SerializeField] private Transform viTriDatCocArrowPoint;
    [SerializeField] private Transform voiNuoc;
    [SerializeField] private Transform voiNuocArrowPoint;

    private Transform mucTieuHienTai;
    private Transform arrowPoint;
    private GameObject cocDangSpawn;
    private int buoc = 0;
    private bool dangChoXemThongTin;
    public bool DangTutorial { get; private set; }
    public bool ChoPhepTuongTac { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public bool CoDuocBamNutX()
    {
        return !DangTutorial;
    }
    private void Start()
    {
        DangTutorial = true;
        ChoPhepTuongTac = false;

        muiTenHuongDan.SetActive(false);

        nutThuThach.SetActive(false);
        nutExit.SetActive(true); 

        StartCoroutine(BatDauTutorial());
    }

    private IEnumerator BatDauTutorial()
    {
        yield return new WaitForSeconds(1f);

        HienThoai("Chào mừng bạn đến với phòng thí nghiệm hóa học. Hãy nhấn tiếp 1 lần lấn");
    }

    private void Update()
    {
        if(buoc == 0)
    {
            if (Input.GetMouseButtonDown(0))
            {
                ClickThoai();
            }
        }

        if (!muiTenHuongDan.activeSelf)
            return;

        if (arrowPoint == null)
            return;

        float x = Mathf.Sin(Time.time * 5f) * 0.15f;

        muiTenHuongDan.transform.position =
            arrowPoint.position +
            new Vector3(x, 0, 0);
    }

    public void ClickThoai()
    {
        if (buoc != 0)
            return;

        buoc = 1;

        HienThoai("Hãy nhấn vào tủ đựng dụng cụ.");

        DatMucTieu(
            tuDungCongCu,
            tuDungCongCuArrowPoint
        );

        ChoPhepTuongTac = true;
    }

    public void DatMucTieu(
        Transform mucTieu,
        Transform diemMuiTen)
    {
        mucTieuHienTai = mucTieu;
        arrowPoint = diemMuiTen;

        muiTenHuongDan.SetActive(true);
    }

    public bool CoDuocClick(GameObject obj)
    {
        if (!DangTutorial) return true; 
        if (!ChoPhepTuongTac) return false; 
        if (mucTieuHienTai == null) return false; 

        
        return obj.transform == mucTieuHienTai || obj.transform.root == mucTieuHienTai.root;
    }

    public void HoanThanhMoTu()
    {
        if (buoc != 1)
            return;

        buoc = 2;

        muiTenHuongDan.SetActive(false);

        arrowPoint = null;

        mucTieuHienTai = null;

        StartCoroutine(HuongDanGangTay());
    }
    private IEnumerator HuongDanGangTay()
    {
        yield return new WaitForSeconds(1f);

        HienThoai(
            "Để đảm bảo an toàn trong phòng thí nghiệm.\n"+
            "hãy đeo găng tay trước khi thực hiện thí nghiệm."
        );

        DatMucTieu(
            gangTay,
            gangTayArrowPoint
        );
    }
    public void HoanThanhLayGangTay()
    {
        if (buoc != 2)
            return;

        buoc = 3;

        muiTenHuongDan.SetActive(false);

        arrowPoint = null;

        mucTieuHienTai = null;

        StartCoroutine(HuongDanLayKhay());
    }
    private IEnumerator HuongDanLayKhay()
    {
        yield return new WaitForSeconds(1f);

        HienThoai(
            "Rất tốt! Bây giờ hãy lấy khay đựng hóa chất."
        );

        DatMucTieu(
            oKhayDungHoaChat,
            oKhayDungHoaChatArrowPoint
        );
    }
    public void HoanThanhLayKhay(GameObject khay)
    {
        if (buoc != 3)
            return;

        buoc = 4;

        StartCoroutine(HuongDanMoKhay(khay));
    }
    private IEnumerator HuongDanMoKhay(GameObject khay)
    {
        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        yield return new WaitForSeconds(1f);

        HienThoai("Hãy nhấp 2 lần vào khay đựng hóa chất trên bàn để mở danh sách hóa chất.");

        DatMucTieu(
            viTriDatKhayDung,
            viTriDatKhayDungArrowPoint
        );
    }
    private void HienThoai(string noiDung)
    {
        thoaiChoAI.SetActive(true);

        textThoai.text = noiDung;
    }
    public void HoanThanhMoKhay()
    {
        if (buoc != 4)
            return;

        buoc = 5;

        StartCoroutine(HuongDanChonBaO());
    }
    private IEnumerator HuongDanChonBaO()
    {
        muiTenHuongDan.SetActive(false);

        arrowPoint = null;

        mucTieuHienTai = null;

        yield return new WaitForSeconds(1f);

        HienThoai("Hãy chọn hóa chất BaO.");

        DatMucTieu(
            oBaO,
            oBaOArrowPoint
        );
    }
    public void HoanThanhLayBaO()
    {
        if (buoc != 5)
            return;

        buoc = 6;

        StartCoroutine(HuongDanLayCoc());
    }
    private IEnumerator HuongDanLayCoc()
    {
        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        yield return new WaitForSeconds(1f);

        HienThoai(
            "Rất tốt! Bây giờ hãy lấy một chiếc cốc rỗng."
        );

        DatMucTieu(
            oCocRong,
            oCocRongArrowPoint
        );
    }
    public void HoanThanhLayCoc(GameObject coc)
    {
        if (buoc != 6)
            return;

        cocDangSpawn = coc;

        buoc = 7;

        StartCoroutine(HuongDanDatCoc());
    }

    public void HoanThanhClickCoc(GameObject obj)
    {
        if (buoc != 7)
            return;

        if (obj != cocDangSpawn)
            return;

        

        StartCoroutine(HuongDanDatCoc());
    }
    
    private IEnumerator HuongDanDatCoc()
    {
        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        yield return new WaitForSeconds(1f);

        HienThoai("Hãy kéo chiếc cốc xuống dưới vòi nước.");

        DatMucTieu(
            cocDangSpawn.transform,
            voiNuocArrowPoint
        );
    }
    public void HoanThanhDatCoc()
    {
        

        if (buoc != 7)
        {
            
            return;
        }

        buoc = 8;

        StartCoroutine(HuongDanMoVoiNuoc());
    }
    private IEnumerator HuongDanMoVoiNuoc()
    {
        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        yield return new WaitForSeconds(1f);

        HienThoai(
            "Tốt lắm! Bây giờ hãy click vào vòi nước để lấy nước."
        );

        DatMucTieu(
            voiNuoc,
            voiNuocArrowPoint
        );
    }

    public void HoanThanhLayNuoc(GameObject cocNuoc)
    {
        if (buoc != 8)
            return;

        buoc = 9;

        StartCoroutine(HuongDanKetThuc());
    }

    private IEnumerator HuongDanKetThuc()
    {
        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        yield return new WaitForSeconds(1f);

        HienThoai(
            "Tốt lắm! Bạn đã có một cốc nước.\n" +
            "Hãy thử cho BaO vào cốc nước để quan sát phản ứng."
        );

        Transform bao = GameObject.FindGameObjectWithTag("BaO").transform;

        Transform arrow =
            bao.Find("ArrowPoint");

        DatMucTieu(
            bao,
            arrow
        );
    }
    public void HoanThanhPhanUngBaO()
    {
        StartCoroutine(HuongDanThuNghiemTuDo());
    }
    private IEnumerator HuongDanThuNghiemTuDo()
    {
        yield return new WaitForSeconds(1f);

        HienThoai(
            "Rất tốt! Như bạn đã thấy phản ứng đã xảy ra.\n"+ 
            "Chúc mừng bạn đã hoàn thành hướng dẫn."
        );

        DangTutorial = false;
        ChoPhepTuongTac = true;

        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(HuongDanHoanTatThiNghiem());
    }
    private IEnumerator HuongDanHoanTatThiNghiem()
    {
        yield return new WaitForSeconds(1f);

        HienThoai(
            
            "Giờ đưa găng tay vào sẽ thấy thông tin sản phẩm.\n"+
            "Bây giờ hãy thử tự do kết hợp các hóa chất khác để khám phá thêm."
        );

        DangTutorial = false;
        ChoPhepTuongTac = true;

        muiTenHuongDan.SetActive(false);

        arrowPoint = null;
        mucTieuHienTai = null;

        dangChoXemThongTin = true;
        yield return new WaitForSeconds(2f);

        thoaiChoAI.SetActive(false);
        nutThuThach.SetActive(true);
    }
    public void HoanThanhXemThongTin()
    {
        if (!dangChoXemThongTin)
            return;

        dangChoXemThongTin = false;

        thoaiChoAI.SetActive(false);
    }
}