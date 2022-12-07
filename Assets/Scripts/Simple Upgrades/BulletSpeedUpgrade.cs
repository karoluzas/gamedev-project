public class BulletSpeedUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return rangedController.bulletForce < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        rangedController.bulletForce += UpgradeValue;
    }
}
