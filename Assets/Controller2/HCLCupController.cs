using System.Collections;
using UnityEngine;

public class HCLCupController : MonoBehaviour
{
    [Header("Reaction Frames")]
    public Sprite[] reactionFramesBaO;
    public Sprite[] reactionFramesCaO;
    public Sprite[] reactionFramesNa2O;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip soundBaO;
    public AudioClip soundCaO;
    public AudioClip soundNa2O;
    public float frameDelay = 0.1f;

    private SpriteRenderer spriteRenderer;
    private TooltipObject tooltipObject;
    private bool reacted = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tooltipObject = GetComponent<TooltipObject>();
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (tooltipObject != null)
        {
            tooltipObject.SetNoiDung(
                "Cốc chứa dung dịch HCl. Thả BaO, CaO hoặc Na2O vào để quan sát phản ứng.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (reacted)
            return;

        // Delegate to a unified handler so collisions (non-trigger) can reuse the same logic
        HandleChemicalCollision(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (reacted)
            return;

        // Some objects may use non-trigger colliders; handle those too
        HandleChemicalCollision(collision.gameObject);
    }

    private void HandleChemicalCollision(GameObject otherObj)
    {
        if (otherObj == null)
            return;

        if (otherObj.CompareTag("BaO"))
        {
            ReactWithChemical(
                otherObj,
                reactionFramesBaO,
                soundBaO,
                "BaCl<sub>2</sub> (Bari clorua)\n" +
                "Công thức: BaO + 2HCl → BaCl<sub>2</sub> + H<sub>2</sub>O\n" +
                "Hiện tượng: Chất rắn BaO tan dần trong dung dịch HCl, tạo thành dung dịch muối trắng.");
            return;
        }

        if (otherObj.CompareTag("CaO"))
        {
            ReactWithChemical(
                otherObj,
                reactionFramesCaO,
                soundCaO,
                "CaCl<sub>2</sub> (Canxi clorua)\n" +
                "Công thức: CaO + 2HCl → CaCl<sub>2</sub> + H<sub>2</sub>O\n" +
                "Hiện tượng: CaO phản ứng với HCl, tan dần và tạo dung dịch muối.");
            return;
        }

        if (otherObj.CompareTag("Na2O"))
        {
            ReactWithChemical(
                otherObj,
                reactionFramesNa2O,
                soundNa2O,
                "NaCl (Natri clorua)\n" +
                "Công thức: Na<sub>2</sub>O + 2HCl → 2NaCl + H<sub>2</sub>O\n" +
                "Hiện tượng: Na2O tan nhanh trong HCl và tạo thành dung dịch muối.");
            return;
        }
    }

    private void ReactWithChemical(
        GameObject chemical,
        Sprite[] frames,
        AudioClip sound,
        string infoText)
    {
        reacted = true;

        if (chemical != null)
        {
            Destroy(chemical);
        }

        if (tooltipObject != null)
        {
            tooltipObject.SetNoiDung(infoText);
        }

        StartCoroutine(PlayReaction(frames, sound));
    }

    private IEnumerator PlayReaction(Sprite[] frames, AudioClip sound)
    {
        if (audioSource != null && sound != null)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }

        if (frames != null && frames.Length > 0 && spriteRenderer != null)
        {
            for (int i = 0; i < frames.Length; i++)
            {
                if (frames[i] != null)
                {
                    spriteRenderer.sprite = frames[i];
                }

                yield return new WaitForSeconds(frameDelay);
            }
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}