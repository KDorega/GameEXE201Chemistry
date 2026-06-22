using UnityEngine;
using UnityEngine.SceneManagement;

public class NutThuThachController : MonoBehaviour
{
    [SerializeField] private string tenSceneThuThach = "ChallengeScene";

    private void OnMouseDown()
    {
        SceneManager.LoadScene(tenSceneThuThach);
    }
}