using System.Collections;
using UnityEngine;

public class CocNuocController : MonoBehaviour
{
    [Header("Frame BaO")]
    [SerializeField] private Sprite[] baOFrames;

    [Header("Frame CaO")]
    [SerializeField] private Sprite[] caOFrames;

    [Header("Frame Na2O")]
    [SerializeField] private Sprite[] na2OFrames;
    [Header("Âm thanh")]
    [SerializeField] private AudioClip baOAudio;

    [SerializeField] private AudioClip caOAudio;

    [SerializeField] private AudioClip na2OAudio;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private TooltipObject tooltipObject;
    private bool dangPhanUng;
    private bool daPhanUng;
    private bool laChatTotChoDat;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        tooltipObject = GetComponent<TooltipObject>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dangPhanUng || daPhanUng)
            return;

        if (other.CompareTag("BaO"))
        {
            Destroy(other.gameObject);
            laChatTotChoDat = false;
            StartCoroutine(ChayHoatAnh(baOFrames, baOAudio,
                "Ba(OH)<sub>2</sub> (Bari hiđroxit - Barium hydroxide)\n" +
                "Công thức hóa học BaO + H<sub>2</sub>O <size=200%>→</size>Ba(OH)<sub>2</sub>\n" +
                "Hiện tượng: Chất rắn BaO màu trắng tan dần trong nước,phản ứng tỏa rất nhiều nhiệt."+
                "Tính chất: Cực kỳ độc, có tính ăn mòn rất cao và <color=red>Khó sử dụng</color>."));
            if (TutorialManager.Instance != null)
            {
                TutorialManager.Instance
                    .HoanThanhPhanUngBaO();
            }
        }

        if (other.CompareTag("CaO"))
        {
            Destroy(other.gameObject);
            laChatTotChoDat = true;
            StartCoroutine(ChayHoatAnh(
                caOFrames, caOAudio,
                "Ca(OH)<sub>2</sub> (Canxi hiđroxit - Nước vôi trong)\n" +
                "Công thức hóa học: CaO + H<sub>2</sub>O <size=200%>→</size> Ca(OH)<sub>2</sub>\n" +
                "Hiện tượng: Chất rắn CaO màu trắng tan dần, phản ứng tỏa rất nhiều nhiệt, làm nước sôi lên."+
                "Tính chất: Khử chua tốt, dễ sử dụng."
            ));
        }

        if (other.CompareTag("Na2O"))
        {
            Destroy(other.gameObject);
            laChatTotChoDat = false;
            StartCoroutine(ChayHoatAnh(
                na2OFrames, na2OAudio,
                "NaOH (Natri hiđroxit - Xút ăn da)\n" +
                "Công thức hóa học: Na<sub>2</sub>O + H<sub>2</sub>O <size=200%>→</size> 2NaOH\n" +
                "Hiện tượng: Chất rắn Na<sub>2</sub>O màu trắng tan nhanh trong nước, phản ứng tỏa nhiệt mạnh."+
                "Tính chất: Độc, ăn mòn và <color=red>Khó sử dụng</color>."
            ));       
    }
    }

    private IEnumerator ChayHoatAnh(
    Sprite[] frames,
    AudioClip amThanh,
    string thongTin)
    {
        dangPhanUng = true;

        if (audioSource != null &&
            amThanh != null)
        {
            audioSource.clip = amThanh;
            audioSource.Play();
        }

        for (int i = 0; i < frames.Length; i++)
        {
            spriteRenderer.sprite = frames[i];

            yield return new WaitForSeconds(0.1f);
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        tooltipObject.SetNoiDung(thongTin);

        dangPhanUng = false;

        daPhanUng = true;
    }
    public bool LaChatTotChoDat
    {
        get { return laChatTotChoDat; }
    }

    public bool DaPhanUng
    {
        get { return daPhanUng; }
    }
}