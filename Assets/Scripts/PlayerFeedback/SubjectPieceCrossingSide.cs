using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCrossingSide : SubjectPieceCrossing
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _subjectHandler.TriggeredSide();
            this.gameObject.SetActive(false);
        }
    }
}
