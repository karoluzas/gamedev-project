public class SwingDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.damageOnHit < MaxValue - floatingPointAllowedDeviation;
    }

    protected override void ApplyUpgrade()
    {
        meleeController.damageOnHit += UpgradeValue;
    }
}
