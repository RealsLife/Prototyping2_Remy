using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHandlerCrossing : SubjectHandler
{
    [SerializeField] private List<SubjectPieceCrossingRaycast> _raycastPieces;
    [SerializeField] private TrafficLightBehaviour _trafficLight;

    private bool _hasFailedLooking = false;
    private bool _hasFailedLights = false;

    private float _redLightGraceTimer = 2f;

    private void Update()
    {
        _redLightGraceTimer = _trafficLight.GetLightState() == LightState.Green ? 2f : Mathf.Max(_redLightGraceTimer - Time.deltaTime, 0);
    }

    public void TriggerStartedCrossing()
    {
        int raycastPiecesTriggered = 0;

        foreach (var piece in _raycastPieces)
            raycastPiecesTriggered += piece.WasTriggered ? 1 : 0;

        _hasFailedLooking = raycastPiecesTriggered < _raycastPieces.Count;
        _hasFailedLights = _redLightGraceTimer <= 0;

        if (_hasFailedLights && _hasFailedLooking)
            AddFeedback(ref _negatives, "Niet links en rechts gekeken en overgestoken bij rood licht.");
        else if (_hasFailedLights)
            AddFeedback(ref _negatives, "Overgestoken bij rood licht.");
        else if (_hasFailedLooking)
            AddFeedback(ref _negatives, "Niet links en rechts gekeken bij het oversteken.");
        else if (!_hasFailedLights && !_hasFailedLooking)
            AddFeedback(ref _positives, "Prima overgestoken.");


        //Debug.Log(verdict + " / Look: " + _hasFailedLooking + " / Lights: " + _hasFailedLights +" / "+ raycastPiecesTriggered);
    }
}
