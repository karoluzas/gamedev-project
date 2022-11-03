using UnityEngine;

public class SimpleUpgradesController : MonoBehaviour
{
    public void UpgradeBulletCooldown()
    {
        if (RangedWeaponUpgrades.Cooldown >= 0.3f)
        {
            RangedWeaponUpgrades.Cooldown -= 0.1f;
        }
    }

    public void UpgradeBulletDamage()
    {
        if (RangedWeaponUpgrades.Damage <= 15.0f)
        {
            RangedWeaponUpgrades.Damage += 0.5f;
        }
    }

    public void UpgradeBulletRange()
    {
        if (RangedWeaponUpgrades.BulletRange <= 2.0f)
        {
            RangedWeaponUpgrades.BulletRange += 0.25f;
        }
        
    }

    public void UpgradeBulletSpeed()
    {
        if (RangedWeaponUpgrades.BulletSpeed <= 2.0f)
        {
            RangedWeaponUpgrades.BulletSpeed += 0.1f;
        }
    }

    public void UpgradeSwingCooldown()
    {
        if (MeleeWeaponUpgrades.Cooldown >= 0.3f)
        {
            MeleeWeaponUpgrades.Cooldown -= 0.1f;
        }
    }

    public void UpgradeSwingDamage()
    {
        if (MeleeWeaponUpgrades.Damage <= 15.0f)
        {
            MeleeWeaponUpgrades.Damage += 0.5f;
        }
    }

    public void UpgradeSwingSize()
    {
        if (MeleeWeaponUpgrades.SwingSize <= 2.0f)
        {
            MeleeWeaponUpgrades.SwingSize += 0.1f;
        }
    }

    public void UpgradeSwingSpeed()
    {
        if (MeleeWeaponUpgrades.SwingSpeed <= 2.0f)
        {
            MeleeWeaponUpgrades.SwingSpeed += 0.1f;
        }
    }
}
