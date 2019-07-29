using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option 
{
    public string buttonMessage;

    [Header("Negative Settings")]
    public int moneyCost;
    public int poblationCost;
    public int foodCost;

    [Header("Possitive Settings")]
    public int foodPerk;
    public float populationPerk;
    public int moneyPerk;

}
