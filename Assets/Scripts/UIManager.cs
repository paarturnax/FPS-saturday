using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private HealthBar playerHealthBar;
    [SerializeField] private TMP_Text ammoText;

    public void SetHealth(float value)
    {
        playerHealthBar.SetValue(value);
    }

    public void SetAmmo(int value)
    {
        ammoText.text = $"{value}";
    }
}
