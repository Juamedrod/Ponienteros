using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiploEarns : MonoBehaviour
{
    public Faction faction;
    public FactionDiplomacy factionDiplomacy;

    public int goldScorpionsPerAgentKilled;
    public int populationPerAgentKilled;
    public int foodPerAgentKilled;
    public float percentDifficultyIncrease;
    public SaveAndLoad saveAndLoad;


    void Start()
    {        
        percentDifficultyIncrease = Mathf.Lerp(1, 2, GameManager.gameManager.difficultyDiplo);
        if (GameManager.gameManager.comingFromDiploWar == true)
        {
            saveAndLoad.LoadGame();
            faction.GoldScorpions = (int)(GameManager.gameManager.enemiesDestroyed * goldScorpionsPerAgentKilled * percentDifficultyIncrease);
            faction.Population= (int)(GameManager.gameManager.enemiesDestroyed * populationPerAgentKilled * percentDifficultyIncrease);
            faction.Food= (int)(GameManager.gameManager.enemiesDestroyed * foodPerAgentKilled * percentDifficultyIncrease);            

        }

        GameManager.gameManager.comingFromDiploWar = false;
        GameManager.gameManager.agentsToCombat.Clear();
    }

}
