using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army 
{
    int index;
    string general;
    int swordmen;
    int spearmen;
    int horsemen;
    int archersShortBow;
    int archerLongBow;
    int knightOnFoot;
    int knightOnStallionSword;
    int knightOnStallionSpear;
    int monsters;  

    public int Index { get => index; set => index = value; }
    public string General { get => general; set => general = value; }
    public int Swordmen { get => swordmen; set => swordmen = value; }
    public int Spearmen { get => spearmen; set => spearmen = value; }
    public int Horsemen { get => horsemen; set => horsemen = value; }
    public int ArchersShortBow { get => archersShortBow; set => archersShortBow = value; }
    public int ArcherLongBow { get => archerLongBow; set => archerLongBow = value; }
    public int KnightOnFoot { get => knightOnFoot; set => knightOnFoot = value; }
    public int KnightOnStallionSword { get => knightOnStallionSword; set => knightOnStallionSword = value; }
    public int KnightOnStallionSpear { get => knightOnStallionSpear; set => knightOnStallionSpear = value; }
    public int Monsters { get => monsters; set => monsters = value; }


    public Army(int swordmen, int spearmen, int horsemen, int archersShortBow, int archerLongBow,
      int knightOnFoot, int knightOnStallionSword, int knightOnStallionSpear, int monsters)
    {
        this.Swordmen = swordmen;
        this.Spearmen = spearmen;
        this.Horsemen = horsemen;
        this.ArcherLongBow = archerLongBow;
        this.ArchersShortBow = archersShortBow;
        this.KnightOnFoot = knightOnFoot;
        this.KnightOnStallionSword = knightOnStallionSword;
        this.KnightOnStallionSpear = knightOnStallionSpear;
        this.Monsters = monsters;
    }

    public void Reset()
    {
        this.Swordmen = 0;
        this.Spearmen = 0;
        this.Horsemen = 0;
        this.ArcherLongBow = 0;
        this.ArchersShortBow = 0;
        this.KnightOnFoot = 0;
        this.KnightOnStallionSword = 0;
        this.KnightOnStallionSpear = 0;
        this.Monsters = 0;
    }
}
