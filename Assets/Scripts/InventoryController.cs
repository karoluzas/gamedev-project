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
        print(this.iron + " " + this.diamond + " " + this.obsidian);
    }
    public void AddBushes(int demonEgg, int rottenFlesh, int orbsOfAcid){
        this.demonEgg += demonEgg;
        this.rottenFlesh += rottenFlesh;
        this.orbsOfAcid += orbsOfAcid;
        print(this.demonEgg + " " + this.rottenFlesh + " " + this.orbsOfAcid);
    }
    public void AddAltairs(int bones, int lavaOrbs, int demonCore){
        this.bones += bones;
        this.lavaOrbs += lavaOrbs;
        this.demonCore += demonCore;
        print(this.bones + " " + this.lavaOrbs + " " + this.demonCore);
    }
    public void AddDemonBlood(int demonBlood){
        this.demonBlood += demonBlood;
        print("Current demon blood: " + this.demonBlood);
    }
}
