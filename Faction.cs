using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Faction : MonoBehaviour
{
    #region atributes
    [Header("Factors Settings")]
    public float adultsToChildren = 0.05f; //A 5% of adults bread children every year.
    public float childrenToAdults = 0.2f;//50% of children keep going adult life each year.


    [Header("Information Settings")]
    public int factionID;
    public string factionName;
    public string leader;

    [Header("Poblation Settings")]
    public int population;    
    public int children;
    public int populationHappiness;    

    [Header("Food Settings")]
    public int food;

    [Header("Financial Settings")]
    public int goldScorpions;
    #endregion

    public UnityEvent AnyAttributeChanged;

    #region Properties
    public int GoldScorpions { get => goldScorpions; set { goldScorpions += value; AnyAttributeChanged.Invoke(); } }
    public int FactionID { get => factionID; set => factionID += value; }
    public string FactionName { get => factionName; set => factionName += value; }
    public string Leader { get => leader; set => leader += value; }
    public int Population { get => population; set { population += value; AnyAttributeChanged.Invoke(); } }    
    public int Children { get => children; set => children += value; }
    public int PopulationHappiness { get => populationHappiness; set { populationHappiness += value; AnyAttributeChanged.Invoke(); } }   
    public int Food { get => food; set { food += value; AnyAttributeChanged.Invoke(); } }
    public float AdultsToChildren { get => adultsToChildren; set { adultsToChildren += value; AnyAttributeChanged.Invoke(); } }
    #endregion

    public void PoblationUpdate()
    {
        Population = Mathf.RoundToInt(Children * childrenToAdults);
        Children = Mathf.RoundToInt(-1 * Children * childrenToAdults);
        Children = Mathf.RoundToInt(population * (populationHappiness * AdultsToChildren));         
    }

    public void FoodUpdate()
    {
        Food =Mathf.RoundToInt(-1 *population * 0.7f);//hardcoded only a penalty of 70% population.
    }

}
