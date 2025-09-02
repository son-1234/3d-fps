using UnityEngine;

public class GlobalAmmo : MonoBehaviour
{
    public static int handgunAmmoCount = 10;
    [SerializeField] private GameObject ammoDisplay;
    void Update()
    {
        ammoDisplay.GetComponent<TMPro.TMP_Text>().text ="" + handgunAmmoCount;
    }
}
