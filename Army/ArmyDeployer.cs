using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyDeployer : MonoBehaviour
{
    Army armyInProgress;

    private void Start()
    {
        armyInProgress = new Army(0,0,0,0,0,0,0,0,0);
    }


    private void OnEnable()
    {
        armyInProgress.Reset();
    }

    #region SEt methods
    public void SetSwordmen(int soldiers)
    {
        armyInProgress.Swordmen = soldiers;
    }
    public void SetSpearmen(int soldiers)
    {
        armyInProgress.Spearmen = soldiers;
    }
    public void SetHorsemen(int soldiers)
    {
        armyInProgress.Horsemen = soldiers;
    }
    public void SetArcherShort(int soldiers)
    {
        armyInProgress.ArchersShortBow = soldiers;
    }

    public void SetArcherLong(int soldiers)
    {
        armyInProgress.ArcherLongBow = soldiers;
    }

    public void SetKnightFoot(int soldiers)
    {
        armyInProgress.KnightOnFoot = soldiers;
    }

    public void SetknightSword(int soldiers)
    {
        armyInProgress.KnightOnStallionSword = soldiers;
    }

    public void SetKnightSpear(int soldiers)
    {
        armyInProgress.KnightOnStallionSpear = soldiers;
    }

    public void SetMonster(int soldiers)
    {
        armyInProgress.Monsters = soldiers;
    }
    #endregion




}
