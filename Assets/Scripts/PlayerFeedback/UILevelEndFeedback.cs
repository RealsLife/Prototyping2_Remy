using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelEndFeedback : MonoBehaviour
{
    //have a timer run of 5 seconds to enable a button to close this menu
    public Text PositiveTextField;
    public Text NegativeTextField;
    public Text ScoreTextField;
    
    public void UpdateFeedbackTextField(string feedbackPositive, string feedbackNegative, int playerScore)
    {
        PositiveTextField.text = feedbackPositive;
        NegativeTextField.text = feedbackNegative;
        ScoreTextField.text = playerScore + "/10";
    }
}
