using UnityEngine;

public class CocRongController : MonoBehaviour
{
    private bool dangOChoLayNuoc;

    private ChaiNuocController chaiDangGan;
    private HCLBottleController hclDangGan;

    public bool DangOChoLayNuoc
    {
        get { return dangOChoLayNuoc; }
    }

    public ChaiNuocController ChaiDangGan
    {
        get { return chaiDangGan; }
    }

    public HCLBottleController HCLDangGan
    {
        get { return hclDangGan; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        // ===== LabScene =====
        if (other.CompareTag("WaterZone"))
        {
            Debug.Log("Đã vào WaterZone");

            dangOChoLayNuoc = true;

            if (VoiNuocController.Instance != null)
            {
                VoiNuocController.Instance.DatCoc(this);
            }
        }

        // ===== ChallengeScene =====
        if (other.CompareTag("ChaiNuoc"))
        {
            Debug.Log("Đã chạm ChaiNuoc");

            dangOChoLayNuoc = true;

            chaiDangGan =
                other.GetComponent<ChaiNuocController>();
        }

        // ===== HCL Bottle =====
        if (other.CompareTag("HCL"))
        {
            Debug.Log("Đã chạm HCL");

            dangOChoLayNuoc = true;

            hclDangGan =
                other.GetComponent<HCLBottleController>();

            if (hclDangGan != null)
            {
                hclDangGan.KiemTraHCL();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ===== LabScene =====
        if (other.CompareTag("WaterZone"))
        {
            dangOChoLayNuoc = false;

            if (VoiNuocController.Instance != null)
            {
                VoiNuocController.Instance.BoCoc();
            }
        }

        // ===== ChallengeScene =====
        if (other.CompareTag("ChaiNuoc"))
        {
            dangOChoLayNuoc = false;

            chaiDangGan = null;
        }

        // ===== HCL Bottle =====
        if (other.CompareTag("HCL"))
        {
            dangOChoLayNuoc = false;

            hclDangGan = null;
        }
    }
}