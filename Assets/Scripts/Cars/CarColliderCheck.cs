using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColliderCheck : MonoBehaviour
{
    [SerializeField] string _tag;
    public bool _isActive = false;

    void OnTriggerEnter(Collider other)
    {      
        if (other.tag == _tag)
        {          
            _isActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == _tag)
        {
            _isActive = false;
        }
    }
}
