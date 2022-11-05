public class BulletDamageUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.damageOnHit < 15.0f;
    }

    protected override void UpgradeValue()
    {
        rangedController.damageOnHit += 1.0f;
    }
}
