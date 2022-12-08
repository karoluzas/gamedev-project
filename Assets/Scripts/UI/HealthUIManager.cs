using UnityEngine;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI healthText;

    public void UpdateHealth(int health)
    {
        healthText.text = health.ToString();
    }
}
