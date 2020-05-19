using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndDirector : MonoBehaviour
{
    private SubjectHandler[] _subjectHandlers;

    public int PlayerScore = 10;//this has to be moved to playerstats

    public UILevelEndFeedback UILevelEndFeedback;

    public UIPopup UIPopup;

    private bool _hasGottenTrophie = false;

    private string _sceneName;

    private void Start()
    {       
        //when a new tile is manually generated, feedback isn't added because it hasn't done FindChallenges() again
        FindChallenges();
        AssignUIPopupToChallenges();
    }

    private void Update()
    {
        _sceneName = SceneManager.GetActiveScene().name;
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

        Debug.Log(PlayerScore);
        checkForTrophie();
        checkForLevelUnlock();

        UILevelEndFeedback.UpdateFeedbackTextField(feedbackPositive, feedbackNegative, PlayerScore);
        UILevelEndFeedback.gameObject.SetActive(true);
    }

    private void checkForTrophie()
    {
        if (PlayerScore >= 8 && !_hasGottenTrophie)
        {
            Debug.Log("player earned trophie");
            PlayerProfiles._trophies += 1;
            _hasGottenTrophie = true;
        }
    }

    private void checkForLevelUnlock()
    {
       if(_hasGottenTrophie == true)
        {
            LevelManager.UnlockNewLevel(_sceneName);
        }
    }

    public void ReactivateControlls()
    {
        PauseMenu._isGamePauzed = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResetDirector()
    {
        PlayerScore = 10;
        _hasGottenTrophie = false;
    }
}
