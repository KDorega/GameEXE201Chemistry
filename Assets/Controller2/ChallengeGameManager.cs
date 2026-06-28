using TMPro;
using UnityEngine;

public class ChallengeGameManager : MonoBehaviour
{
    public static ChallengeGameManager Instance;

    [SerializeField]
    private TMP_Text diemText;

    [SerializeField]
    private TMP_Text thoiGianText;

    [SerializeField]
    public AudioClip nhacChienThang; // Kéo file nhạc thắng vào ô này ở Inspector
    
    [SerializeField]
    public AudioClip nhacNenManTiepTheo; // Kéo file nhạc màn chơi tiếp theo vào đây

    private int diem = 100;

    private float thoiGian = 30f;

    private bool dangChay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CapNhatUI();
    }

    private bool daLuuDiem;

    private void Update()
    {
        if (!dangChay)
            return;

        thoiGian -= Time.deltaTime;

        if (thoiGian <= 0)
        {
            thoiGian = 0;
            dangChay = false;
            
            CapNhatUI();

            if (!daLuuDiem)
            {
                LuuDiem();
                ThangManChoi();
            }
            return;
        }

        CapNhatUI();
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void SendPracticeComplete(int score);
#endif

    private void LuuDiem()
    {
        daLuuDiem = true;

#if UNITY_WEBGL && !UNITY_EDITOR
        SendPracticeComplete(diem);
#else
        Debug.Log(
            $"[Mock WebGL] Gửi điểm hoàn thành Challenge (qua SendPracticeComplete): {diem}"
        );
#endif
    }

    public void BatDauDemNguoc()
    {
        dangChay = true;
    }

    public void TruDiem(int soDiem)
    {
        diem -= soDiem;

        if (diem < 0)
            diem = 0;

        CapNhatUI();
    }

    private void CapNhatUI()
    {
        diemText.text =
            "Điểm: " + diem;

        thoiGianText.text =
            "Thời gian: " +
            Mathf.CeilToInt(thoiGian);
    }

    public void ThangManChoi()
    {
        // 1. Gọi dòng này để AudioManager đổi nhạc xuyên suốt quá trình chuyển cảnh
        BackgroundMusic.instance.PlayVictoryAndChangeMusic(nhacChienThang, nhacNenManTiepTheo);

        // 2. Tiến hành chuyển Scene sang màn chơi phụ hoặc màn tiếp theo
        // UnityEngine.SceneManagement.SceneManager.LoadScene("TenManChoiPhu");
    }

    public void ResetGame()
    {
        diem = 100;

        thoiGian = 30f;

        dangChay = true;
        
        daLuuDiem = false;

        CapNhatUI();
    }
}