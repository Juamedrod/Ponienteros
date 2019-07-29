using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Avatar : MonoBehaviour
{
    AttackButton attackButton;
    public DiplomacyAgent agent;
    public ShowAGentStats display;
    public GameObject panelDisplay;
    public GameObject colliderFloorActivation;
    public Vector3 copyTransformPos;    

    private void Awake()
    {
        display = FindObjectOfType<ShowAGentStats>();
        panelDisplay = display.gameObject;
        attackButton = FindObjectOfType<AttackButton>();
    }

    public void OnMouseDown()
    {
        if (GeneralManager.generalManager.turns > 0)
        {
            colliderFloorActivation.SetActive(true);
            if (agent != null)
            {
                panelDisplay.SetActive(true);
                display.ShowFromMouseOver(agent);
            }
            copyTransformPos = this.transform.position;
            attackButton.combatTrigger = GetComponent<CombatTrigger>();
        }
    }   

    private void OnMouseDrag()
    {
        if (Vector3.Distance(copyTransformPos,Input.mousePosition)> 0.05)
        {
            colliderFloorActivation.SetActive(false);
        }

    }

    private void Update()
    {
        if (agent.diplomacyStrength <= 0)
        {
            GameManager.gameManager.agentsDeadInCombat.Add(this.agent);
            Destroy(this.gameObject);
        }
    }

    public void DestroyAgent()
    {
        Destroy(this.gameObject);
    }
}
