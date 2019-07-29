using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmyBuilder : MonoBehaviour
{
    public FactionArmy factionArmy;
    public GameObject lockerImg;
    public Button b_Recruit;

    public int swordmen;
    public int spearmen;
    public int horsemen;
    public int archersShortBow;
    public int archerLongBow;
    public int knightOnFoot;
    public int knightOnStallionSword;
    public int knightOnStallionSpear;
    public int monsters;

    //methods for extract the strings in the inputs fields
    public void SetSwordmen(string s)
    {
        swordmen = int.Parse(s);
        UpdateUi();
    }
    public void SetSpearmen(string s)
    {
        spearmen = int.Parse(s);
        UpdateUi();
    }
    public void SetHorsemen(string s)
    {
        horsemen = int.Parse(s);
        UpdateUi();
    }
    public void SetArcherShortBow(string s)
    {
        archersShortBow = int.Parse(s);
        UpdateUi();
    }
    public void SetArcherLongBow(string s)
    {
        archerLongBow = int.Parse(s);
        UpdateUi();
    }
    public void SetknightOnFoot(string s)
    {
        knightOnFoot = int.Parse(s);
        UpdateUi();
    }
    public void SetKnightOnSttallionSword(string s)
    {
        knightOnStallionSword = int.Parse(s);
        UpdateUi();
    }
    public void SetKnightOnStallionSpear(string s)
    {
        knightOnStallionSpear = int.Parse(s);
        UpdateUi();
    }
    public void SetMonster(string s)
    {
        monsters = int.Parse(s);
        UpdateUi();
    }

    public void UpdateUi()
    {
        if (factionArmy.UpdateArmy(false, swordmen, spearmen, horsemen, archersShortBow, archerLongBow, knightOnFoot, knightOnStallionSword, knightOnStallionSpear, monsters))
        {
            lockerImg.SetActive(false);
            b_Recruit.enabled=true;
        }
        else
        {
            lockerImg.SetActive(true);
            b_Recruit.enabled = false;
        }
    }

    public void Recruit()// double safety in the recruitment.
    {
        factionArmy.UpdateArmy(true, swordmen, spearmen, horsemen, archersShortBow, archerLongBow, knightOnFoot, knightOnStallionSword, knightOnStallionSpear, monsters);
    }

}
