using TMPro;
using UnityEngine;

public class ReactionInfoManager : MonoBehaviour
{
    public TMP_Text reactionText;

    public static ReactionInfoManager instance;

    void Awake()
    {
        instance = this;
    }

    // =========================
    // BaO
    // =========================
    public void ShowBaOInfo()
    {
        reactionText.text =
     
        "<b>Mô tả chi tiết:</b>\n" +

        "<b>Hiện tượng:</b> Cục <color=#00E5FF>BaO</color> màu trắng tan và rã ra trong nước, tỏa lượng nhiệt rất lớn làm nước nóng lên nhanh chóng.\n" +

        "<b>Sản phẩm:</b> Dung dịch thu được gọi là nước bari.\n" +

        "<b>Độ tan:</b> <color=#00E5FF>Ba(OH)<sub>2</sub></color> có độ tan vừa phải ở nhiệt độ thường; nếu cho quá nhiều <color=#00E5FF>BaO</color>,thì kết tủa trắng ở đáy.";
    }

    // =========================
    // Na2O
    // =========================
    public void ShowNa2OInfo()
    {
        reactionText.text =        
        "<b>Mô tả chi tiết:</b>\n" +

        "<b>Hiện tượng:</b> Phản ứng tỏa ra lượng nhiệt rất lớn, có thể làm nước nóng nhanh. Chất rắn <color=#00E5FF>Na<sub>2</sub>O</color> tan dần trong nước.\n" +

        "<b>Sản phẩm:</b> Tạo ra dung dịch trong suốt, không màu.\n" +

        "<b>Tính chất sản phẩm:</b> Dung dịch tạo thành làm quỳ tím hóa xanh do chứa bazơ mạnh <color=#00E5FF>NaOH</color>.";
    }
}