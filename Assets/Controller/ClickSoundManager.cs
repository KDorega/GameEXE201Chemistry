using UnityEngine;
using UnityEngine.InputSystem;

public class ClickSoundManager : MonoBehaviour
{
    public static ClickSoundManager instance;

    public AudioSource audioSource;

    public AudioClip clickSound;

    void Awake()
    {
        instance = this;
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

            
            if (hit.collider != null)
            {
                PlayClick();
            }
        }
    }

    public void PlayClick()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}