using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonActivateFloor : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Floor")
        {
            if(!other.GetComponent<FloorControl>().occupied) other.GetComponent<FloorControl>().allowMovement = true;
            other.GetComponent<FloorControl>().EvaluateMovement();           
        }
    }
}
