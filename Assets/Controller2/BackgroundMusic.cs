using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    // Cơ chế Singleton để các Script khác dễ dàng gọi tới
    public static BackgroundMusic instance;

    private AudioSource audioSource;

    void Awake()
    {
        // 1. Xử lý trùng lặp Object khi người chơi quay lại Menu chính
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        // 2. Giữ cho Object này không bị xóa khi chuyển Scene (Menu -> Màn chính -> Màn phụ)
        DontDestroyOnLoad(gameObject);

        // Tự động lấy thành phần Audio Source gắn trên cùng Object
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Chức năng Bật/Tắt (Mute/Unmute) nhạc nền bằng nút bấm UI
    /// </summary>
    public void ToggleMute()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute; // Đảo ngược trạng thái tắt tiếng
        }
    }

    /// <summary>
    /// Chức năng phát nhạc chiến thắng ngắn, sau đó tự chuyển sang nhạc nền tiếp theo
    /// </summary>
    public void PlayVictoryAndChangeMusic(AudioClip victoryClip, AudioClip nextLevelMusic)
    {
        audioSource.Stop(); // Dừng nhạc nền hiện tại ngay lập tức
        StartCoroutine(VictorySequence(victoryClip, nextLevelMusic));
    }

    private IEnumerator VictorySequence(AudioClip victory, AudioClip nextMusic)
    {
        // Phát nhạc chiến thắng (Tắt Loop vì đây là nhạc ngắn)
        audioSource.loop = false;
        audioSource.clip = victory;
        audioSource.Play();

        // Chờ nhạc chiến thắng chạy hết độ dài của nó
        yield return new WaitForSeconds(victory.length);

        // Đổi sang nhạc nền của màn chơi tiếp theo và bật lại Loop
        if (nextMusic != null)
        {
            audioSource.clip = nextMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}