using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceRemover : MonoBehaviour
{
    private void Start()
    {
        Collider[] touchingColliders = Physics.OverlapBox(this.transform.position, this.transform.lossyScale / 2, this.transform.rotation);

        foreach(Collider collider in touchingColliders)
        {
            if(collider.GetComponent<SubjectPiece>() != null)
            {
                if(collider.transform.parent != this.transform.parent)
                    Destroy(collider.gameObject);
            }
        }
    }
}
