using UnityEngine;

public class BangNhiemVuController : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ChallengeTutorialManager.Instance != null)
        {
            if (!ChallengeTutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }
        if (ChallengeTutorialManager.Instance != null)
        {
            ChallengeTutorialManager.Instance
                .HoanThanhXemBangNhiemVu();
        }
    }
}