using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCrossingRaycast : SubjectPieceCrossing
{
    [HideInInspector] public bool WasTriggered = false;

    private float _lookTimer;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(WasTriggered)
        {
            _lookTimer -= Time.deltaTime;

            if(_lookTimer <= 0)
            {
                WasTriggered = false;
                _lookTimer = 2f;
            }
            _meshRenderer.enabled = false;
        }
        else
        {
            _meshRenderer.enabled = true;
        }
    }


    public void TriggerPiece()
    {
        WasTriggered = true;
        _lookTimer = 2f;
    }
}
