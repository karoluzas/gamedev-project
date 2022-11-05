public class SwingDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return slashCollisions.damageOnHit < 15.0f - floatingPointAllowedDeviation;
    }

    protected override void UpgradeValue()
    {
        slashCollisions.damageOnHit += 2.5f;
    }
}
