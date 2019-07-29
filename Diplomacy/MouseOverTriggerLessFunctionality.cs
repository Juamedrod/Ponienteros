using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverTriggerLessFunctionality : MonoBehaviour, IPointerEnterHandler
{
    public DiplomacyAgent agent;   
    public MouseOver mOver;
    public FactionDiplomacy factionDiplomacy;
    public Image img;
    bool centinel=true;


    private void Start()
    {
        mOver = FindObjectOfType<MouseOver>();
        factionDiplomacy = FindObjectOfType<FactionDiplomacy>(); 
    }

    private void Update()
    {
        if(centinel && agent != null)
        {
            img.sprite = agent.avatar;
            centinel = false;
        }         
    }

    public void OnPointerEnter(PointerEventData eventData)//MouseOver function sustitute.
    {
        mOver.ShowFromMouseOver(agent);
    }
}
