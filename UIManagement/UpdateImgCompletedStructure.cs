using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateImgCompletedStructure : MonoBehaviour
{
    public bool construido = true;
    public MouseOverTriggerStructures f;
    public Image img;

    private void Start()
    {        
        construido = true;
    }

    private void Update()
    {
        if (f.structure.constructed && construido)
        {
            img.fillAmount = 1;
            construido = false;
        }
    }
}
