using TMPro;
using UnityEngine;

public class BangGiaiThichNhoController : MonoBehaviour
{
    public static BangGiaiThichNhoController Instance;

    [SerializeField] private TextMeshPro textMeshPro;

    [Header("Vi tri hien thi")]
    [SerializeField]
    private Vector3 viTriHienThi;

    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            return;

        transform.position = viTriHienThi;
    }

    public void HienBang(string noiDung)
    {
        textMeshPro.text = noiDung;

        gameObject.SetActive(true);
    }

    public void AnBang()
    {
        gameObject.SetActive(false);
    }
}