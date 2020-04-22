using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask _challengeRaycastMask;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, Mathf.Infinity, _challengeRaycastMask))
        {
            if(hit.transform.GetComponent<SubjectPieceRaycast>() != null)
            {
                SubjectPieceRaycast subjectPiece = hit.transform.GetComponent<SubjectPieceRaycast>();
                subjectPiece.TriggerPiece();
            }
        }
    }
}
