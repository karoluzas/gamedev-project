public class BulletDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.damageOnHit < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        rangedController.damageOnHit += UpgradeValue;
    }
}
