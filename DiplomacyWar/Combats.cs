using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combats : MonoBehaviour
{
    ShowAGentStats showAGentStats;
    ShowEnemyStats showEnemyStats;

    public DiplomacyAgent enemyAgent;
    public DiplomacyAgent myAgent;    
    public int numberOfSpies;
    public TextMeshProUGUI text;
    public int assasinationCoeficient=0;
    public int dissuadeCoeficient=0;
    public int cheatcoeficient=0;    

    [Header("Strings to return with the Combat result in each case")]
    public string assasinated;
    public string avoidedAssasination;
    public string dissuaded;
    public string notDissuaded;
    public string cheated;
    public string notCheated;

    private void Awake()
    {
        showAGentStats = FindObjectOfType<ShowAGentStats>();
        showEnemyStats = FindObjectOfType<ShowEnemyStats>();
    }

    public int Assasination(ref DiplomacyAgent myAgent,ref DiplomacyAgent enemyAgent, int mySpies, int enemySpies )
    {
        int asasinationCoefPositive=0, asasinationCoefNegative=0;
        int absCoeficient = 0;
        if (myAgent.noble) asasinationCoefPositive++;
        if (myAgent.havePeopleLove) asasinationCoefPositive++;
        if (enemyAgent.noble) asasinationCoefNegative++;
        if (enemyAgent.havePeopleLove) asasinationCoefNegative++;        

        myAgent.numberOfSpies -= mySpies;
        enemyAgent.numberOfSpies -= enemySpies;
        assasinationCoeficient = asasinationCoefPositive- asasinationCoefNegative;//coeficient given by agents traits
        //abscoeficient shows the balance between strength in each case(assa, dissua, cheat) relative to eachother.
        absCoeficient = (myAgent.assasinationStrength + mySpies + asasinationCoefPositive) - (enemyAgent.assasinationStrength + enemySpies + asasinationCoefNegative);

        if (absCoeficient>=0)
        {
            enemyAgent.diplomacyStrength -= absCoeficient;
            ReloadUI();
            if (enemyAgent.diplomacyStrength < 0)
            {
                Victory();
                this.gameObject.SetActive(false);
                return 0;//myAgent wins and kill enemy
            }
            Victory();
            this.gameObject.SetActive(false);
            return 2;//my agent hit enemy agent but its not enough to kill him

        }
        else
        {
            myAgent.diplomacyStrength += absCoeficient;
            Defeat();
        }
        
        ReloadUI();
        this.gameObject.SetActive(false);//close combat windows
        return 1;//my agent is blocked by the enemy

    }

    public int Dissuade(ref DiplomacyAgent myAgent, ref DiplomacyAgent enemyAgent, int mySpies, int enemySpies)
    {
        int dissuadeCoefPositive = 0, dissuadeCoefNegative = 0;
        int absCoeficient = 0;

        if (myAgent.Smart) dissuadeCoefPositive++;
        if (myAgent.havePeopleLove) dissuadeCoefPositive++;
        if (enemyAgent.Smart) dissuadeCoefNegative++;
        if (enemyAgent.havePeopleLove) dissuadeCoefNegative++;

        
        assasinationCoeficient = dissuadeCoefPositive - dissuadeCoefNegative;
        absCoeficient = (myAgent.retoricStrength + mySpies + dissuadeCoefPositive) - (enemyAgent.retoricStrength + enemySpies + dissuadeCoefNegative);
        if (absCoeficient>=0)
        {
            enemyAgent.diplomacyStrength -= absCoeficient;
            ReloadUI();
            if (enemyAgent.diplomacyStrength < 0)
            {
                Victory();
                this.gameObject.SetActive(false);
                return 0;//myAgent dissuaded enemy
            }
            Victory();
            this.gameObject.SetActive(false);
            return 2;//my agent dissuaded the enemy for a short time until discover the retoric bullshit

        }
        else
        {
            myAgent.diplomacyStrength += absCoeficient;
            Defeat();
        }
        ReloadUI();
        this.gameObject.SetActive(false);
        return 1;//my agent talked too much but enemy is still my enemy. maybe myagent is captive or maybe not
    }

    public int Cheat(ref DiplomacyAgent myAgent, ref DiplomacyAgent enemyAgent, int mySpies, int enemySpies)
    {
        int cheatCoefPositive = 0, cheatCoefNegative = 0;
        int absCoeficient = 0;
        if (myAgent.Smart) cheatCoefPositive++;
        if (myAgent.havePeopleLove) cheatCoefPositive++;
        if (enemyAgent.Smart) cheatCoefNegative++;
        if (enemyAgent.havePeopleLove) cheatCoefNegative++;

        
        assasinationCoeficient = cheatCoefPositive - cheatCoefNegative;
        absCoeficient = (myAgent.liesStrength + mySpies + cheatCoefPositive) - (enemyAgent.liesStrength + enemySpies + cheatCoefNegative);
        if (absCoeficient>=0)
        {
            enemyAgent.diplomacyStrength -= absCoeficient;
            ReloadUI();
            if (enemyAgent.diplomacyStrength < 0)
            {
                Victory();
                this.gameObject.SetActive(false);
                return 0;//myAgent cheated enemy and maybe now is our agent or suicide

            }
            Victory();
            this.gameObject.SetActive(false);
            return 2;//enemyagent will attack his comrades if its in range
            
        }
        else
        {
            myAgent.diplomacyStrength += absCoeficient;
            Defeat();
        }
        ReloadUI();
        this.gameObject.SetActive(false);
        return 1;//my agent talked too much but enemy is still my enemy. maybe myagent is captive or maybe not
    }

    public void IncreaseSpies()
    {
        int actualspies = numberOfSpies;
        numberOfSpies++;
        
        if (numberOfSpies > myAgent.numberOfSpies)
        {
            numberOfSpies = actualspies;
        }
        text.text = numberOfSpies.ToString();
    }

    public void DecreaseSpies()
    {
        numberOfSpies--;
        if (numberOfSpies < 0) numberOfSpies = 0;
        text.text = numberOfSpies.ToString();
    }

    public void _Assasination()
    {
        Assasination(ref myAgent, ref enemyAgent, numberOfSpies, Random.Range(0, enemyAgent.numberOfSpies));
    }

    public void _Dissuade()
    {
        Dissuade(ref myAgent, ref enemyAgent, numberOfSpies, Random.Range(0, enemyAgent.numberOfSpies));
    }

    public void _Cheat()
    {
        Cheat(ref myAgent, ref enemyAgent, numberOfSpies, Random.Range(0, enemyAgent.numberOfSpies));
    }

    private void OnEnable()
    {
        text.text = "" + 0;//spies employed text reset
        numberOfSpies = 0;
    }

    public void ReloadUI()
    {
        showEnemyStats.ReloadUI();
        showAGentStats.ReloadUI();
    }

    public void Victory()//Every piece of code related to a combat victory.
    {
        GeneralManager.generalManager.Turns++;
    }

    public void Defeat()
    {
        GeneralManager.generalManager.Turns--;//things that happen when lose a fight
    }
}
