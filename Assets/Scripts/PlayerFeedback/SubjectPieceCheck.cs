using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCheck : SubjectPiece
{
    [SerializeField] private SubjectPiece _mainPiece;

    [SerializeField] private string _descriptionLookPositive;
    [SerializeField] private string _descriptionLookNegative;
    [SerializeField] private string _descriptionLightPositive;
    [SerializeField] private string _descriptionLightNegative;

    [SerializeField] private TrafficLightBehaviour _trafficLight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (_trafficLight != null)
            {
                JudgementWithLight();
            }
            else
            {
                JudgementWithoutLight();
            }

            Handler.TriggerVerdict(this);
            Destroy(this.gameObject);
        }

    }

    private void JudgementWithLight()
    {
        if (_mainPiece.RaycastPieces.Count > 0)//player didnt look around before starting to cross the street
        {
            Judgement = Verdict.Serious;

            if (_trafficLight.GetLightState() == LightState.Red)
                Description = _descriptionLookNegative + " en " + _descriptionLightNegative;
            else if (_trafficLight.GetLightState() == LightState.Green)
                Description = _descriptionLookNegative;
        }
        else//player look left & right
        {
            Judgement = Verdict.None;

            if (_trafficLight.GetLightState() == LightState.Red)
            {
                Description = _descriptionLightNegative;
                Judgement = Verdict.Serious;
            }
            else if (_trafficLight.GetLightState() == LightState.Green)
                Description = _descriptionLookPositive + " en " + _descriptionLightPositive;
        }
    }

    private void JudgementWithoutLight()
    {
        if (_mainPiece.RaycastPieces.Count > 0)
        {
            Judgement = Verdict.Serious;
            Description = _descriptionLookNegative;
        }
        else
        {
            Judgement = Verdict.None;
            Description = _descriptionLookPositive;
        }
    }
}
