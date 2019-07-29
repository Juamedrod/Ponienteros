using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Faction)), System.Serializable]
public class FactionDiplomacy : MonoBehaviour
{
    public Faction faction;
    public enum Factions { Stard, Lionster, Bartheon, Torrel, Borne, Margaryen, FreePeople};
    public Factions myFaction;
    public float[] matrixOfDiplomacy;
    public bool[] factionsAtWar;
    [SerializeField]
    public List<DiplomacyAgent> agentsRecruited;
    public DisplayAgentsRecruited DisplayAgentsRecruited;

    

    private void Awake() 
    {        
        faction = GetComponent<Faction>();
        matrixOfDiplomacy =new float[7];
        factionsAtWar = new bool[7];
        agentsRecruited = new List<DiplomacyAgent>();
    } 

    public void SetReputation(Factions factionTarget,float amountOfChange)
    {
        matrixOfDiplomacy[(int)factionTarget] += amountOfChange;
    }
    

    public void DeclareWar(Factions faction)
    {
        factionsAtWar[(int)faction] = true; 
    }

    public void StartDiplomaticQuest(int i)
    {
        //code to start the diplomacy fight
    }

    public void NewAgent(DiplomacyAgent agentRecruited)
    {
        agentsRecruited.Add(agentRecruited);
        DisplayAgentsRecruited.DisplayAgentsRecruitedUI();
        
    }

}
