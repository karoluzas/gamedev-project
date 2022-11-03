public class BulletCooldownUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.fireCooldown >= 0.3f;
    }

    protected override void UpgradeValue()
    {
        rangedController.fireCooldown -= 0.1f;
    }
}
