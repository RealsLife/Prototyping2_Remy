using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHandler : MonoBehaviour
{
    protected List<string> _positives = new List<string>();
    protected List<string> _negatives = new List<string>();

    public string Positives { get { return StringListToString(_positives); } }
    public string Negatives { get { return StringListToString(_negatives); } }

    private int _scorePenalty = 0;

    public int ScorePenalty { get { return _scorePenalty; } }

    [HideInInspector]
    public UIPopup UIPopup;

    [SerializeField] private bool _singularPenalty;
    private bool _singularPenaltyGiven = false;


    private void Start()
    {
        UIPopup = FindObjectOfType<UIPopup>();
    }

    public virtual void TriggerVerdict(SubjectPiece piece)
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

            if(!_singularPenalty || (_singularPenalty && !_singularPenaltyGiven))
                AdjustScore(piece);
        }

        if(piece.Judgement != Verdict.None)
        {
            UIPopup = FindObjectOfType<UIPopup>();
            UIPopup.PopFeedback(piece);
        }

    }

    private void AdjustScore(SubjectPiece piece)
    {
        if (piece.Judgement == Verdict.Mild)
            _scorePenalty -= 3;
        else if (piece.Judgement == Verdict.Serious)
            _scorePenalty -= 6;

        _singularPenaltyGiven = true;
    }

    private string StringListToString(List<string> stringList)
    {
        string package = "";
        foreach (string line in stringList)
            package += line + "\n";
        return package;
    }

    public virtual void AddFeedback(ref List<string> stringList, string textToAdd)
    {
        if (!ListContainsString(stringList, textToAdd))
            stringList.Add(textToAdd);
    }

    private bool ListContainsString(List<string> stringList, string textToFind)
    {
        int amount = 0;

        foreach (string line in stringList)
            amount += line.Equals(textToFind) ? 1 : 0;

        return amount > 0;
    }
}
