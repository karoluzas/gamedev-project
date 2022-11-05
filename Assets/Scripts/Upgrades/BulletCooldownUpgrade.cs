using System;

public class BulletCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.fireCooldown > MaxValue + floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        rangedController.fireCooldown -= UpgradeValue;
    }
}
