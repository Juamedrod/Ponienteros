using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentManagerUI : MonoBehaviour
{
    public MouseOverTrigger[] mOverTrigger;
    public GenerateRandomAgent GenerateRandomAgent;
    public Image[] sprites;
    


    public void ShowInUiAgents()
    {
        for(int i=0; i < sprites.Length; i++)
        {
            if (GenerateRandomAgent.agentsPool[i].avatar != null)
            {
                sprites[i].sprite = GenerateRandomAgent.agentsPool[i].avatar;
                mOverTrigger[i].agent = GenerateRandomAgent.agentsPool[i];
            }
            else
            {
                Debug.Log("Sin agentes");
            }
           
        }
    }
}
