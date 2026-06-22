using UnityEngine;

public class OCocRongController : MonoBehaviour
{
    [SerializeField] private GameObject cocRongPrefab;

    private const int SO_COC_TOI_DA = 4;

    private void OnMouseDown()
    {
        if (ChallengeTutorialManager.Instance != null)
        {
            if (!ChallengeTutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }
        if (!CursorManager.Instance.DangDeoGangTay)
        {
            if (ChallengeTutorialManager.Instance != null)
            {
                ChallengeTutorialManager.Instance
                    .BaoChuaDeoGangTay();
            }

            return;
        }
        GameObject[] dsCoc =
            GameObject.FindGameObjectsWithTag("CocRong");

        if (dsCoc.Length >= SO_COC_TOI_DA)
            return;

        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        mousePos.z = 0;

        GameObject coc =
            Instantiate(
                cocRongPrefab,
                mousePos,
                Quaternion.identity
            );

        DragObject drag =
            coc.GetComponent<DragObject>();

        if (drag != null)
        {
            drag.BatDauKeoNgay();
        }
    }
}   