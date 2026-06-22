using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public TMP_Text thongTinVatPham;

    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(
                Input.mousePosition
            );

        mousePos.z = 0;

        float offsetX = 2.6f;
        float offsetY = 1.6f;

        transform.position =
            mousePos + new Vector3(offsetX, offsetY, 0);
    }

    public void Show(string noiDung)
    {
        gameObject.SetActive(true);

        thongTinVatPham.text = noiDung;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}