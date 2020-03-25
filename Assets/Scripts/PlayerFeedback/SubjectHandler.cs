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

    public void TriggerVerdict(SubjectPiece piece)
    {
        if (piece.Judgement == Verdict.Right)
        {
            if (!_positives.Contains(piece.Description))
                _positives.Add(piece.Description);
        }
        else if (piece.Judgement == Verdict.Wrong)
        {
            if (!_negatives.Contains(piece.Description))
                _negatives.Add(piece.Description);

            _scorePenalty += piece.ScorePenalty;
        }
    }

    private string StringListToString(List<string> stringList)
    {
        string package = "";
        foreach (string line in stringList)
            package += line + "\n";
        return package;
    }
}
