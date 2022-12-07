public class SwingSizeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return meleeController.slashSize < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        meleeController.slashSize += UpgradeValue;
    }
}
