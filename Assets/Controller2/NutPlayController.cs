using UnityEngine;

public class NutPlayController : MonoBehaviour
{
    [SerializeField]
    private GameObject oChaiNuoc;
    private void OnMouseDown()
    {
        ChoiLai();
    }
    public void ChoiLai()
    {
        if (ChallengeGameManager.Instance != null)
        {
            ChallengeGameManager.Instance
                .ResetGame();
        }

        if (oChaiNuoc != null)
        {
            oChaiNuoc.SetActive(true);
        }

        XoaTatCaVatPham();
    }

    private void XoaTatCaVatPham()
    {
        GameObject[] chaiNuoc =
            GameObject.FindGameObjectsWithTag(
                "ChaiNuoc"
            );
        Debug.Log(chaiNuoc.Length);
        foreach (GameObject obj in chaiNuoc)
        {
            Destroy(obj);
        }

        GameObject[] cocRong =
            GameObject.FindGameObjectsWithTag(
                "CocRong"
            );

        foreach (GameObject obj in cocRong)
        {
            Destroy(obj);
        }

        GameObject[] cocNuoc =
            GameObject.FindGameObjectsWithTag(
                "CocNuoc"
            );

        foreach (GameObject obj in cocNuoc)
        {
            Destroy(obj);
        }

        GameObject[] BaO =
            GameObject.FindGameObjectsWithTag(
                "BaO"
            );
        foreach (GameObject obj in BaO)
        {
            Destroy(obj);
        }
        GameObject[] Na2O =
            GameObject.FindGameObjectsWithTag(
                "Na2O"
            );
        foreach (GameObject obj in Na2O)
        {
            Destroy(obj);
        }
        GameObject[] CaO =
    GameObject.FindGameObjectsWithTag(
        "CaO"
    );
        foreach (GameObject obj in CaO)
        {
            Destroy(obj);
        }
    }
}