public class SwingSizeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.slashSize <= 2.0f;
    }

    protected override void UpgradeValue()
    {
        meleeController.slashSize += 0.1f;
    }
}
