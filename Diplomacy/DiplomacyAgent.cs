using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiplomacyAgent 
{
    [SerializeField]
    public Sprite avatar;
    public string name;
    public int cost=50;
    public int diplomacyStrength;
    public int assasinationStrength;
    public int retoricStrength;
    public int liesStrength;
    public int numberOfSpies;
    public bool bornInPonienteros;
    public bool noble;
    public bool havePeopleLove;
    public bool Smart;

    
}
