using UnityEngine;

public class QuestPanelMover : MonoBehaviour
{
    public float moveSpeed = 20f;

    public float holdTimeToDrag = 0.1f;

    private bool mouseHolding = false;
    private bool dragging = false;

    private float holdTimer = 0f;

    void Update()
    {
        Vector2 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        Collider2D hit =
            Physics2D.OverlapPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            if (
                hit != null &&
                hit.gameObject == gameObject
            )
            {
                mouseHolding = true;

                holdTimer = 0f;
            }
        }

        if (mouseHolding)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTimeToDrag)
            {
                dragging = true;
            }
        }

        if (dragging)
        {
            Vector3 targetPos =
                new Vector3(
                    mousePos.x,
                    mousePos.y,
                    0
                );

            transform.position =
                Vector3.Lerp(
                    transform.position,
                    targetPos,
                    moveSpeed * Time.deltaTime
                );
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseHolding = false;
            dragging = false;
        }
    }

    public bool IsDragging()
    {
        return dragging;
    }
}