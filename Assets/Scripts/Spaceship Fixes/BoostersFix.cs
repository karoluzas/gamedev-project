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
        var ironValueTextMeshPro = IronValueText.GetComponent<TextMeshProUGUI>();
        ironValueTextMeshPro.SetText($"{IronNeededForFix} x");
        var lavaOrbsValueTextMeshPro = LavaOrbsValueText.GetComponent<TextMeshProUGUI>();
        lavaOrbsValueTextMeshPro.SetText($"{LavaOrbsNeededForFix} x");
        var orbsOfAcidValueTextMeshPro = OrbsOfAcidValueText.GetComponent<TextMeshProUGUI>();
        orbsOfAcidValueTextMeshPro.SetText($"{OrbsOfAcidNeededForFix} x");
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