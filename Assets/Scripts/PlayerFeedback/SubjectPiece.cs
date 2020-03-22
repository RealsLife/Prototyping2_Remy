using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Verdict
{
    Right, Wrong
}

public class SubjectPiece : MonoBehaviour
{
    public SubjectHandler Handler;

    public Verdict Judgement = Verdict.Wrong;
    public string Description;
    public int ScorePenalty = 0;

    public bool IsEndPiece;

    private void OnTriggerEnter(Collider other)
    {
        Handler.TriggerVerdict(this);
        Destroy(this.gameObject);
    }
}
