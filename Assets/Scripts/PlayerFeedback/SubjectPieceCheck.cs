using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCheck : SubjectPiece
{
    [SerializeField] private SubjectPiece _mainPiece;

    [SerializeField] private string _descriptionPositive;
    [SerializeField] private string _descriptionNegative;

    private void OnTriggerEnter(Collider other)
    {
        if(_mainPiece.RaycastPieces.Count > 0)//player didnt look around before starting to cross the street
        {
            Judgement = Verdict.Serious;
            Description = _descriptionNegative;
        }
        else
        {
            Judgement = Verdict.Positive;
            Description = _descriptionPositive;
        }
        Debug.Log(_mainPiece.EnablePieces.Count);
        Handler.TriggerVerdict(this);
        Destroy(this.gameObject);
    }
}
