using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Health healthComponent;
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHP()
    {
        healthText.SetText(healthComponent.health.ToString());
    }
}
