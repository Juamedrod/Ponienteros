using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    public Material notAllowed;
    public Material Allowed;
    public bool allowMovement;
    public bool occupied=false;
    MeshRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        EvaluateMovement();
    }

    public void EvaluateMovement(bool AllowMovement)
    {
        allowMovement = AllowMovement;
        if (allowMovement)
        {
            _renderer.material= Allowed;
        }
        else
        {
            _renderer.material=notAllowed;
        }

    }

    public void EvaluateMovement( )
    {
        if (allowMovement)
        {
            _renderer.material = Allowed;
        }
        else
        {
            _renderer.material = notAllowed;
        }

    }

    




}
