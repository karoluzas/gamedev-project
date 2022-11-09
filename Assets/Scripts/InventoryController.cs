using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private int iron = 0;
    private int diamond = 0;
    private int obsidian = 0;

    public void AddRocks(int iron, int diamond, int obsidian){
        this.iron += iron;
        this.diamond += diamond;
        this.obsidian += obsidian;
        print(this.iron + " " + this.diamond + " " + this.obsidian);
    }
}
