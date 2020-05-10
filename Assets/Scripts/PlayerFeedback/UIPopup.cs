using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    public UICardPopup CardGreen;
    public UICardPopup CardOrange;
    public UICardPopup CardRed;


    public void PopFeedback(Verdict verdict, string textToDisplay)
    {
        if(verdict == Verdict.Positive)
        {
            CardGreen.gameObject.SetActive(true);
            CardGreen.PlayCardPopup(textToDisplay);
        }
        else if(verdict == Verdict.Mild)
        {
            CardOrange.gameObject.SetActive(true);
            CardOrange.PlayCardPopup(textToDisplay);
        }
        else if(verdict == Verdict.Serious)
        {
            CardRed.gameObject.SetActive(true);
            CardRed.PlayCardPopup(textToDisplay);
        }
    }
}
