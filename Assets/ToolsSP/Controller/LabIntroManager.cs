using TMPro;
using UnityEngine;
using System.Collections;
public class LabIntroManager : MonoBehaviour
{
    public GameObject khungThoai;
    public TMP_Text noiDung;

    private int index = 0;

    string[] messages =
    {
        "Chào mừng bạn đến với Chemistry Lab.\n\nTại đây bạn có thể tự do tạo các phản ứng hóa học trong môi trường ảo.\n\n<color=#00E5FF>Bạn hãy bấm vào tôi để tôi nói tiếp</color>",

        "Đây là phòng thí nghiệm ảo nên bạn sẽ không bị thương khi thao tác sai.\n\nTuy nhiên các phản ứng trong game đều dựa trên kiến thức hóa học thực tế.",

        "Để giúp bạn tìm hiểu các dụng cụ và hóa chất,Tôi sẽ đưa cho bạn công cụ hỗ trợ bằng cách đưa chuột và đợi khoảng 1 giây để xem thông tin chi tiết.",

        "Vì đây là công cụ demo của Lab nên đôi lúc có những chất không xác định được.\n\n Nhưng đừng lo vì tôi có thêm 1 nút 'i' trên đầu sản phẩm cuối cùng phản ứng giúp bạn hiểu rõ hơn.",

        "Hãy đọc kỹ các thông tin trước khi sử dụng hóa chất.\n\n<color=red><b>KHÔNG THỰC HIỆN THÍ NGHIỆM NGOÀI ĐỜI THỰC KHI KHÔNG CÓ NGƯỜI GIÁM SÁT.</b></color>",
        
        "Tôi sẽ giao nhiệm vụ cho bạn thực hành lấy điểm. \n\nTên bảng 'mục tiêu nhiệm vụ', bạn chỉ cần hoàn thành nhiệm vụ được giao là có điểm.",
        
        "Bạn có thể duy chuyển bảng bằng cách giữ và kéo chuột hoặc là phóng to hay thu nhỏ lại bằng click chuột 1 lần",

        "Đó là tất cả những gì bạn cần biết.\n\nChúc bạn thực hành vui vẻ!"
    };

    void Start()
    {
        khungThoai.SetActive(false);

        StartCoroutine(ShowIntro());
    }
    IEnumerator ShowIntro()
    {
        yield return new WaitForSeconds(2f);

        khungThoai.SetActive(true);

        noiDung.text = messages[0];
    }

    public void NextMessage()
    {
        index++;

        if (index >= messages.Length)
        {
            khungThoai.SetActive(false);
            return;
        }

        noiDung.text = messages[index];
    }
}