using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("--- 4 Frame Thu Phóng ---")]
    [SerializeField] private Sprite[] animationFrames;

    [Header("--- UI Dấu Tích & Canvas Group ---")]
    [SerializeField] private CanvasGroup canvasGroupChue; // Kéo Object 'Canvas_Chữ' vào đây
    [SerializeField] private GameObject tickBaO;
    [SerializeField] private GameObject tickNa2O;
    [SerializeField] private GameObject tickCaO;

    [HideInInspector] public bool isBaODone = false;
    [HideInInspector] public bool isNa2ODone = false;
    [HideInInspector] public bool isCaODone = false;

    private SpriteRenderer spriteRenderer;
    private bool isExpanded = false;
    private bool isAnimating = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (animationFrames.Length >= 4) spriteRenderer.sprite = animationFrames[3];

        // Đầu game ẩn toàn bộ chữ và dấu tích bằng cách cho Alpha = 0 (Trong suốt)
        if (canvasGroupChue != null)
        {
            canvasGroupChue.alpha = 0f;
            canvasGroupChue.interactable = false;
            canvasGroupChue.blocksRaycasts = false;
        }
        UpdateTickDisplay();
    }

    // Tự động chạy khi người chơi click chuột vào khu vực Box Collider 2D của bảng nhiệm vụ
    void OnMouseDown()
    {
        if (isAnimating) return;
        isExpanded = !isExpanded;
        StartCoroutine(PlayFoldAnimation(isExpanded));
    }

    private IEnumerator PlayFoldAnimation(bool expand)
    {
        isAnimating = true;

        if (expand)
        {
            // Mở bảng: Đổi hình từ Nhỏ đến Lớn (Hình 4 -> 3 -> 2 -> 1)
            for (int i = 3; i >= 0; i--)
            {
                spriteRenderer.sprite = animationFrames[i];
                yield return new WaitForSeconds(0.04f);
            }
            // Mở xong thì hiện chữ TextMeshPro lên mượt mà
            canvasGroupChue.alpha = 1f;
            canvasGroupChue.interactable = true;
            canvasGroupChue.blocksRaycasts = true;
            UpdateTickDisplay();
        }
        else
        {
            // Thu bảng: Ẩn chữ đi trước
            canvasGroupChue.alpha = 0f;
            canvasGroupChue.interactable = false;
            canvasGroupChue.blocksRaycasts = false;

            // Đổi hình từ Lớn về Nhỏ (Hình 1 -> 2 -> 3 -> 4)
            for (int i = 0; i <= 3; i++)
            {
                spriteRenderer.sprite = animationFrames[i];
                yield return new WaitForSeconds(0.04f);
            }
        }

        isAnimating = false;
    }

    public void UpdateTickDisplay()
    {
        if (tickBaO) tickBaO.SetActive(isBaODone);
        if (tickNa2O) tickNa2O.SetActive(isNa2ODone);
        if (tickCaO) tickCaO.SetActive(isCaODone);
    }

    // Hàm gọi từ hệ thống tương tác hóa chất khi người chơi làm thành công một chất
    public void CompleteChemical(string name)
    {
        if (PracticeManager.instance == null) return;

        switch (name.ToUpper())
        {
            case "BAO":
                isBaODone = true;
                PracticeManager.instance.CompleteBaO(); // Báo sang PracticeManager
                break;
            case "NA2O":
                isNa2ODone = true;
                PracticeManager.instance.CompleteNa2O(); // Báo sang PracticeManager
                break;
            case "CAO":
                isCaODone = true;
                PracticeManager.instance.CompleteCaO(); // Báo sang PracticeManager
                break;
        }

        UpdateTickDisplay();
    }
}