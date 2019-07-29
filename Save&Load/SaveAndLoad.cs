using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public Faction faction;
    public FactionArmy factionArmy;
    public FactionDiplomacy factionDiplomacy;
    public DisplayAgentsRecruited displayAgentsRecruited;
    public FactionStructures factionStructures;
    public GenerateRandomAgent generateRandomAgent;
    public UpdateTopUI topUI;

    public void SaveGame()
    {
        Save save = CreateSaveAsset();
        Debug.Log("save creado");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log(Application.persistentDataPath);//borrar
    }


    private Save CreateSaveAsset()
    {
        Save save = new Save();
        //Faction
        save.adultsToChildren = faction.adultsToChildren;
        save.childrenToAdults = faction.childrenToAdults;
        save.factionID = faction.factionID;
        save.factionName = faction.factionName;
        save.leader = faction.leader;
        save.population = faction.population;
        save.children = faction.children;
        save.populationHappiness = faction.populationHappiness;
        save.food = faction.food;
        save.goldScorpions = faction.goldScorpions;
        //factionArmy
        save.swordmen =                 factionArmy.swordmen;
        save.spearmen =                 factionArmy.spearmen;
        save.horsemen =                 factionArmy.horsemen;
        save.archersShortBow =          factionArmy.archersShortBow;
        save.archerLongBow =            factionArmy.archerLongBow;
        save.knightOnFoot =             factionArmy.knightOnFoot;
        save.knightOnStallionSword =    factionArmy.knightOnStallionSword;
        save.knightOnStallionSpear =    factionArmy.knightOnStallionSpear;
        save.monsters =                 factionArmy.monsters;
        save.totalArmy = factionArmy.totalArmy;

        //FactionStructure
        if (factionStructures.stables.constructed) save.StableCentinel = true;
        if (factionStructures.barracks.constructed) save.BarrackCentinel = true;
        if (factionStructures.armory.constructed) save.ArmoryCentinel = true;
        if (factionStructures.altarOfKnights.constructed) save.AltarCentinel = true;
        if (factionStructures.monstersPit.constructed) save.pitCentinel = true;
        if (factionStructures.steelFoundation.constructed) save.FoundryCentinel = true;
        
        for (int i=0; i < factionStructures.initializeStructuresBools.Length ; i++ )
        {
            save.construtedStructuresList[i] = factionStructures.initializeStructuresBools[i].constructed;
        }

        //faction Diplomacy
        foreach(DiplomacyAgent d in factionDiplomacy.agentsRecruited)
        {
            DiplomacyAgentWrapper wrapper = new DiplomacyAgentWrapper();
            wrapper.name=                      d.name;
            wrapper.cost =                     d.cost;
            wrapper.diplomacyStrength=         d.diplomacyStrength;
            wrapper.assasinationStrength =      d.assasinationStrength;
            wrapper.retoricStrength    =        d.retoricStrength;
            wrapper.liesStrength       =        d.liesStrength;
            wrapper.numberOfSpies      =        d.numberOfSpies;
            wrapper.bornInPonienteros    =      d.bornInPonienteros;
            wrapper.noble               =       d.noble;
            wrapper.havePeopleLove      =       d.havePeopleLove;
            wrapper.Smart              =        d.Smart;
            save.agentsRecruited.Add(wrapper);
        }

        //timeManager settings
        save.timeIncrement = TimeManager.timeManager.timeIncrement;
        save.deltaIncrement = TimeManager.timeManager.deltaIncrement;
        save.year = TimeManager.timeManager.year;
        save.centinel = TimeManager.timeManager.centinela;

        return save;
    }
 

    public void LoadGame()
    {
        
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            //faction settings
            faction.adultsToChildren = save.adultsToChildren;
            faction.childrenToAdults=save.childrenToAdults;
            faction.factionID=save.factionID ;
            faction.factionName=save.factionName ;
            faction.leader=save.leader;            
            faction.children=save.children ;
            faction.populationHappiness=save.populationHappiness;
            faction.food=save.food;
            faction.goldScorpions=save.goldScorpions;
            faction.population = save.population;
            topUI.UpdateTopUi();
            //factionArmy
            factionArmy.swordmen = save.swordmen;           
            factionArmy.spearmen = save.spearmen;
            factionArmy.horsemen = save.horsemen;
            factionArmy.archersShortBow = save.archersShortBow;
            factionArmy.archerLongBow = save.archerLongBow;
            factionArmy.knightOnFoot = save.knightOnFoot;
            factionArmy.knightOnStallionSword = save.knightOnStallionSword;
            factionArmy.knightOnStallionSpear = save.knightOnStallionSpear;
            factionArmy.monsters = save.monsters;
            factionArmy.totalArmy = save.totalArmy;
            //faction Structure
            factionStructures.BarrackCentinel = save.BarrackCentinel; 
            factionStructures.StableCentinel =   save.StableCentinel;
            factionStructures.ArmoryCentinel =   save.ArmoryCentinel;
            factionStructures.AltarCentinel =    save.AltarCentinel;
            factionStructures.pitCentinel =      save.pitCentinel;
            factionStructures.FoundryCentinel =  save.FoundryCentinel;
            for (int i = 0; i < factionStructures.initializeStructuresBools.Length; i++)
            {
                factionStructures.initializeStructuresBools[i].constructed=save.construtedStructuresList[i];
                
            }           
            
            //faction diplomacy            

            foreach (DiplomacyAgentWrapper d in save.agentsRecruited)
            {
                DiplomacyAgent wrapper=new DiplomacyAgent();
                wrapper.name = d.name;
                wrapper.cost = d.cost;
                wrapper.diplomacyStrength = d.diplomacyStrength;
                wrapper.assasinationStrength = d.assasinationStrength;
                wrapper.retoricStrength = d.retoricStrength;
                wrapper.liesStrength = d.liesStrength;
                wrapper.numberOfSpies = d.numberOfSpies;
                wrapper.bornInPonienteros = d.bornInPonienteros;
                wrapper.noble = d.noble;
                wrapper.havePeopleLove = d.havePeopleLove;
                wrapper.Smart = d.Smart;
                wrapper.avatar = generateRandomAgent.spritesPool[Random.Range(0, generateRandomAgent.spritesPool.Length)];

                bool dead = false; //Here we evaluate if the agent is dead in combat somehow( if he is stored in the agentsDead.
                foreach(DiplomacyAgent agentDead in GameManager.gameManager.agentsDeadInCombat)
                {
                    if (agentDead.name == wrapper.name)
                    {
                        dead = true;
                        break;
                    }
                }
                if (!dead)
                {
                    factionDiplomacy.NewAgent(wrapper);
                }
                
            }   
            
            GameManager.gameManager.agentsDeadInCombat.Clear();
            displayAgentsRecruited.DisplayAgentsRecruitedUI();

            //TimeManager
            TimeManager.timeManager.timeIncrement = save.timeIncrement ;
           // TimeManager.timeManager.deltaIncrement= save.deltaIncrement;
            TimeManager.timeManager.year= save.year ;
            TimeManager.timeManager.centinela = save.centinel;

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

}
