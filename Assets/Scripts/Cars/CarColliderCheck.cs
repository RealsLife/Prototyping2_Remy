using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColliderCheck : MonoBehaviour
{
    [SerializeField] string[] _tag;
    public bool[] _isActive;

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _tag.Length; i++)
        {
            if (other.tag == _tag[0])
            {
                _isActive[0] = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _tag.Length; i++)
        {
            if (other.tag == _tag[0])
            {
                _isActive[0] = false;
            }
        }
    }

}
