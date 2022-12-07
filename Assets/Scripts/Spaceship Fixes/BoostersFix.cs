using TMPro;
using UnityEngine;

public class BoostersFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int LavaOrbsNeededForFix = 0;
    public int OrbsOfAcidNeededForFix = 0;

    public GameObject IronValueText;
    public GameObject LavaOrbsValueText;
    public GameObject OrbsOfAcidValueText;

    protected override void InitializeValueText()
    {
        SetText(IronValueText, IronNeededForFix);
        SetText(LavaOrbsValueText, LavaOrbsNeededForFix);
        SetText(OrbsOfAcidValueText, OrbsOfAcidNeededForFix);
    }

    protected override void ApplyFix()
    {
        inventoryController.iron -= IronNeededForFix;
        inventoryController.lavaOrbs -= LavaOrbsNeededForFix;
        inventoryController.orbsOfAcid -= OrbsOfAcidNeededForFix;
        fixedText = "Boosters Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= IronNeededForFix
               && inventoryController.lavaOrbs >= LavaOrbsNeededForFix
               && inventoryController.orbsOfAcid >= OrbsOfAcidNeededForFix;
    }
}