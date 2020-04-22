using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHandler : MonoBehaviour
{
    private List<string> _positives = new List<string>();
    private List<string> _negatives = new List<string>();

    public string Positives { get { return StringListToString(_positives); } }
    public string Negatives { get { return StringListToString(_negatives); } }

    private int _scorePenalty = 0;

    public int ScorePenalty { get { return _scorePenalty; } }

    [HideInInspector]
    public UIPopup UIPopup;

    private void Start()
    {
        UIPopup = FindObjectOfType<UIPopup>();
    }

    public void TriggerVerdict(SubjectPiece piece)
    {
        if (piece.Judgement == Verdict.Positive)
        {
            if (!_positives.Contains(piece.Description))
                _positives.Add(piece.Description);
        }
        else if (piece.Judgement == Verdict.Mild || piece.Judgement == Verdict.Serious)
        {
            if (!_negatives.Contains(piece.Description))
                _negatives.Add(piece.Description);

            AdjustScore(piece);
        }

        if(piece.Judgement != Verdict.None)
            UIPopup.PopFeedback(piece);
    }

    private void AdjustScore(SubjectPiece piece)
    {
        if (piece.Judgement == Verdict.Mild)
            _scorePenalty -= 3;
        else if (piece.Judgement == Verdict.Serious)
            _scorePenalty -= 6;
    }

    private string StringListToString(List<string> stringList)
    {
        string package = "";
        foreach (string line in stringList)
            package += line + "\n";
        return package;
    }
}
