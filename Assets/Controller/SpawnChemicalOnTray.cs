using UnityEngine;
using TMPro; // Sử dụng TextMeshPro cho text
using System.Collections;

public class SpawnChemicalOnTray : MonoBehaviour
{
    public GameObject chemicalPrefab;

    

    void OnMouseDown()
    {
        if (TrayHolder.currentTray == null)
        {
            AIMessageManager.Instance.ShowMessage(
                "Hóa chất rất nguy hiểm khi rơi xuống sàn. Bạn nên lấy Khay đựng để đựng hóa chất trước."
            );

            return;
        }

        Instantiate(
            chemicalPrefab,
            TrayHolder.currentTray.spawnPoint.position,
            Quaternion.identity
        );
    }

    
}