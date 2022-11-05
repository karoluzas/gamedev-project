public class SwingDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.damageOnHit < 15.0f - floatingPointAllowedDeviation;
    }

    protected override void UpgradeValue()
    {
        meleeController.damageOnHit += 2.5f;
    }
}
