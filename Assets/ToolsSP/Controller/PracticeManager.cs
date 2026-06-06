using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // THÊM DÒNG NÀY ĐỂ SỬ DỤNG TEXTMESHPRO

public class PracticeManager : MonoBehaviour
{
    public static PracticeManager instance;
    public GameObject nutExitLab;
    public GameObject thongBao; // Đây chính là TThongbaoE của bạn

    // ===== BỔ SUNG: Ô chứa linh hồn hiển thị Text trên màn hình =====
    public TextMeshProUGUI diemSoText;

    private bool daLamBaO = false;
    private bool daLamNa2O = false;

    // ===== BỔ SUNG: Trạng thái hoàn thành của CaO =====
    private bool daLamCaO = false;

    private bool daThongBao = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Khởi tạo đầu game, đảm bảo text hiển thị là 0 điểm
        if (diemSoText != null)
        {
            diemSoText.text = "Điểm: 0";
        }
    }

    void Update()
    {
        // Click tắt thông báo
        if (
            daThongBao &&
            thongBao.activeSelf &&
            Mouse.current.leftButton.wasPressedThisFrame
        )
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (
                hit.collider != null &&
                hit.collider.gameObject == thongBao
            )
            {
                thongBao.SetActive(false);
            }
        }
    }

    // =========================
    // BAO
    // =========================
    public void CompleteBaO()
    {
        daLamBaO = true;
        CheckComplete();
    }

    // =========================
    // NA2O
    // =========================
    public void CompleteNa2O()
    {
        daLamNa2O = true;
        CheckComplete();
    }

    // =========================
    // ===== BỔ SUNG: CAO =====
    // =========================
    public void CompleteCaO()
    {
        daLamCaO = true;
        CheckComplete();
    }

    // =========================
    // KIỂM TRA HOÀN THÀNH
    // =========================
#if UNITY_WEBGL && !UNITY_EDITOR
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void SendPracticeComplete(int score);
#endif

    void CheckComplete()
    {
        // Tính toán và hiển thị điểm cập nhật theo thời gian thực ra UI màn hình
        int currentProgressScore = CalculateCurrentScore();
        if (diemSoText != null)
        {
            diemSoText.text = "Điểm: " + currentProgressScore;
        }

        // ===== CẬP NHẬT ĐIỀU KIỆN: Người chơi phải làm đủ cả 3 chất BaO, Na2O và CaO =====
        if (
            daLamBaO &&
            daLamNa2O &&
            daLamCaO &&
            !daThongBao
        )
        {
            daThongBao = true;
            StartCoroutine(ShowNotificationDelay(4f));
        }
        else
        {
            // Cập nhật tiến trình điểm thử nghiệm lên Console để kiểm thử nhanh
            Debug.Log($"[Tiến độ] Điểm hiện tại đạt được: {currentProgressScore}/100");
        }
    }

    // Hàm bổ sung: Tính điểm động dựa trên số lượng chất thực tế đã hoàn thành
    private int CalculateCurrentScore()
    {
        int completedCount = 0;
        if (daLamBaO) completedCount++;
        if (daLamNa2O) completedCount++;
        if (daLamCaO) completedCount++;

        if (completedCount == 1) return 33;
        if (completedCount == 2) return 66;
        if (completedCount == 3) return 100;
        return 0;
    }

    // Hàm đếm ngược thời gian
    IEnumerator ShowNotificationDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        thongBao.SetActive(true); // Kích hoạt bảng thông báo chiến thắng thành công công việc

        if (nutExitLab != null)
        {
            nutExitLab.SetActive(true);
        }

        Debug.Log("HOAN THANH THUC HANH - ĐẠT ĐIỂM TỐI ĐA");

        int score = CalculateCurrentScore();
        if (diemSoText != null)
        {
            diemSoText.text = "Điểm: " + score;
        }

#if UNITY_WEBGL && !UNITY_EDITOR
    SendPracticeComplete(score);
#else
        Debug.Log($"[Mock WebGL] Gửi điểm hoàn thành: {score}");
#endif
    }
}