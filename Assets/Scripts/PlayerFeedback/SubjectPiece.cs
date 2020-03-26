using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Verdict
{
    Positive, Mild, Serious
}

public class SubjectPiece : MonoBehaviour
{
    public SubjectHandler Handler;

    public Verdict Judgement = Verdict.Positive;
    public string Description;

    private void OnTriggerEnter(Collider other)
    {
        Handler.TriggerVerdict(this);
        Destroy(this.gameObject);
    }
}
