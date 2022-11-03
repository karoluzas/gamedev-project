public class SwingCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.slashCooldown >= 0.3f;
    }

    protected override void UpgradeValue()
    {
        meleeController.slashCooldown -= 0.1f;
    }
}
