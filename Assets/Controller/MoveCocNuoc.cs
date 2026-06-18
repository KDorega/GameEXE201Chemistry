using UnityEngine;

public class MoveCocNuoc : MonoBehaviour
{
    private bool dragging = false;

    private Rigidbody2D rb;

    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        offset = transform.position - mousePos;

        dragging = true;

        // Tắt vật lý khi cầm
        rb.gravityScale = 0;

        rb.linearVelocity = Vector2.zero;
    }

    void OnMouseUp()
    {
        dragging = false;

        // Bật vật lý khi thả
        rb.gravityScale = 1;
    }

    void Update()
    {
        if (!dragging) return;

        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        transform.position = mousePos + offset;
    }
}