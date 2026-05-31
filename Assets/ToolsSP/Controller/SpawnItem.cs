using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPrefab;

    private GameObject currentItem;

    private bool dragging = false;

    void Update()
    {
        // Đang giữ chuột
        if (dragging && currentItem != null)
        {
            Vector3 mousePos =
                Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            mousePos.z = 0;

            currentItem.transform.position = mousePos;
        }

        // Thả chuột
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (currentItem != null)
            {
                Rigidbody2D rb =
                    currentItem.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.gravityScale = 1;
                }
            }

            dragging = false;

            currentItem = null;
        }
    }

    void OnMouseDown()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Mouse.current.position.ReadValue()
            );

        mousePos.z = 0;

        currentItem =
            Instantiate(itemPrefab, mousePos, Quaternion.identity);

        Rigidbody2D rb =
            currentItem.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.gravityScale = 0;
        }

        dragging = true;
    }
}