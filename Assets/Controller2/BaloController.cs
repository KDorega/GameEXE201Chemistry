using UnityEngine;

public class BaloController : MonoBehaviour
{
    [SerializeField] private GameObject oDungDo;
    [SerializeField] private GameObject hopPhaChe;
    [SerializeField] private GameObject oGangTay;
    [SerializeField] private GameObject oCocRong;
    [SerializeField] private GameObject oChaiNuoc;
    [SerializeField] private GameObject o_BaO;
    [SerializeField] private GameObject o_Na2O;
    [SerializeField] private GameObject o_CaO;
    private bool daMo;

    private void Start()
    {
        oDungDo.SetActive(false);
        hopPhaChe.SetActive(false);
        oGangTay.SetActive(false);
        oCocRong.SetActive(false);
        oChaiNuoc.SetActive(false);
        o_BaO.SetActive(false);
        o_CaO.SetActive(false);
        o_Na2O.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (ChallengeTutorialManager.Instance != null)
        {
            if (!ChallengeTutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }
        daMo = !daMo;

        oDungDo.SetActive(daMo);

        hopPhaChe.SetActive(daMo);
        oGangTay.SetActive(daMo);
        oCocRong.SetActive(daMo);
        oChaiNuoc.SetActive(daMo);
        o_BaO.SetActive(daMo);
        o_CaO.SetActive(daMo);
        o_Na2O.SetActive(daMo);

        if (daMo &&
            ChallengeTutorialManager.Instance != null)
        {
            ChallengeTutorialManager.Instance
                .HoanThanhMoBalo();
        }
    }
}