public class BoostersFix : SpaceshipFixBase
{
    public int IronNeededForFix = 0;
    public int LavaOrbsNeededForFix = 0;
    public int OrbsOfAcidNeededForFix = 0;

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