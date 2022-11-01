using UnityEngine;

public class SimpleUpgradesController : MonoBehaviour
{
    public SimpleUpgrades SimpleUpgrades;

    public void UpgradeBulletCooldown()
    {
        SimpleUpgrades.RangedWeaponUpgrades.Cooldown *= 1.5f;
    }
}
