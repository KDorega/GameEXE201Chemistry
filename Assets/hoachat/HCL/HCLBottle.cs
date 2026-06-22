using System.Collections;
using UnityEngine;

public class HCLBottle : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openedSprite;

    [Header("Spawn")]
    public GameObject cocHCLPrefab;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip amThanhDoHCL;
    [Range(0.5f, 3f)]
    public float tocDoAmThanh = 1.5f;

    [SerializeField]
    private int soLanSuDung = 3;

    private SpriteRenderer sr;

    public bool isOpened = false;

    private bool dangDoNuoc = false;
    private float lastClickTime = 0f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (Time.time - lastClickTime < 0.3f)
        {
            ToggleBottle();
        }

        lastClickTime = Time.time;
    }

    void OnMouseUp()
    {
        KiemTraDoNuoc();
    }

    void ToggleBottle()
    {
        isOpened = !isOpened;

        if (isOpened)
        {
            sr.sprite = openedSprite;
        }
        else
        {
            sr.sprite = closedSprite;
        }
    }

    public void KiemTraDoNuoc()
    {
        if (dangDoNuoc || !isOpened || cocHCLPrefab == null)
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

            dangDoNuoc = true;
            StartCoroutine(DoNuoc(coc));
            break;
        }
    }

    private IEnumerator DoNuoc(CocRongController coc)
    {
        Vector3 viTriSpawn =
            coc.transform.position;

        coc.gameObject.SetActive(false);

        yield return StartCoroutine(
            PlayPourAnimation()
        );

        Instantiate(
            cocHCLPrefab,
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

    private IEnumerator PlayPourAnimation()
    {
        if (audioSource != null && amThanhDoHCL != null)
        {
            audioSource.pitch = tocDoAmThanh;
            audioSource.clip = amThanhDoHCL;
            audioSource.Play();
        }

        yield return new WaitForSeconds(0.4f);

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.pitch = 1f;
        }
    }
}