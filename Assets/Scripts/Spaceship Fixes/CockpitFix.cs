using TMPro;
using UnityEngine;

public class CockpitFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int BonesNeededForFix = 0;
    public int DiamondNeededForFix = 0;

    public GameObject IronValueText;
    public GameObject BonesValueText;
    public GameObject DiamondValueText;

    protected override void InitializeValueText()
    {
        var ironValueTextMeshPro = IronValueText.GetComponent<TextMeshProUGUI>();
        ironValueTextMeshPro.SetText($"{IronNeededForFix} x");
        var bonesValueTextMeshPro = BonesValueText.GetComponent<TextMeshProUGUI>();
        bonesValueTextMeshPro.SetText($"{BonesNeededForFix} x");
        var diamondValueTextMeshPro = DiamondValueText.GetComponent<TextMeshProUGUI>();
        diamondValueTextMeshPro.SetText($"{DiamondNeededForFix} x");
    }

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