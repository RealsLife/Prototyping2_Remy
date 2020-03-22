using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHandler : MonoBehaviour
{
    [SerializeField]
    private string _title;

    private List<string> _positives = new List<string> { "<b>Goed:</b> " };
    private List<string> _negatives = new List<string> { "<b>Slecht:</b> " };

    private bool _isSubjectFinished;

    private int _scorePenalty = 0;

    public void TriggerVerdict(SubjectPiece piece)
    {
        if(!_isSubjectFinished)//can still be changed, for example if the player runs back and does the exercise again
            AnalyzePiece(piece);

        if (piece.IsEndPiece)
            _isSubjectFinished = true;
    }

    private void AnalyzePiece(SubjectPiece piece)
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

    public string RequestFinalVerdict(ref int playerScore)
    {
        string package = "<b>" + _title +"</b>\n";

        StringListToString(ref _positives, ref package);
        StringListToString(ref _negatives, ref package);

        package += "\n";

        playerScore -= _scorePenalty;

        return package;

        /*
        if(_isSubjectFinished)
        {

            //string = list to string
            //return that string
        }
        else
        {
            
        }*/
    }

    private void StringListToString(ref List<string> stringList, ref string package)
    {
        foreach (string line in stringList)
            package += line + "\n";
    }
}
