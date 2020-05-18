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
        //Debug.Log(other.transform.parent.tag);
        for (int i = 0; i < _tag.Length; i++)
        {
            if (other.transform.parent.tag == _tag[i])
            {
                PathFollow otherPathFollow = other.transform.GetComponentInParent<PathFollow>();
                PathFollow thisPathFollow = this.transform.GetComponentInParent<PathFollow>();
                _isActive[i] = true;

                if(otherPathFollow && thisPathFollow)
                {
                    if (otherPathFollow.CurrentPathTheCarIsFollowing?.GetInstanceID() == thisPathFollow.CurrentPathTheCarIsFollowing?.GetInstanceID())
                    {
                        otherPathFollow.CarBehindThisCarIsFollowingTheSamePath = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _tag.Length; i++)
        {
            if (other.transform.parent.tag == _tag[i])
            {
                PathFollow otherPathFollow = other.transform.GetComponentInParent<PathFollow>();
                _isActive[i] = false;

                if(otherPathFollow)
                {
                    otherPathFollow.CarBehindThisCarIsFollowingTheSamePath = false;
                }
            }
        }
    }

}
