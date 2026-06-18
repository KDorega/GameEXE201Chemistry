using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class NutBamXController : MonoBehaviour
{
    public DungDoManager dungDoManager;
    private SpriteRenderer sr;

    private Color32 darkColor =
        new Color32(45, 45, 45, 255);
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos =
                Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            RaycastHit2D hit =
                Physics2D.Raycast(mousePos, Vector2.zero);

            if (
                hit.collider != null &&
                hit.collider.gameObject == gameObject
            )
            {
                sr.color = darkColor;

                StartCoroutine(PressEffect());
            }
        }
    }
    IEnumerator PressEffect()
    {
        sr.color = darkColor;

        yield return new WaitForSeconds(0.1f);

        sr.color = Color.white;

        dungDoManager.CloseInventory();
    }
}