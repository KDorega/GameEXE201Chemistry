using UnityEngine;

public class DatChuaZoneController : MonoBehaviour
{
    [SerializeField]
    private DatChuaController datChua;

    private void OnTriggerEnter2D(
        Collider2D other)
    {
        CocNuocController cocNuoc =
            other.GetComponent<CocNuocController>();

        if (cocNuoc == null)
            return;

        datChua.XuLyDungDich(
            cocNuoc
        );
    }
}