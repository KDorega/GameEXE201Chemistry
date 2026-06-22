using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    [SerializeField] private GameObject cursorGangTay;

    [SerializeField] private Sprite gangTayThaLong;
    [SerializeField] private Sprite gangTayChiTay;
    [SerializeField] private Sprite gangTayNamChat;
    private SpriteRenderer spriteRenderer;
    public bool DangDeoGangTay { get; private set; }
    public bool DangCamVat { get; private set; }
    private void Awake()
    {
        Instance = this;

        spriteRenderer = cursorGangTay.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!cursorGangTay.activeSelf)
            return;

        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        cursorGangTay.transform.position = mousePos;

        // Ưu tiên trạng thái đang cầm đồ
        if (DangCamVat)
        {
            spriteRenderer.sprite = gangTayNamChat;
            return;
        }

        Collider2D hit = Physics2D.OverlapPoint(mousePos);

        if (hit != null && !hit.CompareTag("Table"))
        {
            spriteRenderer.sprite = gangTayChiTay;
        }
        else
        {
            spriteRenderer.sprite = gangTayThaLong;
        }
    }

    public void ChonGangTay()
    {
        DangDeoGangTay = true;
        Cursor.visible = false;

        cursorGangTay.SetActive(true);

        spriteRenderer.sprite = gangTayThaLong;
    }
    public void BatDauCamVat()
    {
        DangCamVat = true;
    }

    public void ThaVat()
    {
        DangCamVat = false;
    }
    public void ResetCursor()
    {
        DangDeoGangTay = false;
        DangCamVat = false;

        Cursor.visible = true;

        if (cursorGangTay != null)
        {
            cursorGangTay.SetActive(false);
        }
    }
}