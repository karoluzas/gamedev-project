public class BulletDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return bulletCollisions.damageOnHit <= 15.0f;
    }

    protected override void UpgradeValue()
    {
        bulletCollisions.damageOnHit += 0.5f;
    }
}
