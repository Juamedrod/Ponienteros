using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Faction)),System.Serializable]
public class FactionArmy : MonoBehaviour
{
    public static FactionArmy factionArmy;
    Faction faction;
    [Header("Units Costs Settings")]
    public int basicSoldiersCost = 1;
    public int spearmenCost = 3;
    public int knightCost = 4;
    public int knightSwordCost = 6;
    public int knightSpearCost = 10;
    public int monstersCost = 200000;

    [Header("Units Poblation Costs Settings")]
    public int poblationSoldiersCost = 1;
    public int poblationAdvancedCost = 4;

    [Header("Total Army")]
    public int totalArmy;

    [Header("Faction Army")]//Armies possibilities in general for everyfaction.
    public int swordmen;//cost 1GS
    public int spearmen;//3 goldenScorpions
    public int horsemen;//1 GS
    public int archersShortBow;//1GS
    public int archerLongBow;//1GS
    public int knightOnFoot;//4GS
    public int knightOnStallionSword;//6GS
    public int knightOnStallionSpear;//10GS
    public int monsters;//All monsters cost 200000GS each
    
    [Header("Army Ranks")]//unit ranks
    public int swordRank;
    public int spearRank;
    public int monstersRank;
    public int knightsRank;

    private void Awake()
    {
        if (factionArmy == null)
        {
            factionArmy = this;
        }
        else
        {
            Destroy(this);
        }
    }


    private void Start()
    {
        faction = GetComponent<Faction>();

    }

    public bool UpdateArmy(bool executeMethod, int swordmen,int spearmen, int horsemen, int archersShortBow,int archerLongBow, int knightOnFoot,
                            int knightOnStallionSword,int knightOnStallionSpear, int monsters)//improved trazability to what is needed for completion.
    {
        int menNeeded= (swordmen + spearmen + horsemen + archerLongBow + archersShortBow)*poblationSoldiersCost + (knightOnFoot  + knightOnStallionSpear  + knightOnStallionSword)*poblationAdvancedCost ;        
        int moneyNeeded=(swordmen  + archerLongBow + archersShortBow)*basicSoldiersCost + (spearmen + horsemen )* spearmenCost  + knightOnFoot*knightCost + knightOnStallionSpear*knightSpearCost + knightOnStallionSword*knightSwordCost +(monsters)*monstersCost;

        bool men = faction.population >= menNeeded;       
        bool money = faction.goldScorpions >= moneyNeeded;

        if(men && money)//desglosamos para poder identificar luego en la UI que nos falta rapidamente
        {
            if (executeMethod)
            {
                //restamos la poblacion que vamos a necesitar y el dinero
                faction.Population = -menNeeded;
                totalArmy += menNeeded;
                faction.GoldScorpions = -moneyNeeded;
                //Aumentamos el ejercito
                this.swordmen += swordmen;
                this.spearmen += spearmen;
                this.horsemen += horsemen;
                this.archerLongBow += archerLongBow;
                this.archersShortBow += archersShortBow;
                this.knightOnFoot += knightOnFoot;
                this.knightOnStallionSword += knightOnStallionSword;
                this.knightOnStallionSpear += knightOnStallionSpear;
                this.monsters += monsters;

            }                       
            return true;
        }
        else
        {
            Debug.Log("No se tienen los recursos");
            return false;
        }

    }

    public int TotalSoldiers()
    {
        int i;
        i = swordmen + spearmen + horsemen + archerLongBow + archersShortBow + knightOnFoot + knightOnStallionSpear + knightOnStallionSword + monsters;
        return i;
    }

    public void UpdateWeaponRanks(int idWeaponToUpgrade) //Sube un rango al tipo de arma pasado por indice.
    {
        switch (idWeaponToUpgrade)
        {
            case 0:
                swordRank++;
                break;
            case 1:
                spearRank++;
                break;
            case 2:
                knightsRank++;
                break;
            case 3:
                monstersRank++;
                break;
            default:
                Debug.Log("No he encontrado ningun arma a la que subir el rango");
                break;
        }
    }

    public void UpdateFoodFromArmy()
    {
        int totalSoldiers= swordmen + spearmen + horsemen + archerLongBow + archersShortBow + knightOnFoot + knightOnStallionSpear + knightOnStallionSword +monsters*5;
        faction.Food = -totalSoldiers;//*0.7?? Study if its possible to decrease food consumption when population pass to soldiers(thieving, stealing...)
    }

}
