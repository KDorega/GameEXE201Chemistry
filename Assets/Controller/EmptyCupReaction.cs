//using UnityEngine;
//using System.Collections;

//public class EmptyCupReaction : MonoBehaviour
//{
//    public SpriteRenderer cupRenderer;

//    public Sprite[] pourFrames;

//    public Sprite finalCupSprite;

//    private bool reacted = false;
//    public AudioSource audioSource;

//    public AudioClip pourSound;

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (reacted) return;

//        HCLBottle bottle =
//            other.GetComponent<HCLBottle>();

//        if (bottle == null) return;

//        if (!bottle.isOpened) return;

//        reacted = true;

//        Destroy(other.gameObject);

//        StartCoroutine(PlayPourAnimation());
//    }

//    IEnumerator PlayPourAnimation()
//    {
//        if (
//            audioSource != null &&
//            pourSound != null
//        )
//        {
//            audioSource.clip = pourSound;

//            audioSource.volume = 0f;

//            audioSource.Play();
//        }

//        int totalFrames = pourFrames.Length;

//        for (int i = 0; i < totalFrames; i++)
//        {
//            cupRenderer.sprite = pourFrames[i];

//            float volume = 1f;

//            float progress =
//                (float)i / (totalFrames - 1);

//            // Tăng dần
//            if (progress < 0.3f)
//            {
//                volume =
//                    Mathf.Lerp(
//                        0.1f,
//                        1f,
//                        progress / 0.3f
//                    );
//            }
//            // Giữ nguyên
//            else if (progress < 0.7f)
//            {
//                volume = 1f;
//            }
//            // Giảm dần
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

//            yield return new WaitForSeconds(0.14f);
//        }

//        if (audioSource != null)
//        {
//            audioSource.Stop();

//            audioSource.volume = 1f;
//        }

//        cupRenderer.sprite = finalCupSprite;

//        ItemInfo itemInfo =
//            GetComponent<ItemInfo>();

//        if (itemInfo != null)
//        {
//            itemInfo.SetInfo(
//                "Tên: Dung dịch Axit Clohidric (HCl)\n\n" +
//                "Trạng thái: Dung dịch axit mạnh không màu.\n\n" +
//                "Lưu ý: Có tính ăn mòn cao, gây bỏng da và mắt khi tiếp xúc."
//            );
//        }

//        HCLCupReaction hclReaction =
//            GetComponent<HCLCupReaction>();

//        if (hclReaction != null)
//        {
//            hclReaction.containsHCL = true;
//        }
//    }
//}