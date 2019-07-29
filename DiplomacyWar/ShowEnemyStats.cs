using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowEnemyStats : MonoBehaviour
{
    public GameObject[] diplomacyStrengthImg;
    public GameObject[] assasinationImg;
    public GameObject[] RetoricImg;
    public GameObject[] liesImg;
    public GameObject[] SpiesImg;
    public TextMeshProUGUI afixes, agentName;
    DiplomacyAgent agentStored;

    public void ReloadUI()
    {
        ShowFromMouseOver(agentStored);
    }


    public void ShowFromMouseOver(DiplomacyAgent agent)
    {
        agentStored = agent;
        agentName.text = agent.name;
        afixes.text = "";

        foreach (GameObject g in diplomacyStrengthImg)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in assasinationImg)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in RetoricImg)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in liesImg)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in SpiesImg)
        {
            g.SetActive(false);
        }


        for (int i = 0; i < agent.diplomacyStrength; i++)
        {
            diplomacyStrengthImg[i].SetActive(true);
        }
        for (int i = 0; i < agent.assasinationStrength; i++)
        {
            assasinationImg[i].SetActive(true);
        }
        for (int i = 0; i < agent.retoricStrength; i++)
        {
            RetoricImg[i].SetActive(true);
        }
        for (int i = 0; i < agent.liesStrength; i++)
        {
            liesImg[i].SetActive(true);
        }
        for (int i = 0; i < agent.numberOfSpies; i++)
        {
            SpiesImg[i].SetActive(true);
        }

        if (agent.noble) afixes.text += "NOBLE \n";
        if (agent.Smart) afixes.text += "SABIO \n";
        if (agent.bornInPonienteros) afixes.text += "NACIDO EN PONIENTEROS \n";
        if (agent.havePeopleLove) afixes.text += " TIENE EL AMOR DEL PUEBLO";
    }
}
