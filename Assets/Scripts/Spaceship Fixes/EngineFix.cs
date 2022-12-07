public class EngineFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int ObsidianNeededForFix = 0;
    public int DemonCoreNeededForFix = 0;

    protected override void ApplyFix()
    {
        inventoryController.iron -= IronNeededForFix;
        inventoryController.obsidian -= ObsidianNeededForFix;
        inventoryController.demonCore -= DemonCoreNeededForFix;
        FixedText = "Engine Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= IronNeededForFix
               && inventoryController.obsidian >= ObsidianNeededForFix
               && inventoryController.demonCore >= DemonCoreNeededForFix;
    }
}