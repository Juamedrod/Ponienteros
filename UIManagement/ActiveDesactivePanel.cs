using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactivePanel : MonoBehaviour
{
    public GameObject panel;

    public void SwitchActiveDeactive()
    {
        panel.SetActive(!panel.active);
    }
}
