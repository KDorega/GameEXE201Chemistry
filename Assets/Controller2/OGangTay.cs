using UnityEngine;

public class OGangTay : MonoBehaviour
{
    [SerializeField]
    private bool anSauKhiLay;

    private void OnMouseDown()
    {
        if (ChallengeTutorialManager.Instance != null)
        {
            if (!ChallengeTutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }
        if (TutorialManager.Instance != null)
        {
            if (!TutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }

        CursorManager.Instance.ChonGangTay();
        if (ChallengeTutorialManager.Instance != null)
        {
            ChallengeTutorialManager.Instance
                .HoanThanhDeoGangTay();
        }
        if (anSauKhiLay)
        {
            gameObject.SetActive(false);
        }

        if (TutorialManager.Instance != null)
        {
            TutorialManager.Instance.HoanThanhLayGangTay();
        }
    }

}