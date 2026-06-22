using UnityEngine;
using System.Collections;

public class TrashBin : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite closedSprite;

    public Sprite openSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(OpenTrash());
        Destroy(other.gameObject);


    }

    IEnumerator OpenTrash()
    {
        spriteRenderer.sprite = openSprite;

        yield return new WaitForSeconds(0.5f);

        spriteRenderer.sprite = closedSprite;
    }
}