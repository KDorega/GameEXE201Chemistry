using UnityEngine;

public class OHCLBottleController : MonoBehaviour
{
    [SerializeField] private GameObject hclBottlePrefab;

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

        GameObject hclBottle =
            Instantiate(
                hclBottlePrefab,
                mousePos,
                Quaternion.identity
            );

        DragObject drag =
            hclBottle.GetComponent<DragObject>();

        if (drag != null)
        {
            drag.BatDauKeoNgay();
        }

        gameObject.SetActive(false);
    }
}
