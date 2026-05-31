using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReactionFrames : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Frame của BaO
    public Sprite[] reactionFramesBaO;

    // Frame của Na2O
    public Sprite[] reactionFramesNa2O;

    public float frameDelay = 0.1f;

    public GameObject infoButton;
    public bool reactionFinished = false;
    private bool reacted = false;
    
    private string reactionType = "";
    public AudioSource audioSource;

    public AudioClip soundBaO;

    public AudioClip soundNa2O;
    private void Start()
    {
        if (infoButton != null)
        {
            infoButton.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (reacted) return;

        // BaO
        if (other.CompareTag("BaO"))
        {
            reacted = true;

            reactionType = "BaO";

            ItemInfo itemInfo = GetComponent<ItemInfo>();

            if (itemInfo != null)
            {
                itemInfo.SetInfo(
                    "Tên: Dung dịch Bari Hydroxit (Ba(OH)<sub>2</sub>)\n\n" +
                    "Trạng thái: Dung dịch bazơ mạnh.\n\n" +
                    "Lưu ý: Có tính ăn mòn và gây kích ứng da."
                );
            }

            Destroy(other.gameObject);
            PracticeManager.instance.CompleteBaO();
            StartCoroutine(PlayReaction(reactionFramesBaO, soundBaO));
        }

        // Na2O
        else if (other.CompareTag("Na2O"))
        {
            reacted = true;

            reactionType = "Na2O";

            ItemInfo itemInfo = GetComponent<ItemInfo>();

            if (itemInfo != null)
            {
                itemInfo.SetInfo(
                    "Tên: Dung dịch Natri Hydroxit (NaOH)\n\n" +
                    "Trạng thái: Dung dịch bazơ mạnh.\n\n" +
                    "Lưu ý: Có khả năng gây bỏng hóa học."
                );
            }

            Destroy(other.gameObject);
            PracticeManager.instance.CompleteNa2O();
            StartCoroutine(PlayReaction(reactionFramesNa2O, soundNa2O));
        }
    }

    IEnumerator PlayReaction(Sprite[] frames, AudioClip sound)
    {
        // ===== PHÁT ÂM THANH =====
        if (audioSource != null && sound != null)
        {
            

            audioSource.volume = 0f;

            audioSource.PlayOneShot(sound);
        }

        int totalFrames = frames.Length;

        for (int i = 0; i < totalFrames; i++)
        {
            spriteRenderer.sprite = frames[i];

            // ===== CHIA 3 GIAI ĐOẠN =====

            float volume = 1f;

            float progress =
                (float)i / (totalFrames - 1);

            // =========================
            // 1. ĐẦU
            // 0% -> 30%
            // tăng dần
            // =========================
            if (progress < 0.3f)
            {
                volume =
                    Mathf.Lerp(
                        0.1f,
                        1f,
                        progress / 0.3f
                    );
            }

            // =========================
            // 2. GIỮA
            // 30% -> 70%
            // volume max
            // =========================
            else if (progress < 0.7f)
            {
                volume = 1f;
            }

            // =========================
            // 3. CUỐI
            // 70% -> 100%
            // giảm dần
            // =========================
            else
            {
                volume =
                    Mathf.Lerp(
                        1f,
                        0f,
                        (progress - 0.7f) / 0.3f
                    );
            }

            // GÁN VOLUME
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }

            yield return new WaitForSeconds(frameDelay);
        }

        // ===== DỪNG ÂM THANH =====
        if (audioSource != null)
        {
            audioSource.Stop();

            audioSource.volume = 1f;
        }
        reactionFinished = true;
        
    }
    public string GetReactionType()
    {
        return reactionType;
    }
    private void OnMouseDown()
    {
        if (!reactionFinished) return;

        Vector2 mousePos =
            Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue()
            );

        RaycastHit2D hit =
            Physics2D.Raycast(mousePos, Vector2.zero);

        // Nếu đang click vào nút i thì bỏ qua
        if (
            hit.collider != null &&
            hit.collider.gameObject == infoButton
        )
        {
            return;
        }

        if (infoButton != null)
        {
            infoButton.SetActive(!infoButton.activeSelf);
        }
    }
}