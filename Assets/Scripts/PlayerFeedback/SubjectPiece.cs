using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Verdict
{
    None, Positive, Mild, Serious
}

public class SubjectPiece : MonoBehaviour
{
    public SubjectHandler Handler;

    public Verdict Judgement = Verdict.None;
    public string Description;

    public List<SubjectPiece> EnablePieces;
    public List<SubjectPiece> DisablePieces;
    public List<SubjectPieceRaycast> RaycastPieces;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Handler.TriggerVerdict(this);

            ChangePieceStates(ref EnablePieces, true);
            ChangePieceStates(ref DisablePieces, false);

            foreach (SubjectPieceRaycast piece in RaycastPieces)
            {
                piece.MainPiece = this;
                piece.gameObject.SetActive(true);
            }

            Destroy(this.gameObject);
        }

    }

    protected void ChangePieceStates(ref List<SubjectPiece> subjectPieces, bool state)
    {
        foreach (SubjectPiece piece in subjectPieces)
            piece.gameObject.SetActive(state);
    }

}
