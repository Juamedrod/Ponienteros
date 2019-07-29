using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManagement : MonoBehaviour
{
    public FloorControl[] floorControls;
    
       

    public void PutFloorsToRed()
    {
        foreach(FloorControl f in floorControls)
        {
            f.EvaluateMovement(false);
        }

    }

    public void EvaluateFloors()
    {
        foreach (FloorControl f in floorControls)
        {
            f.EvaluateMovement();
        }


    }

}
