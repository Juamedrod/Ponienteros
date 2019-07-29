using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverTriggerStructures : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MouseOverDisplayStructures display;
    string costNormalized;//string to pass at cost text normalized to display in correct format
    string perksNormalized;

    public GameObject panelMouseOver;   
    public Structure structure;

    

    private void Start()
    {
        display = panelMouseOver.GetComponent<MouseOverDisplayStructures>();
        costNormalized = "COSTE: " + structure.cost + "\n" + "COSTE POB: " + structure.poblationCost;
        perksNormalized = "COMIDA: +" + structure.foodPerk + "\n" + "RATIO DE EMBARAZOS: +" + structure.populationPerk + "\n"+ "GOLD SCORPIONS: +" + structure.moneyPerk ;


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panelMouseOver.SetActive(true);      
        display.ShowText(costNormalized, perksNormalized);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelMouseOver.SetActive(false);
    }
}
