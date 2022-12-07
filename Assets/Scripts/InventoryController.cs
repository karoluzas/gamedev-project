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

    public void AddRocks(int iron, int diamond, int obsidian){
        this.iron += iron;
        this.diamond += diamond;
        this.obsidian += obsidian;
    }

    public void AddBushes(int demonEgg, int rottenFlesh, int orbsOfAcid){
        this.demonEgg += demonEgg;
        this.rottenFlesh += rottenFlesh;
        this.orbsOfAcid += orbsOfAcid;
    }

    public void AddAltairs(int bones, int lavaOrbs, int demonCore){
        this.bones += bones;
        this.lavaOrbs += lavaOrbs;
        this.demonCore += demonCore;
    }

    public void AddDemonBlood(int demonBlood){
        this.demonBlood += demonBlood;
    }
}
