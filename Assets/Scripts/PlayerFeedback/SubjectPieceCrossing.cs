using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubjectPieceCrossing : MonoBehaviour
{
    protected SubjectHandlerCrossing _subjectHandler;

    private void Start()
    {
        _subjectHandler = this.transform.parent.GetComponent<SubjectHandlerCrossing>();
    }
}
