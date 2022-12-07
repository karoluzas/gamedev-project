public class SwingCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return meleeController.slashCooldown > MaxValue + floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        meleeController.slashCooldown -= UpgradeValue;
    }
}
