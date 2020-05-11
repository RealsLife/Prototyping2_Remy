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

    private void AdjustScore(Verdict verdict)
    {
        if (verdict == Verdict.Mild)
            _scorePenalty -= 3;
        else if (verdict == Verdict.Serious)
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

    public virtual void AddFeedback(ref List<string> stringList, string textToAdd, Verdict verdict)
    {
        if (!ListContainsString(stringList, textToAdd))
            stringList.Add(textToAdd);

        AdjustScore(verdict);

        if (verdict != Verdict.None && verdict != Verdict.Positive)
        {
            UIPopup = FindObjectOfType<UIPopup>();
            UIPopup.PopFeedback(verdict, textToAdd);
        }
    }

    private bool ListContainsString(List<string> stringList, string textToFind)
    {
        int amount = 0;

        foreach (string line in stringList)
            amount += line.Equals(textToFind) ? 1 : 0;

        return amount > 0;
    }
}
