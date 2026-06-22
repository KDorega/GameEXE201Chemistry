using System.Collections;
using UnityEngine;

public class CocHCLController : MonoBehaviour
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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        tooltipObject = GetComponent<TooltipObject>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (tooltipObject != null)
        {
            tooltipObject.SetNoiDung("Cốc chứa dung dịch HCl. Thả BaO, CaO hoặc Na2O vào để quan sát phản ứng.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dangPhanUng || daPhanUng)
            return;

        if (other.CompareTag("BaO"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ChayHoatAnh(baOFrames, baOAudio,
                "BaCl<sub>2</sub> (Bari clorua)\n" +
                "Công thức: BaO + 2HCl → BaCl<sub>2</sub> + H<sub>2</sub>O\n" +
                "Hiện tượng: Chất rắn BaO tan dần trong dung dịch HCl, tạo thành dung dịch muối trắng."));
        }

        if (other.CompareTag("CaO"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ChayHoatAnh(
                caOFrames, caOAudio,
                "CaCl<sub>2</sub> (Canxi clorua)\n" +
                "Công thức: CaO + 2HCl → CaCl<sub>2</sub> + H<sub>2</sub>O\n" +
                "Hiện tượng: CaO phản ứng với HCl, tan dần và tạo dung dịch muối."
            ));
        }

        if (other.CompareTag("Na2O"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ChayHoatAnh(
                na2OFrames, na2OAudio,
                "NaCl (Natri clorua)\n" +
                "Công thức: Na<sub>2</sub>O + 2HCl → 2NaCl + H<sub>2</sub>O\n" +
                "Hiện tượng: Na2O tan nhanh trong HCl và tạo thành dung dịch muối."
            ));       
        }
    }

    private IEnumerator ChayHoatAnh(
        Sprite[] frames,
        AudioClip amThanh,
        string thongTin)
    {
        dangPhanUng = true;

        if (audioSource != null && amThanh != null)
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

    public bool DaPhanUng
    {
        get { return daPhanUng; }
    }
}
