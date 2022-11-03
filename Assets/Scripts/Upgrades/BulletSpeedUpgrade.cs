public class BulletSpeedUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.bulletForce <= 2.0f;
    }

    protected override void UpgradeValue()
    {
        rangedController.bulletForce += 0.1f;
    }
}
