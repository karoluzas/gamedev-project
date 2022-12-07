public class BoostersFix : SpaceshipFixBase
{
    public int ironNeededForFix = 0;
    public int lavaOrbsNeededForFix = 0;
    public int orbsOfAcidNeededForFix = 0;

    protected override void ApplyFix()
    {
        inventoryController.iron -= ironNeededForFix;
        inventoryController.lavaOrbs -= lavaOrbsNeededForFix;
        inventoryController.orbsOfAcid -= orbsOfAcidNeededForFix;
        FixedText = "Boosters Fixed";
    }

    protected override bool CanFix()
    {
        return inventoryController.iron >= ironNeededForFix
               && inventoryController.lavaOrbs >= lavaOrbsNeededForFix
               && inventoryController.orbsOfAcid >= orbsOfAcidNeededForFix;
    }
}