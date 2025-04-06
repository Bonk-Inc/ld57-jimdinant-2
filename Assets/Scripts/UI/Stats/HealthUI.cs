using Bonk.StandardLibrary;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    public void UpdateHealth(Health.OnHealthChangedEventArgs health)
    {
        healthText.text = Mathf.RoundToInt(health.NewHealth / 100f).ToString();
    }
}
