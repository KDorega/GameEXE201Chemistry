using System.Collections;
using UnityEngine;

public class ChaiNuocController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Sprite[] pourFrames;

    [Header("Spawn")]
    [SerializeField] private GameObject cocNuocPrefab;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip amThanhDoNuoc;

    [Range(0.5f, 3f)]
    [SerializeField] private float tocDoAmThanh = 1.5f;

    [SerializeField]
    private int soLanSuDung = 3;

    private Sprite spriteBanDau;
    private SpriteRenderer spriteRenderer;

    private bool dangDoNuoc;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteBanDau = spriteRenderer.sprite;

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public int SoLanSuDung
    {
        get { return soLanSuDung; }
    }

    public void KiemTraDoNuoc()
    {
        if (dangDoNuoc)
            return;

        Collider2D[] hits =
            Physics2D.OverlapCircleAll(
                transform.position,
                0.85f
            );

        foreach (Collider2D hit in hits)
        {
            CocRongController coc =
                hit.GetComponent<CocRongController>();

            if (coc == null)
                continue;

            StartCoroutine(
                DoNuoc(coc)
            );

            break;
        }
    }

    private IEnumerator DoNuoc(CocRongController coc)
    {
        dangDoNuoc = true;

        Vector3 viTriSpawn =
            coc.transform.position;

        coc.gameObject.SetActive(false);

        yield return StartCoroutine(
            PlayPourAnimation()
        );

        Instantiate(
            cocNuocPrefab,
            viTriSpawn,
            Quaternion.identity
        );

        Destroy(coc.gameObject);

        soLanSuDung--;

        if (soLanSuDung <= 0)
        {
            Destroy(gameObject);
        }

        dangDoNuoc = false;
    }

    public IEnumerator PlayPourAnimation()
    {
        // Bắt đầu âm thanh
        if (audioSource != null && amThanhDoNuoc != null)
        {
            audioSource.pitch = tocDoAmThanh;   // chỉnh tốc độ
            audioSource.clip = amThanhDoNuoc;
            audioSource.Play();
        }

        for (int i = 0; i < pourFrames.Length; i++)
        {
            spriteRenderer.sprite = pourFrames[i];

            yield return new WaitForSeconds(0.08f);
        }

        // Dừng âm thanh ngay khi hết hoạt ảnh
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.pitch = 1f;
        }

        spriteRenderer.sprite = spriteBanDau;
    }
}