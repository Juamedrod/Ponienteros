using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAgentsRecruited : MonoBehaviour
{
    public FactionDiplomacy factionDiplomacy;
    public List<DiplomacyAgent> listToShowInUI=new List<DiplomacyAgent>();
    public GameObject prefabPanelUI;
    public Transform parentTransform;

    private void Start()
    {
        //listToShowInUI = new List<DiplomacyAgent>();
        factionDiplomacy = FindObjectOfType<FactionDiplomacy>();
    }
    public void DisplayAgentsRecruitedUI()
    {
        GameObject clone;
        foreach (DiplomacyAgent a in factionDiplomacy.agentsRecruited)
        {
            if (!listToShowInUI.Contains(a))
            {                
                listToShowInUI.Add(a);
                clone=Instantiate(prefabPanelUI, parentTransform);
                MouseOverTriggerLessFunctionality mouseOverTrigger = clone.GetComponent<MouseOverTriggerLessFunctionality>();
                mouseOverTrigger.agent = a;
                //instantiate a panel with the agent
            }
            else
            {
                //do some other thing or nothing
            }
        }   
        
    }
}
