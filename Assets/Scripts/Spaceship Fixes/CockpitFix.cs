public class CockpitFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int BonesNeededForFix = 0;
    public int DiamondNeededForFix = 0;

    protected override void ApplyFix()
    {
        inventoryController.iron -= IronNeededForFix;
        inventoryController.bones -= BonesNeededForFix;
        inventoryController.diamond -= DiamondNeededForFix;
        fixedText = "Cockpit Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= IronNeededForFix
               && inventoryController.bones >= BonesNeededForFix
               && inventoryController.diamond >= DiamondNeededForFix;
    }
}