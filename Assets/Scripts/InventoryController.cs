using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //Wester Zone Drops
    public int Iron { get; private set; } = 0;
    public int Diamond { get; private set; } = 0;
    public int Obsidian { get; private set; } = 0;
    //Eastern Zone Drops
    public int DemonEgg { get; private set; } = 0;
    public int RottenFlesh { get; private set; } = 0;
    public int OrbsOfAcid { get; private set; } = 0;
    //Southern Zone Drops
    public int Bones { get; private set; } = 0;
    public int LavaOrbs { get; private set; } = 0;
    public int DemonCore { get; private set; } = 0;
    //Enemy Drops
    public int DemonBlood { get; private set; } = 0;

    public void AddRocks(int iron, int diamond, int obsidian){
        Iron += iron;
        Diamond += diamond;
        Obsidian += obsidian;
        PrintInventory();
    }

    public void AddBushes(int demonEgg, int rottenFlesh, int orbsOfAcid){
        DemonEgg += demonEgg;
        RottenFlesh += rottenFlesh;
        OrbsOfAcid += orbsOfAcid;
        PrintInventory();
    }

    public void AddAltairs(int bones, int lavaOrbs, int demonCore){
        Bones += bones;
        LavaOrbs += lavaOrbs;
        DemonCore += demonCore;
        PrintInventory();
    }

    public void AddDemonBlood(int demonBlood){
        DemonBlood += demonBlood;
        PrintInventory();
    }

    private void PrintInventory(){
        //This function is for debugging purposes
        print(
            $"Iron: {Iron} Diamond: {Diamond} Obsidian: {Obsidian}\n" +
            $"Demon Egg: {DemonEgg} Rotten Flesh: {RottenFlesh} Orbs of Acid: {OrbsOfAcid}\n" +
            $"Bones: {Bones } Lava Orbs: {LavaOrbs} Demon Core: {DemonCore}\n" +
            $"Demon Blood - {DemonBlood}");
    }
}
