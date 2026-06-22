using UnityEngine;

public class LayDungCu : MonoBehaviour
{
    [SerializeField] private GameObject prefabCanSpawn;
    [SerializeField] private Transform viTriSpawn;
    public enum LoaiDungCu
    {
        KhayHoaChat,
        CocRong
    }

    [SerializeField] private LoaiDungCu loaiDungCu;
    private void OnMouseDown()
    {
        Debug.Log("LayDungCu.OnMouseDown called on: " + gameObject.name);

        try
        {
            if (!TutorialManager.Instance.CoDuocClick(gameObject))
            {
                Debug.Log("Khong duoc click Tutorial");
                return;
            }

            if (!CursorManager.Instance.DangDeoGangTay)
            {
                Debug.Log("Chua deo gang tay");
                return;
            }

            Debug.Log("LayDungCu: Thỏa mãn điều kiện, tiến hành spawn...");

            GameObject vat = Instantiate(
                prefabCanSpawn,
                viTriSpawn.position,
                Quaternion.identity
            );

            switch (loaiDungCu)
            {
                case LoaiDungCu.KhayHoaChat:
                    TutorialManager.Instance.HoanThanhLayKhay(vat);
                    break;

                case LoaiDungCu.CocRong:
                    Debug.Log("Spawn CocRong xong");
                    TutorialManager.Instance.HoanThanhLayCoc(vat);
                    break;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Lỗi Exception trong LayDungCu.OnMouseDown: " + e.Message + "\n" + e.StackTrace);
        }
    }
}