using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool isDragging;
    private Vector3 offset;
    private float thoiGianNhan;
    private bool daChuyenSangCam;
    private Rigidbody2D rb;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (!CursorManager.Instance.DangDeoGangTay)
            return;

        thoiGianNhan = Time.time;
        daChuyenSangCam = false;

        if (TutorialManager.Instance != null)
        {
            if (!TutorialManager.Instance.CoDuocClick(gameObject))
                return;
        }

        if (TutorialManager.Instance != null &&
            TutorialManager.Instance.DangTutorial)
        {
            TutorialManager.Instance.HoanThanhClickCoc(gameObject);
        }

        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        offset = transform.position - mousePos;

        isDragging = true;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        rb.bodyType =
            RigidbodyType2D.Dynamic;

        CursorManager.Instance.ThaVat();

        // Tutorial cũ
        CocRongController coc =
            GetComponent<CocRongController>();

        if (coc != null &&
            TutorialManager.Instance != null &&
            coc.DangOChoLayNuoc)
        {
            TutorialManager.Instance.HoanThanhDatCoc();
        }

        // ChallengeScene
        ChaiNuocController chai =
            GetComponent<ChaiNuocController>();

        if (chai != null)
        {
            chai.KiemTraDoNuoc();
        }
    }

    private void Update()
    {
        if (!isDragging)
            return;

        if (!daChuyenSangCam &&
            Time.time - thoiGianNhan > 0.3f) // giữ 1 giây
        {
            daChuyenSangCam = true;

            CursorManager.Instance.BatDauCamVat();
        }

        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        transform.position = mousePos + offset;
    }
    public void BatDauKeoNgay()
    {
        isDragging = true;

        rb.bodyType = RigidbodyType2D.Kinematic;

        offset = Vector3.zero;

        CursorManager.Instance.BatDauCamVat();
    }
}