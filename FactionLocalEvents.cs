using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Faction))]
public class FactionLocalEvents : MonoBehaviour
{
    WaitForSeconds Espera1seg;
    Faction faction;
    bool eventLoaded = false;

    public List<Event> eventqueue;
    public Event FocusedEvent;
    public Image iconEvent;
    public TextMeshProUGUI textRed;
    public TextMeshProUGUI textGreen;
    public TextMeshProUGUI textDescription;
    public TextMeshProUGUI textSeriousDescription;
    public TextMeshProUGUI leftButton;
    public TextMeshProUGUI rightButton;
    public GameObject panelEvent;
    


    private void Start()
    {
        Espera1seg=new WaitForSeconds(1);
        faction = GetComponent<Faction>();
        StartCoroutine(CheckIfEvent());

    }

    IEnumerator CheckIfEvent()
    {
        while (true)
        {
            LoadEventToUI();
            yield return Espera1seg;
        }              
    }
    

    public void Option1()
    {
        ApplyOption(FocusedEvent.option1);
        //code to execute after the selection
        eventqueue.RemoveAt(0);
        FocusedEvent = null;
        eventLoaded = false;
        LoadEventToUI();
    }

    public void Option2()
    {
        ApplyOption(FocusedEvent.option2);
        //code to execute after select the option 2
        eventqueue.RemoveAt(0);
        FocusedEvent = null;
        eventLoaded = false;
        LoadEventToUI();
    }

    public void ShowOption(int i)
    {
        if (i == 1)
        {
            if (FocusedEvent != null)
            {
                Option o = FocusedEvent.option1;
                textRed.text = "Golden Scorpions: " + o.moneyCost + "\n" + "Población: " + o.poblationCost + "\n" + "Comida: " + o.foodCost + "\n";
                textGreen.text = "Golden Scorpions: " + o.moneyPerk + "\n" + "Población: " + o.populationPerk + "\n" + "Comida: " + o.foodCost + "\n";

            }
            
            
        }
        else
        {
            if (FocusedEvent != null)
            {
                Option o = FocusedEvent.option2;
                textRed.text = "Golden Scorpions: " + o.moneyCost + "\n" + "Población: " + o.poblationCost + "\n" + "Comida: " + o.foodCost + "\n";
                textGreen.text = "Golden Scorpions: " + o.moneyPerk + "\n" + "Población: " + o.populationPerk + "\n" + "Comida: " + o.foodCost + "\n";
            }
           
        }        
    }

    public void LoadEventToUI()
    {
        
        if (eventqueue.Count != 0 && !eventLoaded)
        {            
            
            FocusedEvent = eventqueue[0];
            panelEvent.SetActive(true);
            iconEvent.sprite = FocusedEvent.icon;
            textDescription.text = FocusedEvent.description;
            textSeriousDescription.text = FocusedEvent.seriousDescription;
            leftButton.text = FocusedEvent.option1.buttonMessage;
            rightButton.text = FocusedEvent.option2.buttonMessage;
            eventLoaded = true;
        }
        else
        {
            if (!eventLoaded)
            {
                panelEvent.SetActive(false);

            }
        }
        
    }

    public void ApplyOption(Option o)
    {
        //positives
        faction.Food = o.foodCost+o.foodPerk;
        faction.GoldScorpions = o.moneyCost + o.moneyPerk;
        faction.adultsToChildren = o.populationPerk;
        faction.population = o.poblationCost;        

    }









    public void Wedding()
    {
        
        //output to UI
    }

    public void Justa()
    {
        faction.PopulationHappiness = 1;
        //output to UI
    }

    public void Gift(int gifted)
    {
        faction.GoldScorpions = gifted;
        //output to UI
    }

    public void Conspiracy()
    {
        faction.PopulationHappiness = -1;
        //downside effects on army or population
    }

    public void BannerManArise()
    {
        faction.PopulationHappiness = 1;
        //Army has to rise due to this.
    }

    public void BronzeBankFavor(int i)
    {
        faction.GoldScorpions = i;
        //show UI, and other side effects.
    }
    
    public void AknightRise(int knightsRise)
    {
        faction.Population = (-knightsRise);
        //a new knight rise, ui display and side effects
    }


}
