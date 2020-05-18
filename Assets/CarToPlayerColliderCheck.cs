using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarToPlayerColliderCheck : MonoBehaviour
{
    public bool IsTriggered { get; set; }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            IsTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsTriggered = false;
        }
    }
}
