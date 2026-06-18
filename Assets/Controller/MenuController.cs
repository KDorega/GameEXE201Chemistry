using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
public class MenuController : MonoBehaviour
{
    public string sceneName = "LabScene";

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
                // PLAY
                if (hit.collider.gameObject.name == "NuTPlayE")
                {
                    ClickSoundManager.instance.PlayClick();
                    StartCoroutine(LoadSceneDelay(sceneName));

                }

                // EXIT
                if (hit.collider.gameObject.name == "NutExitremove")
                {
                    ClickSoundManager.instance.PlayClick();

                    StartCoroutine(QuitDelay());
                }

                if (hit.collider.gameObject.name == "NutExitLab")
                {
                    ClickSoundManager.instance.PlayClick();
                    StartCoroutine(LoadSceneDelay("MenuScene"));
                }
                IEnumerator LoadSceneDelay(string scene)
                {
                    // phát click
                    ClickSoundManager.instance.PlayClick();

                    // chờ âm thanh phát
                    yield return new WaitForSeconds(0.15f);

                    SceneManager.LoadScene(scene);
                }
                IEnumerator QuitDelay()
                {
                    yield return new WaitForSeconds(0.15f);

                    Application.Quit();

                    Debug.Log("EXIT GAME");
                }
            }
        }
    }
}