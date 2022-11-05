using UnityEngine;

public abstract class SimpleUpgradeBase : MonoBehaviour
{
    protected RangedController rangedController;
    protected MeleeController meleeController;
    protected float floatingPointAllowedDeviation = 0.0001f;

    public bool MaxUpgradeReached = false;

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
            UpgradeValue();
        }
        else
        {
            MaxUpgradeReached = true;
        }
    }

    protected abstract bool CanUpgrade();
    
    protected abstract void UpgradeValue();
}
