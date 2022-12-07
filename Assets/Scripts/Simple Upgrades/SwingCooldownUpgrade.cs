public class SwingCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.slashCooldown > MaxValue + floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        meleeController.slashCooldown -= UpgradeValue;
    }
}
