public class SwingSpeedUpgrade : SimpleUpgradeBase
{
    protected override bool CanUpgrade()
    {
        //return meleeController.slashSpeed < 2.0f; //Todo implement swing speed
        return false;
    }

    protected override void UpgradeValue()
    {
        //return meleeController.slashSpeed += 0.1f; //Todo implement swing speed
    }
}
