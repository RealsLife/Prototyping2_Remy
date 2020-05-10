using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCrossingRaycast : SubjectPieceCrossing
{
    [HideInInspector] public bool WasTriggered = false;

    private float _lookTimer;

    [SerializeField] private MeshRenderer _starMeshRenderer;
    [SerializeField] private ParticleSystem _starParticles;

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
            _starMeshRenderer.enabled = true;
        }
        else
        {
            _starMeshRenderer.enabled = false;
        }
    }


    public void TriggerPiece()
    {
        if (!WasTriggered)
            _starParticles.Play();
        WasTriggered = true;
        _lookTimer = 2f;
    }
}
