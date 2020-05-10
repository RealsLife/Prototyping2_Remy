using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPieceCrossingStartCheck : SubjectPieceCrossing
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _subjectHandler.TriggerStartedCrossing();
            this.gameObject.SetActive(false);
        }
    }
}
