using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //Wester Zone Drops
    private int iron = 0;
    private int diamond = 0;
    private int obsidian = 0;
    //Eastern Zone Drops
    private int demonEgg = 0;
    private int rottenFlesh = 0;
    private int orbsOfAcid = 0;
    //Southern Zone Drops
    private int bones = 0;
    private int lavaOrbs = 0;
    private int demonCore = 0;
    //Enemy Drops
    private int demonBlood = 0;

    public void AddRocks(int iron, int diamond, int obsidian){
        this.iron += iron;
        this.diamond += diamond;
        this.obsidian += obsidian;
        PrintInventory();
    }
    public void AddBushes(int demonEgg, int rottenFlesh, int orbsOfAcid){
        this.demonEgg += demonEgg;
        this.rottenFlesh += rottenFlesh;
        this.orbsOfAcid += orbsOfAcid;
        PrintInventory();
    }
    public void AddAltairs(int bones, int lavaOrbs, int demonCore){
        this.bones += bones;
        this.lavaOrbs += lavaOrbs;
        this.demonCore += demonCore;
        PrintInventory();
    }
    public void AddDemonBlood(int demonBlood){
        this.demonBlood += demonBlood;
        PrintInventory();
    }

    private void PrintInventory(){
        //This function is for debugging purposes
        print("Iron: " + this.iron + " Diamond: " + this.diamond + " Obsidian: " + this.obsidian);
        print("Demon Egg: " + this.demonEgg + " Rotten Flesh: " + this.rottenFlesh + " Orbs of Acid: " + this.orbsOfAcid);
        print("Bones: " + this.bones + " Lava Orbs: " + this.lavaOrbs + " Demon Core: " + this.demonCore);
        print("Demon Blood - " + this.demonBlood);
    }
}
