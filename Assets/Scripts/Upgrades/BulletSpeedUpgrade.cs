public class BulletSpeedUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.bulletForce < 20.0f - floatingPointAllowedDeviation;
    }

    protected override void UpgradeValue()
    {
        rangedController.bulletForce += 2.5f;
    }
}
