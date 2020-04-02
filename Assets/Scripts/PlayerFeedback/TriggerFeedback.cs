using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFeedback : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        LevelEndDirector director = FindObjectOfType<LevelEndDirector>();

        director.GenerateFeedback();
    }
}
