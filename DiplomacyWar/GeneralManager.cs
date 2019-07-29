using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class GeneralManager : MonoBehaviour
{
    public static GeneralManager generalManager;
    public int turns;
    public TextMeshProUGUI textTurns;

    public int Turns { get => turns; set { turns = value; textTurns.text = turns.ToString(); } }

    private void Awake()
    {
        if (generalManager == null)
        {
            generalManager = this;
        }
        else
        {
            Destroy(this);
        }
    }//Singleton

    private void Start()
    {
        Turns=GameManager.gameManager.agentsToCombat.Count * 10;
        
    }

















}
