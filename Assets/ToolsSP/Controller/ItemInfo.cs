using UnityEngine;
using System.Collections;

public class ItemInfo : MonoBehaviour
{
    [TextArea(5, 20)]
    public string noiDung;
    public void SetInfo(string newInfo)
    {
        noiDung = newInfo;
    }
    private Coroutine showRoutine;

    private void OnMouseEnter()
    {
        showRoutine = StartCoroutine(ShowAfterDelay());
    }

    private void OnMouseExit()
    {
        if (showRoutine != null)
        {
            StopCoroutine(showRoutine);
        }

        TooltipManager.Instance.Hide();
    }

    IEnumerator ShowAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        TooltipManager.Instance.Show(noiDung);
    }
}