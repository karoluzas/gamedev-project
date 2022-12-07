public class BulletRangeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.bulletRange < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        rangedController.bulletRange += UpgradeValue;
    }
}
