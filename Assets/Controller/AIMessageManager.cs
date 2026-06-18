using TMPro;
using UnityEngine;
using System.Collections;

public class AIMessageManager : MonoBehaviour
{
    public static AIMessageManager Instance;

    public TMP_Text noiDung;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowMessage(string message, float time = 3f)
    {
        StopAllCoroutines();

        gameObject.SetActive(true);

        noiDung.text = message;

        StartCoroutine(HideAfter(time));
    }

    IEnumerator HideAfter(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}