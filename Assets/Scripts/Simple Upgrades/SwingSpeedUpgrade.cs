public class SwingSpeedUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return meleeController.slashSpeed < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        meleeController.slashSpeed += UpgradeValue;
    }
}
