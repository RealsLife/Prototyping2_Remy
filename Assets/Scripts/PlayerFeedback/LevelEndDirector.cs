using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndDirector : MonoBehaviour
{
    public List<SubjectHandler> SubjectHandlers;

    public int PlayerScore = 10;//this has to be moved to playerstats

    public UILevelEndFeedback UILevelEndFeedback;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            LevelEndFeedback();
    }

    private void LevelEndFeedback()
    {
        string feedbackPositive = "";
        string feedbackNegative = "";

        foreach(SubjectHandler subjectHandler in SubjectHandlers)
        {
            feedbackPositive += subjectHandler.Positives;
            feedbackNegative += subjectHandler.Negatives;
            PlayerScore = Mathf.Max(PlayerScore - subjectHandler.ScorePenalty, 0);
        }

        UILevelEndFeedback.UpdateFeedbackTextField(feedbackPositive, feedbackNegative, PlayerScore);
        UILevelEndFeedback.gameObject.SetActive(true);
    }
}
