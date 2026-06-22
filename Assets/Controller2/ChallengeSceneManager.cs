using UnityEngine;

public class ChallengeSceneManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;

        if (CursorManager.Instance != null)
        {
            CursorManager.Instance.ThaVat();
        }
    }
}