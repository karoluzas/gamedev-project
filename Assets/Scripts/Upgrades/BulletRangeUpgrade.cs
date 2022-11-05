public class BulletRangeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return bulletCollisions.bulletRange < 5.0f;
    }

    protected override void UpgradeValue()
    {
        bulletCollisions.bulletRange += 1.0f;
    }
}
