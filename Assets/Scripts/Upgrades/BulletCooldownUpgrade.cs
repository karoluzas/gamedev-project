using System;

public class BulletCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.fireCooldown > 0.1f + floatingPointAllowedDeviation;
    }

    protected override void UpgradeValue()
    {
        rangedController.fireCooldown -= 0.1f;
    }
}
