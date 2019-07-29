using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEraser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FogEraser")) transform.gameObject.SetActive(false);
    }
}
