using UnityEngine;

public class HoaChatUIManager : MonoBehaviour
{
    public static HoaChatUIManager Instance;

    public GameObject oCacHoaChat;
    public GameObject oBaO;
    public GameObject oCaO;
    public GameObject oNa2O;

    private void Awake()
    {
        Instance = this;
    }
}