public class SwingSizeUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        return meleeController.slashSize < 2.0f - floatingPointAllowedDeviation;
    }

    protected override void UpgradeValue()
    {
        meleeController.slashSize += 0.5f;
    }
}
