public class SwingDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgradeUpToMaxValue()
    {
        return meleeController.damageOnHit < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        meleeController.damageOnHit += UpgradeValue;
    }
}
