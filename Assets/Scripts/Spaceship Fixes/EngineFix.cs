using UnityEngine;

public class EngineFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int ObsidianNeededForFix = 0;
    public int DemonCoreNeededForFix = 0;

    public GameObject IronValueText;
    public GameObject ObsidianValueText;
    public GameObject DemonCoreValueText;

    protected override bool IsFixed => spaceshipFixesManager.IsEngineFixed;
    protected override string FixedText => spaceshipFixesManager.EngineFixedText;

    protected override void InitializeValueText()
    {
        SetText(IronValueText, IronNeededForFix);
        SetText(ObsidianValueText, ObsidianNeededForFix);
        SetText(DemonCoreValueText, DemonCoreNeededForFix);
    }

    protected override void ApplyFix()
    {
        inventoryController.iron -= IronNeededForFix;
        inventoryController.obsidian -= ObsidianNeededForFix;
        inventoryController.demonCore -= DemonCoreNeededForFix;
        spaceshipFixesManager.IsEngineFixed = true;
        spaceshipFixesManager.EngineFixedText = "Engine Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= IronNeededForFix
               && inventoryController.obsidian >= ObsidianNeededForFix
               && inventoryController.demonCore >= DemonCoreNeededForFix;
    }
}