using System.Collections;
using UnityEngine;

public class VoiNuocController : MonoBehaviour
{
    public static VoiNuocController Instance;

    [Header("Hoạt ảnh")]
    [SerializeField] private Sprite[] frames;
    [SerializeField] private Sprite spriteMacDinh;

    [Header("Prefab")]
    [SerializeField] private GameObject cocNuocPrefab;

    [Header("Âm thanh")]
    [SerializeField] private AudioClip amThanhNuocChay;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private CocRongController cocDangLayNuoc;

    private void Awake()
    {
        Instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();

        spriteRenderer.sprite = spriteMacDinh;
    }

    public void DatCoc(CocRongController coc)
    {
        cocDangLayNuoc = coc;
    }

    public void BoCoc()
    {
        cocDangLayNuoc = null;
    }

    private void OnMouseDown()
    {
        if (!TutorialManager.Instance.CoDuocClick(gameObject))
            return;

        if (cocDangLayNuoc == null)
            return;

        StartCoroutine(DoNuocCoroutine());
    }

    private IEnumerator DoNuocCoroutine()
    {
        Vector3 viTriCoc = Vector3.zero;

        if (cocDangLayNuoc != null)
        {
            viTriCoc = cocDangLayNuoc.transform.position;

            Destroy(cocDangLayNuoc.gameObject);

            cocDangLayNuoc = null;
        }

        // Bắt đầu phát tiếng nước
        if (audioSource != null && amThanhNuocChay != null)
        {
            audioSource.clip = amThanhNuocChay;
            audioSource.loop = true;
            audioSource.pitch = 3f;
            audioSource.Play();
        }

        // Chạy hoạt ảnh
        for (int i = 0; i < frames.Length; i++)
        {
            spriteRenderer.sprite = frames[i];

            yield return new WaitForSeconds(0.1f);
        }

        // Dừng tiếng nước
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        // Spawn cốc nước
        GameObject cocNuoc = Instantiate(
            cocNuocPrefab,
            viTriCoc,
            Quaternion.identity
        );

        spriteRenderer.sprite = spriteMacDinh;

        TutorialManager.Instance.HoanThanhLayNuoc(cocNuoc);
    }
}