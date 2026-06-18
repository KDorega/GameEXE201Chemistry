using UnityEngine;

public class OChaiNuocController : MonoBehaviour
{
    [SerializeField]
    private GameObject chaiNuocPrefab;

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
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        mousePos.z = 0;

        GameObject chai =
            Instantiate(
                chaiNuocPrefab,
                mousePos,
                Quaternion.identity
            );

        DragObject drag =
            chai.GetComponent<DragObject>();

        if (drag != null)
        {
            drag.BatDauKeoNgay();
        }

        gameObject.SetActive(false);
    }
}