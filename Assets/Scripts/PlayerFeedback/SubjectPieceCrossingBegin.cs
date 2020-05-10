using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCrossingBegin : SubjectPieceCrossing
{
    [SerializeField] private List<SubjectPieceCrossing> _enableSubjectPieces;
    [SerializeField] private List<SubjectPieceCrossing> _disableSubjectPieces;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (var piece in _enableSubjectPieces)
                piece.gameObject.SetActive(true);

            foreach (var piece in _disableSubjectPieces)
                piece.gameObject.SetActive(false);
        }
    }
}
