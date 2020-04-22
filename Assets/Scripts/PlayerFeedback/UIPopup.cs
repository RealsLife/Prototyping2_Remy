using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    public UICardPopup CardGreen;
    public UICardPopup CardOrange;
    public UICardPopup CardRed;


    public void PopFeedback(SubjectPiece piece)
    {
        if(piece.Judgement == Verdict.Positive)
        {
            CardGreen.gameObject.SetActive(true);
            CardGreen.PlayCardPopup(piece.Description);
        }
        else if(piece.Judgement == Verdict.Mild)
        {
            CardOrange.gameObject.SetActive(true);
            CardOrange.PlayCardPopup(piece.Description);
        }
        else if(piece.Judgement == Verdict.Serious)
        {
            CardRed.gameObject.SetActive(true);
            CardRed.PlayCardPopup(piece.Description);
        }
    }
}
