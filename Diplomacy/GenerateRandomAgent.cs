using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomAgent : MonoBehaviour
{
    public Sprite[] spritesPool;    
    public List<DiplomacyAgent> agentsPool;

    private void Awake()
    {
        agentsPool = new List<DiplomacyAgent>();
        if (spritesPool.Length != 0)
        {
            GenerateAgents(20);//there is still to code this line only for the first time its run
        }
        else
        {
            GenerateAgents(20, true);
        }
        
    }


    public void GenerateAgents(int numberOfAgents)//Generate Random Agent
    {
        agentsPool.Clear();
        for(int i=0; i < numberOfAgents; i++)
        {
            DiplomacyAgent e = new DiplomacyAgent();
            e.avatar=spritesPool[Random.Range(0,spritesPool.Length)];
            e.name=RandomNamesGenerator();            
            e.diplomacyStrength=Random.Range(1,11);
            e.assasinationStrength = Random.Range(1, 11);
            e.retoricStrength = Random.Range(1, 11);
            e.liesStrength = Random.Range(1, 11);
            e.numberOfSpies = Random.Range(1, 11);
            e.bornInPonienteros = Random.Range(0, 11) <= Random.Range(0, 11);
            e.noble = Random.Range(0, 11) <= Random.Range(0, 11); 
            e.havePeopleLove = Random.Range(0, 11) <= Random.Range(0, 11); 
            e.Smart = Random.Range(0, 11) <= Random.Range(0, 11);
            e.cost += 5 * (e.diplomacyStrength + e.assasinationStrength + e.liesStrength + e.retoricStrength + e.numberOfSpies);
            agentsPool.Add(e);
        }
    }

    public void GenerateAgents(int numberOfAgents, bool isNotWithSprite)//Generate Random Agent
    {
        agentsPool.Clear();
        for (int i = 0; i < numberOfAgents; i++)
        {
            DiplomacyAgent e = new DiplomacyAgent();            
            e.name = RandomNamesGenerator();
            e.diplomacyStrength = Random.Range(1, 11);
            e.assasinationStrength = Random.Range(1, 11);
            e.retoricStrength = Random.Range(1, 11);
            e.liesStrength = Random.Range(1, 11);
            e.numberOfSpies = Random.Range(1, 11);
            e.bornInPonienteros = Random.Range(0, 11) <= Random.Range(0, 11);
            e.noble = Random.Range(0, 11) <= Random.Range(0, 11);
            e.havePeopleLove = Random.Range(0, 11) <= Random.Range(0, 11);
            e.Smart = Random.Range(0, 11) <= Random.Range(0, 11);
            e.cost += 5 * (e.diplomacyStrength + e.assasinationStrength + e.liesStrength + e.retoricStrength + e.numberOfSpies);
            agentsPool.Add(e);
        }
    }



    public string RandomNamesGenerator()//Generate names for the Agents
    {
        string randomName;
        string[] names = new string[] { "Varyl", "Bigfinger", "Maese", "Benioff","Weiss", "Ariya", "Aemion","Viseros","Vertis","Green","Yellow","Crimson", "Emerald","Red", "Blue","Victorius", "Tydrion","Sarsa","Brion","Mendeley","Carnaval","Doppel","Venturi","Ponientos","Gargolet","Davios" };
        string[] surnames = new string[] { "Worm", "Spider", "Wollfenstoun", "David", "Crowler", "Seaunworth", "the Blind", "the Tide", "Enigma", "O'Hara", "Sand", "Wolf", "Dream", "Lion", "Bombadol", "Martin", "the sullied", "the bastard", "the Gold Shrine", "the Master", "Van Den Eyde", "the puppet", "Queenslayer", "the Wind Blow", "The Pentorisy" };
        randomName =(string) names[Random.Range(0, names.Length)] + " " + surnames[Random.Range(0, surnames.Length)];        
        return randomName;
    }








}
