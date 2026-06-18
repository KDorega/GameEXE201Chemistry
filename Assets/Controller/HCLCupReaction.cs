//using System.Collections;
//using UnityEngine;

//public class HCLCupReaction : MonoBehaviour
//{
//    public SpriteRenderer spriteRenderer;

//    [Header("BaO + HCl")]
//    public Sprite[] reactionFramesBaO;
//    public Sprite[] reactionFramesNa2O;
//    public Sprite[] reactionFramesCaO;
//    public AudioSource audioSource;
//    private string reactionType = "";
//    public AudioClip soundBaO;
//    public AudioClip soundNa2O;
//    public AudioClip soundCaO;
//    public float frameDelay = 0.1f;

//    [HideInInspector]
//    public bool containsHCL = false;

//    private bool reacted = false;
//    public GameObject infoButton;

//    private bool reactionFinished = false;
//    private void Start()
//    {
//        if (infoButton != null)
//        {
//            infoButton.SetActive(false);
//        }
//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (reacted) return;

//        if (!containsHCL) return;

//        // BaO + HCl
//        if (other.CompareTag("BaO"))
//        {
//            reacted = true;
//            reactionType = "BaCl2";
//            Destroy(other.gameObject);
//            QuestManager qm =
//            FindFirstObjectByType<QuestManager>();

//            if (qm != null)
//            {
//                qm.CompleteChemical("BaO");
//            }
//            ItemInfo itemInfo =
//                GetComponent<ItemInfo>();

//            if (itemInfo != null)
//            {
//                itemInfo.SetInfo(
//                    "Tên: Dung dịch Bari Clorua (BaCl<sub>2</sub>)\n\n" +
//                    "Trạng thái: Dung dịch muối.\n\n" +
//                    "Được tạo thành từ phản ứng giữa BaO và HCl."
//                );
//            }

//            StartCoroutine(
//                PlayReaction(
//                    reactionFramesBaO,
//                    soundBaO
//                )
//            );
//        }

//        // Na2O + HCl
//        else if (other.CompareTag("Na2O"))
//        {
//            reacted = true;
//            reactionType = "NaCl";
//            Destroy(other.gameObject);
//            QuestManager qm =
//            FindFirstObjectByType<QuestManager>();

//            if (qm != null)
//            {
//                qm.CompleteChemical("Na2O");
//            }
//            ItemInfo itemInfo =
//                GetComponent<ItemInfo>();

//            if (itemInfo != null)
//            {
//                itemInfo.SetInfo(
//                    "Tên: Dung dịch Natri Clorua (NaCl)\n\n" +
//                    "Trạng thái: Dung dịch muối.\n\n" +
//                    "Được tạo thành từ phản ứng giữa Na<sub>2</sub>O và HCl."
//                );
//            }

//            StartCoroutine(
//                PlayReaction(
//                    reactionFramesNa2O,
//                    soundNa2O
//                )
//            );
//        }
//        else if (other.CompareTag("CaO"))
//        {
//            reacted = true;
//            reactionType = "CaCl2";
//            Destroy(other.gameObject);

//            QuestManager qm =
//                FindFirstObjectByType<QuestManager>();

//            if (qm != null)
//            {
//                qm.CompleteChemical("CaO");
//            }

//            ItemInfo itemInfo =
//                GetComponent<ItemInfo>();

//            if (itemInfo != null)
//            {
//                itemInfo.SetInfo(
//                    "Tên: Dung dịch Canxi Clorua (CaCl<sub>2</sub>)\n\n" +
//                    "Trạng thái: Dung dịch muối.\n\n" +
//                    "Được tạo thành từ phản ứng giữa CaO và HCl."
//                );
//            }

//            StartCoroutine(
//                PlayReaction(
//                    reactionFramesCaO,
//                    soundCaO
//                )
//            );
//        }
//    }

//    IEnumerator PlayReaction(
//    Sprite[] frames,
//    AudioClip sound
//)
//    {
//        if (
//            audioSource != null &&
//            sound != null
//        )
//        {
//            audioSource.clip = sound;

//            audioSource.volume = 0f;

//            audioSource.Play();
//        }

//        int totalFrames = frames.Length;

//        for (int i = 0; i < totalFrames; i++)
//        {
//            spriteRenderer.sprite = frames[i];

//            float volume = 1f;

//            float progress =
//                (float)i / (totalFrames - 1);

//            // ĐẦU
//            if (progress < 0.3f)
//            {
//                volume =
//                    Mathf.Lerp(
//                        0.1f,
//                        1f,
//                        progress / 0.3f
//                    );
//            }
//            // GIỮA
//            else if (progress < 0.7f)
//            {
//                volume = 1f;
//            }
//            // CUỐI
//            else
//            {
//                volume =
//                    Mathf.Lerp(
//                        1f,
//                        0f,
//                        (progress - 0.7f) / 0.3f
//                    );
//            }

//            if (audioSource != null)
//            {
//                audioSource.volume = volume;
//            }

//            yield return new WaitForSeconds(
//                frameDelay
//            );
//        }

//        if (audioSource != null)
//        {
//            audioSource.Stop();

//            audioSource.volume = 1f;
//        }
//        reactionFinished = true;

//        if (infoButton != null)
//        {
//            infoButton.SetActive(true);
//        }
//    }
//    public string GetReactionType()
//    {
//        return reactionType;
//    }
//}