using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //Diplomacy Engagement
    public List<DiplomacyAgent> agentsToCombat = new List<DiplomacyAgent>();
    public List<DiplomacyAgent> agentsDeadInCombat = new List<DiplomacyAgent>();
    public int enemiesDestroyed;
    public int difficultyDiplo; //must be between 0-1 being 1 more difficult
    public bool comingFromDiploWar;

    //SINGLETON
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        /*if (agentsToCombat == null) agentsToCombat = new List<DiplomacyAgent>();
        if (agentsDeadInCombat == null) agentsDeadInCombat = new List<DiplomacyAgent>();*/

        if (SceneManager.GetActiveScene().name == "DiplomacyWar")
        {
            agentsDeadInCombat.Clear();
        }
        
    }

    public void ChangeSceneToDiploWar()
    {
        SaveAndLoad saveAndLoad = FindObjectOfType<SaveAndLoad>();
        FactionDiplomacy factionDiplomacy = FindObjectOfType<FactionDiplomacy>();
        GameManager.gameManager.agentsToCombat= factionDiplomacy.agentsRecruited;
        saveAndLoad.SaveGame();
        SceneManager.LoadScene("DiplomacyWar");
    }








}
