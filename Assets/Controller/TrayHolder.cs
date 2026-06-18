using UnityEngine;

public class TrayHolder : MonoBehaviour
{
    public Transform spawnPoint;

    public static TrayHolder currentTray;

    void Start()
    {
        currentTray = this;
    }
}