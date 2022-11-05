public class SwingSpeedUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        //return meleeController.slashSpeed < MaxValue - floatingPointAllowedDeviation; //Todo implement swing speed
        return false;
    }

    protected override void ApplyUpgrade()
    {
        //return meleeController.slashSpeed += UpgradeValue; //Todo implement swing speed
    }
}
