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
        reactionText.text = reactionText.text =
        "<b>Mô tả chi tiết:</b>\n\n" +
        "<b>Công thức hóa học:</b> BaO + H<sub>2</sub>O <size=150%>→</size> Ba(OH)<sub>2</sub>\n\n" +
        "<b>Hiện tượng:</b> Cục <color=#00E5FF>BaO</color> màu trắng tan và rã ra trong nước, tỏa lượng nhiệt rất lớn làm nước nóng lên nhanh chóng.\n\n" +
        "<b>Sản phẩm:</b> Tạo ra dung dịch trong suốt, không màu. Dung dịch thu được gọi là nước bari\n\n" +
        "<b>Độ tan:</b> <color=#00E5FF>Ba(OH)<sub>2</sub></color> có độ tan vừa phải ở nhiệt độ thường; nếu cho quá nhiều <color=#00E5FF>BaO</color>, thì kết tủa trắng ở đáy.";
    }

    // =========================
    // Na2O
    // =========================
    public void ShowNa2OInfo()
    {
        reactionText.text =
        "<b>Mô tả chi tiết:</b>\n\n" +

        "<b>Công thức hóa học:</b> Na<sub>2</sub>O + H<sub>2</sub>O <size=250%>→</size> NaOH\n\n" +

        "<b>Hiện tượng:</b> Phản ứng tỏa ra lượng nhiệt rất lớn. Chất rắn <color=#00E5FF>Na<sub>2</sub>O</color> tan dần trong nước.\n\n" +

        "<b>Sản phẩm:</b> Tạo ra dung dịch trong suốt, không màu.\n\n" +

        "<b>Tính chất sản phẩm:</b> Dung dịch tạo thành làm quỳ tím hóa xanh do chứa bazơ mạnh <color=#00E5FF>NaOH</color>.";
    }
    public void ShowCaOInfo()
    {
        reactionText.text =
        "<b>Mô tả chi tiết:</b>\n\n" +

        "<b>Công thức hóa học:</b> CaO + H<sub>2</sub>O <size=150%>→</size> Ca(OH)<sub>2</sub>\n\n" +

        "<b>Hiện tượng:</b> Cục <color=#00E5FF>CaO</color> màu trắng hút nước mạnh, nóng lên và dần tan tạo thành chất bột trắng.\n\n" +

        "<b>Sản phẩm:</b> Tạo thành <color=#00E5FF>Ca(OH)<sub>2</sub></color> còn gọi là nước vôi trong hoặc vôi tôi.\n\n" +

        "<b>Độ tan:</b> <color=#00E5FF>Ca(OH)<sub>2</sub></color> tan rất ít trong nước, phần dư sẽ lắng xuống đáy tạo lớp màu trắng.";
    }
}