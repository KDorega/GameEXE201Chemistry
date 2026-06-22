using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private Mover mover;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mover = GetComponent<Mover>();

        // Ban đầu không rơi
        rb.gravityScale = 0;
    }

    void Update()
    {
        // Nếu đang kéo
        if (Input.GetMouseButton(0))
        {
            rb.gravityScale = 0;

            // Tắt velocity để không rung
            rb.linearVelocity = Vector2.zero;
        }

        // Thả chuột
        if (Input.GetMouseButtonUp(0))
        {
            // Bật trọng lực
            rb.gravityScale = 1;
        }
    }
}