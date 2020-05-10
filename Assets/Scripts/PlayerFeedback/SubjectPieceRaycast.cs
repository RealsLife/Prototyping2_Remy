using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceRaycast : SubjectPiece
{
    public void TriggerPiece()
    {
        //_subjectHandler.TriggerVerdict(this);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
