using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInStart : MonoBehaviour
{
  
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    
}
