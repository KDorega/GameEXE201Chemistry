using UnityEngine;

public class LayHoaChat : MonoBehaviour
{
    [SerializeField]
    private GameObject hoaChatPrefab;

    private void OnMouseDown()
    {
        // ===== Tutorial LabScene =====
        if (TutorialManager.Instance != null)
        {
            if (!TutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }

        // ===== Bắt buộc đeo găng tay =====

        if (!CursorManager.Instance.DangDeoGangTay)
        {
            if (ChallengeTutorialManager.Instance != null)
            {
                ChallengeTutorialManager.Instance
                    .BaoChuaDeoGangTay();
            }

            return;
        }

        // ===== LabScene =====
        if (ChallengeTutorialManager.Instance != null)
        {
            if (!ChallengeTutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }
        if (HoaChatSpawnManager.Instance != null &&
            HoaChatSpawnManager.Instance.viTriDatHoaChat != null)
        {
            Instantiate(
                hoaChatPrefab,
                HoaChatSpawnManager.Instance.viTriDatHoaChat.position,
                Quaternion.identity
            );

            if (TutorialManager.Instance != null)
            {
                if (gameObject.name.Contains("BaO") ||
                    (hoaChatPrefab != null &&
                     hoaChatPrefab.name.Contains("BaO")))
                {
                    TutorialManager.Instance
                        .HoanThanhLayBaO();
                }
            }

            return;
        }

        // ===== ChallengeScene =====
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        mousePos.z = 0;

        GameObject hoaChat =
            Instantiate(
                hoaChatPrefab,
                mousePos,
                Quaternion.identity
            );

        DragObject drag =
            hoaChat.GetComponent<DragObject>();

        if (drag != null)
        {
            drag.BatDauKeoNgay();
        }
    }
}