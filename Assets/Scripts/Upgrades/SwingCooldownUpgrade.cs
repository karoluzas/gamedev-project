public class SwingCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.slashCooldown > 0.1f + floatingPointAllowedDeviation;
    }

    protected override void UpgradeValue()
    {
        meleeController.slashCooldown -= 0.1f;
    }
}
