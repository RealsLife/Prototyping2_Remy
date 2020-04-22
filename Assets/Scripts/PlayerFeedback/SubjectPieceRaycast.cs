using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceRaycast : SubjectPiece
{
    [HideInInspector] public SubjectPiece MainPiece;

    public void TriggerPiece()
    {
        Handler.TriggerVerdict(this);
        MainPiece.RaycastPieces.Remove(this);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
