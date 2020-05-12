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
                //Debug.Log("ACTIVITYEEE");
                _isActive[i] = true;

                //other.transform.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = true;
                if (other.transform.GetComponentInParent<PathFollow>().CurrentPathTheCarIsFollowing?.GetInstanceID() == this.transform.GetComponentInParent<PathFollow>().CurrentPathTheCarIsFollowing?.GetInstanceID())
                {
                    other.transform.GetComponentInParent<PathFollow>().CarBehindThisCarIsFollowingTheSamePath = true;
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
                _isActive[i] = false;
                other.transform.GetComponentInParent<PathFollow>().CarBehindThisCarIsFollowingTheSamePath = false;
                //other.transform.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = false;
            }
        }
    }

}
