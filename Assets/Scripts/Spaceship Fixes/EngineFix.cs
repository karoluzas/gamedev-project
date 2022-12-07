using TMPro;
using UnityEngine;

public class EngineFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int ObsidianNeededForFix = 0;
    public int DemonCoreNeededForFix = 0;

    public GameObject IronValueText;
    public GameObject ObsidianValueText;
    public GameObject DemonCoreValueText;

    protected override void InitializeValueText()
    {
        var ironValueTextMeshPro = IronValueText.GetComponent<TextMeshProUGUI>();
        ironValueTextMeshPro.SetText($"{IronNeededForFix} x");
        var obsidianValueTextMeshPro = ObsidianValueText.GetComponent<TextMeshProUGUI>();
        obsidianValueTextMeshPro.SetText($"{ObsidianNeededForFix} x");
        var demonCoreValueTextMeshPro = DemonCoreValueText.GetComponent<TextMeshProUGUI>();
        demonCoreValueTextMeshPro.SetText($"{DemonCoreNeededForFix} x");
    }

    protected override void ApplyFix()
    {
        inventoryController.iron -= IronNeededForFix;
        inventoryController.obsidian -= ObsidianNeededForFix;
        inventoryController.demonCore -= DemonCoreNeededForFix;
        fixedText = "Engine Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= IronNeededForFix
               && inventoryController.obsidian >= ObsidianNeededForFix
               && inventoryController.demonCore >= DemonCoreNeededForFix;
    }
}