public class BulletRangeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return rangedController.bulletRange < 5.0f;
    }

    protected override void UpgradeValue()
    {
        rangedController.bulletRange += 1.0f;
    }
}
