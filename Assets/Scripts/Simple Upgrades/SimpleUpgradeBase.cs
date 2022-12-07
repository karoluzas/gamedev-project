using UnityEngine;

public abstract class SimpleUpgradeBase : MonoBehaviour
{
    private InventoryController inventoryController;
    protected RangedController rangedController;
    protected MeleeController meleeController;
    protected float floatingPointAllowedDeviation = 0.0001f;
    
    public bool MaxUpgradeReached { get; private set; } = false;
    public string MaxUpgradeReachedText { get; private set; }

    public int DemonBloodNeededForUpgrade = 0;
    public float MaxValue = 0f;
    public float UpgradeValue = 0f;

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
    }

    public void Upgrade()
    {
        if (IsGatherableAmountEnoughForUpgrade() && CanUpgradeUpToMaxValue())
        {
            ApplyUpgrade();
            inventoryController.demonBlood -= DemonBloodNeededForUpgrade;
            if (!CanUpgradeUpToMaxValue())
            {
                MaxUpgradeReached = true;
                MaxUpgradeReachedText = "Max upgrade reached";
            }
        }
    }

    private bool IsGatherableAmountEnoughForUpgrade()
    {
        return inventoryController.demonBlood >= DemonBloodNeededForUpgrade;
    }

    protected abstract bool CanUpgradeUpToMaxValue();
    
    protected abstract void ApplyUpgrade();
}
