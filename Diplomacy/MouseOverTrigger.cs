using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverTrigger : MonoBehaviour, IPointerEnterHandler,IPointerDownHandler//UI elements cant be triggered by OnMouseOver, I have to use the interface implementacion of Pointers
{
    public DiplomacyAgent agent;
    public MouseOver mOver;    
    public FactionDiplomacy factionDiplomacy;

    private void Start()
    {
        mOver = FindObjectOfType<MouseOver>();
        factionDiplomacy = FindObjectOfType<FactionDiplomacy>();
    }
    public void OnPointerEnter(PointerEventData eventData)//MouseOver function sustitute.
    {
       mOver.ShowFromMouseOver(agent);
    }
    

    public void OnPointerDown(PointerEventData eventData)//OnMouseDown sustitute for GUI elements
    {        
        factionDiplomacy.NewAgent(agent);        
        factionDiplomacy.faction.GoldScorpions = -agent.cost;
        Destroy(this.gameObject);
    }
}
