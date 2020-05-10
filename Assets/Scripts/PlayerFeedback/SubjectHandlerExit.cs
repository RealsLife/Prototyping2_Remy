using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHandlerExit : MonoBehaviour
{
    [SerializeField] private List<GameObject> _disableObjects;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (var go in _disableObjects)
                go.SetActive(false);
        }
    }
}
