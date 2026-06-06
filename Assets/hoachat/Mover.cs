using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 20f;

    private bool dragging;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(mousePos);

        // Bắt đầu kéo
        if (Input.GetMouseButtonDown(0))
        {
            if (hit != null && hit.gameObject == gameObject)
            {
                dragging = true;
            }
        }

        // Thả chuột
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        // Di chuyển mượt theo chuột
        if (dragging)
        {
            Vector3 targetPos = new Vector3(mousePos.x, mousePos.y, 0);

            transform.position = Vector3.Lerp(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
        }
    }
}