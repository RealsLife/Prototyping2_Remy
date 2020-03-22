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
        string packageFeedback = "";

        foreach(SubjectHandler subjectHandler in SubjectHandlers)
        {
            packageFeedback += subjectHandler.RequestFinalVerdict(ref PlayerScore);
        }

        packageFeedback += "\nThe player's score in the level is: " + PlayerScore;
        UILevelEndFeedback.UpdateFeedbackTextField(packageFeedback);
        UILevelEndFeedback.gameObject.SetActive(true);
    }
}
