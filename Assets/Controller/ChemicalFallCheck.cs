using UnityEngine;

public class ChemicalFallCheck : MonoBehaviour
{
    private bool counted = false;

    void Update()
    {
        if (counted) return;

        Vector3 viewportPos =
            Camera.main.WorldToViewportPoint(
                transform.position
            );

        // dưới màn hình
        if (viewportPos.y < 0)
        {
            counted = true;

            LabSafetyManager.Instance.HoaChatRoiXuongSan();

            Destroy(gameObject);
        }
    }
}