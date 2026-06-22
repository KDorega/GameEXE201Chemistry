using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PracticeManager : MonoBehaviour
{
    public static PracticeManager instance;

    public GameObject nutExitLab;

    public GameObject thongBao;

    public TextMeshProUGUI diemSoText;

    private bool daLamBaCl2 = false;

    private bool daLamNaCl = false;

    private bool daLamCaCl2 = false;

    private bool daThongBao = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (diemSoText != null)
        {
            diemSoText.text = "Điểm: 0";
        }
    }

    void Update()
    {
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
                Physics2D.Raycast(
                    mousePos,
                    Vector2.zero
                );

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
    // BaCl2
    // =========================
    public void CompleteBaCl2()
    {
        daLamBaCl2 = true;

        CheckComplete();
    }

    // =========================
    // NaCl
    // =========================
    public void CompleteNaCl()
    {
        daLamNaCl = true;

        CheckComplete();
    }

    // =========================
    // CaCl2
    // =========================
    public void CompleteCaCl2()
    {
        daLamCaCl2 = true;

        CheckComplete();
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void SendPracticeComplete(int score);
#endif

    void CheckComplete()
    {
        int currentProgressScore =
            CalculateCurrentScore();

        if (diemSoText != null)
        {
            diemSoText.text =
                "Điểm: " +
                currentProgressScore;
        }

        if (
            daLamBaCl2 &&
            daLamNaCl &&
            daLamCaCl2 &&
            !daThongBao
        )
        {
            daThongBao = true;

            StartCoroutine(
                ShowNotificationDelay(4f)
            );
        }
        else
        {
            Debug.Log(
                $"[Tiến độ] Điểm hiện tại đạt được: {currentProgressScore}/100"
            );
        }
    }

    private int CalculateCurrentScore()
    {
        int completedCount = 0;

        if (daLamBaCl2) completedCount++;

        if (daLamNaCl) completedCount++;

        if (daLamCaCl2) completedCount++;

        if (completedCount == 1)
            return 33;

        if (completedCount == 2)
            return 66;

        if (completedCount == 3)
            return 100;

        return 0;
    }

    IEnumerator ShowNotificationDelay(
        float delayTime
    )
    {
        yield return new WaitForSeconds(
            delayTime
        );

        thongBao.SetActive(true);

        if (nutExitLab != null)
        {
            nutExitLab.SetActive(true);
        }

        Debug.Log(
            "HOAN THANH THUC HANH - ĐẠT ĐIỂM TỐI ĐA"
        );

        int score =
            CalculateCurrentScore();

        if (diemSoText != null)
        {
            diemSoText.text =
                "Điểm: " + score;
        }

#if UNITY_WEBGL && !UNITY_EDITOR
        SendPracticeComplete(score);
#else
        Debug.Log(
            $"[Mock WebGL] Gửi điểm hoàn thành: {score}"
        );
#endif
    }
}