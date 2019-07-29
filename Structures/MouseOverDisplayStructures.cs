using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseOverDisplayStructures : MonoBehaviour
{
    public TextMeshProUGUI cost;
    public TextMeshProUGUI perks;

    public void ShowText(string cost, string description)
    {
        this.cost.text = cost;
        this.perks.text = description;
    }

}
