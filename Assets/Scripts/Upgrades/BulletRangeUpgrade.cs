public class BulletRangeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return bulletCollisions.bulletRange <= 2.0f;
    }

    protected override void UpgradeValue()
    {
        bulletCollisions.bulletRange += 0.25f;
    }
}
