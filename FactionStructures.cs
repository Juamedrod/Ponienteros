using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Faction)), System.Serializable]
public class FactionStructures : MonoBehaviour
{
    Faction faction;
    private List<int> centinelaDobleUpdate; //this array save the id of the grow update, to prevent multiple clicks to increment population happiness.

    public bool BarrackCentinel=  false;
    public bool StableCentinel =  false;
    public bool ArmoryCentinel =  false;
    public bool AltarCentinel =   false;
    public bool pitCentinel =     false;
    public bool FoundryCentinel = false;


    public Structure[] initializeStructuresBools;
    public UnlockRecruitment[] unlockRecruitments;
    public Image[] images;
    [Header("Factor Correction Settings")]
    public float economyFactorCorrection=1;
    

    [Header("First Need buildings")]
    public Structure farm;
    public Structure packOfSheeps;
    public Structure eggsFactory;
    public Structure packOfCows;

    [Header("Financial buildings")]
    public Structure marketplace;// awards 7K/10K/15K Golden Scorpions
    public Structure coinHouse;//awards 7K/10K/15K GS
    public Structure bank;//awards 15K/17K/20K GS

    [Header("Army Buildings")]
    public Structure stables; //open horsemen   tier 1
    public Structure barracks;//open spearmen  tier 1
    public Structure armory;//open archers(both)  tier 1
    public Structure altarOfKnights;//tier 2, open knights on foot
    public Structure monstersPit;//tier2, open monsters recruitment
    public Structure steelFoundation;//tier 2, open knightson stallion with spear/sword +weapon improvements

    [Header("Population Grow & Happiness buildings")]
    public Structure waterWell;
    public Structure sewers;//alcantarillas
    public Structure butchery;
    public Structure circus;
    public Structure brothel;

        


    private void Start()
    {
        faction = GetComponent<Faction>();
        centinelaDobleUpdate = new List<int>();
        foreach(Structure e in initializeStructuresBools)//put all scriptable objects boolean to its initial state.Testing only
        {
            e.constructed = false;
        }
        waterWell.PerkForOnce=1;//testing initialization
        sewers.PerkForOnce = 1;
        butchery.PerkForOnce = 1;
        circus.PerkForOnce = 1;
        brothel.PerkForOnce = 1;
    }
    
    //Attributes Callbacks
    #region PropiedadesYLlamadas
    public void Farm(bool b)
    {
        if(MeetRequeriments(farm)&& !farm.constructed)
        {
            StartCoroutine(Cooldown(farm, images[0]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void PackOfSheeps(bool b)
    {
        if (MeetRequeriments(packOfSheeps) && !packOfSheeps.constructed)
        {
            StartCoroutine(Cooldown(packOfSheeps, images[1]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void EggsFactory(bool b)
    {
        if (MeetRequeriments(eggsFactory) && !eggsFactory.constructed)
        {
            StartCoroutine(Cooldown(eggsFactory, images[2]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void PackOfCows(bool b)
    {
        if (MeetRequeriments(packOfCows) && !packOfCows.constructed)
        {
            StartCoroutine(Cooldown(packOfCows, images[3]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void Marketplace(bool b)
    {
        if (MeetRequeriments(marketplace) && !marketplace.constructed)
        {
            StartCoroutine(Cooldown(marketplace, images[4]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void CoinHouse(bool b)
    {
        if (MeetRequeriments(coinHouse) && !coinHouse.constructed)
        {
            StartCoroutine(Cooldown(coinHouse, images[5]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void Bank(bool b)
    {
        if (MeetRequeriments(bank) && !bank.constructed)
        {
            StartCoroutine(Cooldown(bank, images[6]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void Stables(bool b)
    {
        if (MeetRequeriments(stables) && !stables.constructed)
        {
            StartCoroutine(Cooldown(stables, images[7]));
            StableCentinel = true;            
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void Barracks(bool b)
    {
        if (MeetRequeriments(barracks) && !barracks.constructed)
        {
            StartCoroutine(Cooldown(barracks, images[8]));
            BarrackCentinel = true;            
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void Armory(bool b)
    {
        if (MeetRequeriments(armory) && !armory.constructed)
        {
            StartCoroutine(Cooldown(armory, images[9]));
            ArmoryCentinel = true;
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void AltarOfKnights(bool b)
    {
        if (MeetRequeriments(altarOfKnights) && !altarOfKnights.constructed)
        {
            StartCoroutine(Cooldown(altarOfKnights, images[10]));
            AltarCentinel = true;
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void MonstersPit(bool b)
    {
        if (MeetRequeriments(monstersPit) && !monstersPit.constructed)
        {
            StartCoroutine(Cooldown(monstersPit, images[11]));
            pitCentinel = true;
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void SteelFoundation(bool b)
    {
        if (MeetRequeriments(steelFoundation) && !steelFoundation.constructed)
        {
            StartCoroutine(Cooldown(steelFoundation, images[12]));
            FoundryCentinel = true;
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void WaterWell(bool b)
    {
        if (MeetRequeriments(waterWell) && !waterWell.constructed)
        {
            StartCoroutine(Cooldown(waterWell, images[13]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void Sewers(bool b)
    {
        if (MeetRequeriments(sewers) && !sewers.constructed)
        {
            StartCoroutine(Cooldown(sewers, images[14]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
        
    }
    public void Butchery(bool b)
    {
        if (MeetRequeriments(butchery) && !butchery.constructed)
        {
            StartCoroutine(Cooldown(butchery, images[15]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void Circus(bool b)
    {
        if (MeetRequeriments(circus) && !circus.constructed)
        {
            StartCoroutine(Cooldown(circus, images[16]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }
    public void Brothel(bool b)
    {
        if (MeetRequeriments(brothel) && !brothel.constructed)
        {
            StartCoroutine(Cooldown(brothel, images[17]));
        }
        else
        {
            Debug.Log("Not enough resources");//DELETE TESTING PURPOSE ONLY
        }
    }

    #endregion

    private void Update()
    {
        if (StableCentinel)
        {
            unlockRecruitments[2]._UnlockRecruitment();
            StableCentinel = false;
        }
        if (BarrackCentinel)
        {
            unlockRecruitments[0]._UnlockRecruitment();
            BarrackCentinel = false;
        }
        if (ArmoryCentinel)
        {
            unlockRecruitments[1]._UnlockRecruitment();
            ArmoryCentinel = false;
        }
        if (AltarCentinel)
        {
            unlockRecruitments[3]._UnlockRecruitment();
            AltarCentinel = false;
        }
        if (FoundryCentinel)
        {
            unlockRecruitments[4]._UnlockRecruitment();
            FoundryCentinel = false;
        }
        if (pitCentinel)
        {
            unlockRecruitments[5]._UnlockRecruitment();
            pitCentinel = false;
        }
    }   

    public bool MeetRequeriments(Structure structure)
    {
        bool b = false;
        if (structure.cost <= faction.goldScorpions && structure.poblationCost <= faction.population && structure.minimunPoblationHappiness <= faction.populationHappiness)
        {
            b=true;
        }
        return b;
    }

    IEnumerator Cooldown(Structure structure, Image image)
    {
        float maxRange = structure.constructionTime*TimeManager.timeManager.aYearForMe;
        float tempCooldown = maxRange;
        PayConstructionCosts(structure);
        while (tempCooldown > 0)
        {
            if (!TimeManager.timeManager.pause)
            {
                tempCooldown -= Time.deltaTime * TimeManager.timeManager.deltaIncrement;
                image.fillAmount = 1 - (tempCooldown / maxRange);
            }            
            yield return null;
        }
        structure.constructed = true;
        if (structure.PerkForOnce == 1)//There is perks that only update once they are constructed and not along the time.
        {
            faction.PopulationHappiness = 1;
            faction.AdultsToChildren = structure.populationPerk;
            structure.PerkForOnce = 0;
        }
    }

    public void IndividualPerk(Structure structure)//Implement the benefits of certain structure into the faction script
    {
        faction.Food = structure.foodPerk;        
        faction.GoldScorpions = Mathf.RoundToInt(structure.moneyPerk * economyFactorCorrection);                

    }

    public void UpdatePerks()
    {
        foreach(Structure e in initializeStructuresBools)
        {
            if (e.constructed)
            {
                IndividualPerk(e);
            }
        }

    }

    public void PayConstructionCosts(Structure e)
    {
        faction.GoldScorpions = -e.cost;
        faction.Population = -e.poblationCost;
    }
}
