using UnityEngine;
using UnityEngine.SceneManagement;

public class NutExitController : MonoBehaviour
{
    [SerializeField] private string tenSceneMenu = "MenuScene";

    private void OnMouseDown()
    {
        if (CursorManager.Instance != null)
        {
            CursorManager.Instance.ResetCursor();
        }
        SceneManager.LoadScene(tenSceneMenu);
    }
}