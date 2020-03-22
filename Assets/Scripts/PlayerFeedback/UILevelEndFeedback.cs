using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelEndFeedback : MonoBehaviour
{
    public Text FeedbackTextField;
    
    public void UpdateFeedbackTextField(string feedback)
    {
        FeedbackTextField.text = feedback;
    }
}
