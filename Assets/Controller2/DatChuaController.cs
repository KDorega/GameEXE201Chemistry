using System.Collections;
using UnityEngine;

public class DatChuaController : MonoBehaviour
{
    [Header("Hoạt ảnh đất hồi phục")]
    [SerializeField]
    private Sprite[] framesHoiPhuc;

    [SerializeField]
    private float tocDoFrame = 0.15f;

    [Header("Ẩn toàn bộ gameplay")]
    [SerializeField]
    private GameObject gameplayRoot;

    private SpriteRenderer spriteRenderer;

    private bool dangChayHoatAnh;

    private void Awake()
    {
        spriteRenderer =
            GetComponent<SpriteRenderer>();
    }

    public void XuLyDungDich(
        CocNuocController cocNuoc)
    {
        if (dangChayHoatAnh)
            return;

        if (cocNuoc == null || !cocNuoc.gameObject.activeInHierarchy)
            return;

        if (!cocNuoc.DaPhanUng)
            return;

        // Đánh dấu đã xử lý để tránh OnTriggerEnter gọi 2 lần trong 1 frame
        cocNuoc.gameObject.SetActive(false);

        // ĐÚNG
        if (cocNuoc.LaChatTotChoDat)
        {
            Destroy(cocNuoc.gameObject);

            StartCoroutine(
                ChayHoatAnhHoiPhuc()
            );
        }
        // SAI
        else
        {
            ChallengeGameManager.Instance.TruDiem(10);

            Destroy(cocNuoc.gameObject);
        }
    }

    private IEnumerator ChayHoatAnhHoiPhuc()
    {
        dangChayHoatAnh = true;

        if (gameplayRoot != null)
        {
            gameplayRoot.SetActive(false);
        }

        AnTatCaClone();
        for (int i = 0;
            i < framesHoiPhuc.Length;
            i++)
        {
            spriteRenderer.sprite =
                framesHoiPhuc[i];

            yield return new WaitForSeconds(
                tocDoFrame
            );
        }

        yield return new WaitForSeconds(
            1f
        );

        if (gameplayRoot != null)
        {
            gameplayRoot.SetActive(true);
        }
        HienTatCaClone();
        dangChayHoatAnh = false;
    }
    private void AnTatCaClone()
    {
        string[] tags =
        {
        "ChaiNuoc",
        "CocNuoc",
        "CocRong",
        "BaO",
        "CaO",
        "Na2O"
    };

        foreach (string tag in tags)
        {
            GameObject[] ds =
                GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in ds)
            {
                obj.SetActive(false);
            }
        }
    }
    private void HienTatCaClone()
    {
        string[] tags =
        {
        "ChaiNuoc",
        "CocNuoc",
        "CocRong",
        "BaO",
        "CaO",
        "Na2O"
    };

        foreach (string tag in tags)
        {
            GameObject[] ds =
                GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in ds)
            {
                obj.SetActive(true);
            }
        }
    }
}