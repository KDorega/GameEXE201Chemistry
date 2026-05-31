using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; // THÊM DÒNG NÀY ĐỂ DÙNG COROUTINE

public class PracticeManager : MonoBehaviour
{
    public static PracticeManager instance;
    public GameObject nutExitLab;
    public GameObject thongBao;

    private bool daLamBaO = false;

    private bool daLamNa2O = false;

    private bool daThongBao = false;

    void Awake()
    {
        instance = this;
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
            Vector2 mousePos =
                Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            RaycastHit2D hit =
                Physics2D.Raycast(mousePos, Vector2.zero);

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
    // KIỂM TRA HOÀN THÀNH
    // =========================
#if UNITY_WEBGL && !UNITY_EDITOR
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void SendPracticeComplete(int score);
#endif

    void CheckComplete()
    {
        if (
            daLamBaO &&
            daLamNa2O &&
            !daThongBao
        )
        {
            // Đánh dấu là đã thông báo ngay lập tức để không bị gọi trùng lặp lại nhiều lần
            daThongBao = true;

            // Gọi hàm đợi 2 giây
            StartCoroutine(ShowNotificationDelay(4f));
        }
    }

    // Hàm đếm ngược thời gian
    IEnumerator ShowNotificationDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        thongBao.SetActive(true);

        if (nutExitLab != null)
        {
            nutExitLab.SetActive(true);
        }

        Debug.Log("HOAN THANH THUC HANH");

        int score = 100;

#if UNITY_WEBGL && !UNITY_EDITOR
    SendPracticeComplete(score);
#else
        Debug.Log($"[Mock WebGL] Gửi điểm: {score}");
#endif
    }
}