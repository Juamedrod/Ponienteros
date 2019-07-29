using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structures", menuName = "Structure", order = 1)]
public class Structure:ScriptableObject
{
    public new string name;
    public string description;

    [Header("Cost Settings")]
    public int cost;
    public int poblationCost;
    public int minimunPoblationHappiness;
    public float constructionTime;

    [Header("Perks Settings")]
    public int foodPerk;
    public float populationPerk;
    public int moneyPerk;

    [Header("¿Constructed?")]
    public bool constructed;
    public int PerkForOnce = 0;

   
}
