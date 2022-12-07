using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SimpleUpgradeBase : MonoBehaviour
{
    private InventoryController inventoryController;
    protected RangedController rangedController;
    protected MeleeController meleeController;
    protected float floatingPointAllowedDeviation = 0.0001f;

    public int DemonBloodNeededForUpgrade = 0;
    public float MaxValue = 0f;
    public float UpgradeValue = 0f;
    public GameObject UpgradeButton;
    public GameObject UpgradeValueText;

    protected void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            var playerController = player.GetComponent<PlayerController>();
            rangedController = playerController.aimTransform.GetComponent<RangedController>();
            meleeController = playerController.aimTransform.GetComponent<MeleeController>();
            inventoryController = playerController.GetComponent<InventoryController>();
        }
        var textMeshPro = UpgradeValueText.GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText($"{DemonBloodNeededForUpgrade} x");
    }

    protected void Update()
    {
        var button = UpgradeButton.GetComponent<Button>();
        if (!IsGatherableAmountEnoughForUpgrade() || !CanUpgradeUpToMaxValue())
        {
            button.interactable = false;
            if (!CanUpgradeUpToMaxValue())
            {
                var textMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
                textMeshPro.SetText("Max upgrade reached");
            }
        }
        else
        {
            button.interactable = true;
        }
    }

    public void Upgrade()
    {
        if (IsGatherableAmountEnoughForUpgrade() && CanUpgradeUpToMaxValue())
        {
            ApplyUpgrade();
            inventoryController.demonBlood -= DemonBloodNeededForUpgrade;
        }
    }

    private bool IsGatherableAmountEnoughForUpgrade()
    {
        return inventoryController.demonBlood >= DemonBloodNeededForUpgrade;
    }

    protected abstract bool CanUpgradeUpToMaxValue();
    
    protected abstract void ApplyUpgrade();
}
