public class EngineFix : SpaceshipFixBase
{
    public int ironNeededForFix = 0;
    public int obsidianNeededForFix = 0;
    public int demonCoreNeededForFix = 0;

    protected override void ApplyFix()
    {
        inventoryController.iron -= ironNeededForFix;
        inventoryController.obsidian -= obsidianNeededForFix;
        inventoryController.demonCore -= demonCoreNeededForFix;
        FixedText = "Engine Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= ironNeededForFix
               && inventoryController.obsidian >= obsidianNeededForFix
               && inventoryController.demonCore >= demonCoreNeededForFix;
    }
}