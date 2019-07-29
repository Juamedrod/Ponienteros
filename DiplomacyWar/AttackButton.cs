using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public CombatTrigger combatTrigger;

    public void Interact()
    {
        combatTrigger.ObjetiveLooking();
    }




}
