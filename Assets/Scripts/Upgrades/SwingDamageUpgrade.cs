public class SwingDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return slashCollisions.damageOnHit <= 15.0f;
    }

    protected override void UpgradeValue()
    {
        slashCollisions.damageOnHit += 0.5f;
    }
}
