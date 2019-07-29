using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogEraserCollider : MonoBehaviour
{
    public Collider col;   

    private void OnMouseDown()
    {
        col.enabled = false;
    }

    private void OnMouseUp()
    {
        col.enabled = true;
    }
}
