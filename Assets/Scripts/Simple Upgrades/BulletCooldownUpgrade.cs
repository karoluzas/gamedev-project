public class BulletCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return rangedController.fireCooldown > MaxValue + floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        rangedController.fireCooldown -= UpgradeValue;
    }
}
