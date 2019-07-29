using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnlockRecruitment : MonoBehaviour
{    
    public GameObject[] inputField;
    public GameObject[] imagenLocked;

    public void _UnlockRecruitment()
    {
        foreach(GameObject g in inputField)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in imagenLocked)
        {
            g.SetActive(false);
        }
    }
}
