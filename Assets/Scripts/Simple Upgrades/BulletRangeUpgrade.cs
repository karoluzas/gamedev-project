public class BulletRangeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return rangedController.bulletRange < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        rangedController.bulletRange += UpgradeValue;
    }
}
