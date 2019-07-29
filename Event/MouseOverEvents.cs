using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject panelRed;
    public GameObject panelGreen;
    public GameObject seriousDescriptionPanel;
    public FactionLocalEvents factionEvents;
    public int option=1;


    public void OnPointerEnter(PointerEventData eventData)
    {
        factionEvents.ShowOption(option);
        panelRed.SetActive(true);
        panelGreen.SetActive(true);
        seriousDescriptionPanel.SetActive(false);
        
    }    

    public void OnPointerExit(PointerEventData eventData)
    {
        panelRed.SetActive(false);
        panelGreen.SetActive(false);
        seriousDescriptionPanel.SetActive(true);

    }

    
}
