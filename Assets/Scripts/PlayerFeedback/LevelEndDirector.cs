using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndDirector : MonoBehaviour
{
    private SubjectHandler[] _subjectHandlers;

    public int PlayerScore = 10;//this has to be moved to playerstats

    public UILevelEndFeedback UILevelEndFeedback;

    public UIPopup UIPopup;

    private void Start()
    {
        PauseMenu._isGamePauzed = false;
        Cursor.lockState = CursorLockMode.Locked;

        //when a new tile is manually generated, feedback isn't added because it hasn't done FindChallenges() again
        FindChallenges();
        AssignUIPopupToChallenges();
    }

    private void FindChallenges()
    {
        _subjectHandlers = FindObjectsOfType<SubjectHandler>();
    }

    private void AssignUIPopupToChallenges()
    {
        foreach (SubjectHandler subjectHandler in _subjectHandlers)
            subjectHandler.UIPopup = UIPopup;
    }

    public void GenerateFeedback()
    {
        PauseMenu._isGamePauzed = true;
        Cursor.lockState = CursorLockMode.None;

        FindChallenges();

        string feedbackPositive = "";
        string feedbackNegative = "";

        foreach(SubjectHandler subjectHandler in _subjectHandlers)
        {
            feedbackPositive += subjectHandler.Positives;
            feedbackNegative += subjectHandler.Negatives;
            PlayerScore += subjectHandler.ScorePenalty;
            PlayerScore = Mathf.Max(PlayerScore, 0);
        }

        UILevelEndFeedback.UpdateFeedbackTextField(feedbackPositive, feedbackNegative, PlayerScore);
        UILevelEndFeedback.gameObject.SetActive(true);
    }
}
