using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateTopUI : MonoBehaviour
{

    public TextMeshProUGUI[] texts;
    Faction faction;

    private void Start()
    {
        faction = FindObjectOfType<Faction>();
        texts[0].text = faction.food + "";
        texts[1].text = faction.population + "";
        texts[2].text = faction.populationHappiness + "";
        texts[3].text = faction.goldScorpions + "";
        texts[4].text = FactionArmy.factionArmy.totalArmy + "";
        texts[5].text = faction.AdultsToChildren.ToString();
    }

    public void UpdateTopUi()
    {
        texts[0].text = faction.food+"";
        texts[1].text = faction.population + "";
        texts[2].text = faction.populationHappiness + "";
        texts[3].text = faction.goldScorpions + "";
        texts[4].text = FactionArmy.factionArmy.totalArmy+"";
        texts[5].text = faction.AdultsToChildren.ToString();
    }
}
