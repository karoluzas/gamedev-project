using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //Wester Zone Drops
    public int iron = 0;
    public int diamond = 0;
    public int obsidian = 0;
    //Eastern Zone Drops
    public int demonEgg = 0;
    public int rottenFlesh = 0;
    public int orbsOfAcid = 0;
    //Southern Zone Drops
    public int bones = 0;
    public int lavaOrbs = 0;
    public int demonCore = 0;
    //Enemy Drops
    public int demonBlood = 0;

    public void AddRocks(int iron, int diamond, int obsidian)
    {
        this.iron += iron;
        this.diamond += diamond;
        this.obsidian += obsidian;
        print("WESTERN ZONE" + this.iron + " " + this.diamond + " " + this.obsidian );
    }

    public void AddBushes(int demonEgg, int rottenFlesh, int orbsOfAcid)
    {
        this.demonEgg += demonEgg;
        this.rottenFlesh += rottenFlesh;
        this.orbsOfAcid += orbsOfAcid;
        print("EASTERN ZONE" + this.demonEgg + " " + this.rottenFlesh + " " + this.orbsOfAcid);
    }

    public void AddAltairs(int bones, int lavaOrbs, int demonCore)
    {
        this.bones += bones;
        this.lavaOrbs += lavaOrbs;
        this.demonCore += demonCore;
        print("SOUTHERN ZONE" + this.bones + " " + this.lavaOrbs + " " + this.demonCore );
    }

    public void AddDemonBlood(int demonBlood)
    {
        this.demonBlood += demonBlood;
        print("DEMON BLOOD" + this.demonBlood);
    }
}
