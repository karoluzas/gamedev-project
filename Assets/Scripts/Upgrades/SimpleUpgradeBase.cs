using UnityEngine;

public abstract class SimpleUpgradeBase : MonoBehaviour
{
    protected RangedController rangedController;
    protected MeleeController meleeController;
    protected BulletCollisions bulletCollisions;
    protected SlashCollisions slashCollisions;

    public bool MaxUpgradeReached = false;

    protected void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            var playerController = player.GetComponent<PlayerController>();
            rangedController = playerController.aimTransform.GetComponent<RangedController>();
            meleeController = playerController.aimTransform.GetComponent<MeleeController>();
            bulletCollisions = rangedController.GetComponent<BulletCollisions>();
            slashCollisions = meleeController.GetComponent<SlashCollisions>();
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
