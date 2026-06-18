using UnityEngine;

public class HoaChatSpawnManager : MonoBehaviour
{
    public static HoaChatSpawnManager Instance;

    public Transform viTriDatHoaChat;

    private void Awake()
    {
        Instance = this;
    }
}