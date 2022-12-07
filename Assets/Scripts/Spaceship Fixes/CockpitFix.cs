public class CockpitFix : SpaceshipFixBase
{
    public int ironNeededForFix = 0;
    public int bonesNeededForFix = 0;
    public int diamondNeededForFix = 0;

    protected override void ApplyFix()
    {
        inventoryController.iron -= ironNeededForFix;
        inventoryController.bones -= bonesNeededForFix;
        inventoryController.diamond -= diamondNeededForFix;
        FixedText = "Cockpit Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= ironNeededForFix
               && inventoryController.bones >= bonesNeededForFix
               && inventoryController.diamond >= diamondNeededForFix;
    }
}