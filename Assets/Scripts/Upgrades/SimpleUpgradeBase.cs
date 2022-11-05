using UnityEngine;

public abstract class SimpleUpgradeBase : MonoBehaviour
{
    protected RangedController rangedController;
    protected MeleeController meleeController;
    protected float floatingPointAllowedDeviation = 0.0001f;

    public float MaxValue = 0f;
    public float UpgradeValue = 0f;
    public bool MaxUpgradeReached { get; private set; } = false;

    protected void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            var playerController = player.GetComponent<PlayerController>();
            rangedController = playerController.aimTransform.GetComponent<RangedController>();
            meleeController = playerController.aimTransform.GetComponent<MeleeController>();
        }
    }

    public void Upgrade()
    {
        if (CanUpgrade())
        {
            ApplyUpgrade();
        }
        else
        {
            MaxUpgradeReached = true;
        }
    }

    protected abstract bool CanUpgrade();
    
    protected abstract void ApplyUpgrade();
}
