using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save 
{
    //Serialization of Faction.cs
    public float adultsToChildren; 
    public float childrenToAdults;    
    public int factionID;
    public string factionName;
    public string leader;    
    public int population;
    public int children;
    public int populationHappiness;   
    public int food;    
    public int goldScorpions;

    //Serialization of FactionArmy
    public int swordmen;
    public int spearmen;
    public int horsemen;
    public int archersShortBow;
    public int archerLongBow;
    public int knightOnFoot;
    public int knightOnStallionSword;
    public int knightOnStallionSpear;
    public int monsters;
    public int totalArmy;

    //Serialization of FactionStructure
    public bool BarrackCentinel = false;
    public bool StableCentinel = false;
    public bool ArmoryCentinel = false;
    public bool AltarCentinel = false;
    public bool pitCentinel = false;
    public bool FoundryCentinel = false;
    public bool[] construtedStructuresList=new bool[18];


    //Serialization of Diplomacy
    public List<DiplomacyAgentWrapper> agentsRecruited = new List<DiplomacyAgentWrapper>();

    //timemanager settings

    public float timeIncrement;
    public float year;
    public float deltaIncrement;
    public int centinel;




}

