using UnityEngine;
using UnityEngine.SceneManagement;

public class LabSafetyManager : MonoBehaviour
{
    public static LabSafetyManager Instance;

    private int soLanRoi = 0;

    private void Awake()
    {
        // Singleton pattern cơ bản
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void HoaChatRoiXuongSan()
    {
        soLanRoi++;

        if (soLanRoi >= 3)
        {
            
            AIMessageManager.Instance.ShowMessage(
                "Vì bạn không chịu thực hiện đúng yêu cầu nên tôi sẽ đưa bạn ra khỏi lab."
            );

            Invoke(nameof(ReturnToMenu), 3f);
        }
        else if (soLanRoi == 2) 
        {
            AIMessageManager.Instance.ShowMessage(
                 "Nếu bạn để rơi hóa chất xuống sàn quá 3 lần thì tôi buộc phải đưa bạn ra khỏi lab."
            );
        }
        else 
        {
            AIMessageManager.Instance.ShowMessage(
                "Bạn vừa làm rơi hóa chất xuống sàn. Hãy cẩn thận hơn."
            );
        }
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene"); 
    }
}