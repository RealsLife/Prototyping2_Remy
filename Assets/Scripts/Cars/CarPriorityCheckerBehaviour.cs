using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPriorityCheckerBehaviour : MonoBehaviour
{
    private bool _detectingOtherCar;
    private bool _detectingOtherCarPriorityChecker = false;
    private void OnTriggerEnter(Collider other)
    {
        CarBehaviour otherCarBehaviour = other.GetComponentInParent<CarBehaviour>();
        CarBehaviour thisCarBehaviour = this.GetComponentInParent<CarBehaviour>();

        if (Vector3.Dot(this.transform.forward, other.transform.forward) < 0)
        {
            //if the carPriorityChecker collider has hit a car
            if (other.transform.parent.CompareTag("Car"))
            {
                if(thisCarBehaviour && otherCarBehaviour != null)
                {
                    if(otherCarBehaviour.IsStandingStillAtTrafficLight == false && thisCarBehaviour.IsStandingStillAtTrafficLight == false)
                    {
                        if(otherCarBehaviour.IsGivingPriority == false && thisCarBehaviour.IsGivingPriority == false)
                        {
                            _detectingOtherCar = true;
                            thisCarBehaviour.ForceToGivePriority(true);
                        }
                    }
                }
                //if (other.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false && this.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false)
                //{
                //    if (other.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false && this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false)
                //    {
                //        //Debug.Log("priority given by car detection by car: " + this.gameObject.GetComponentInParent<CarBehaviour>().GetInstanceID());
                //        //Debug.Break();
                //        _detectingOtherCar = true;
                //        this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                //    }
                //}
            }
            //if the carPriorityChecker collider has hit another carPriorityChecker collider
            else
            {
                if (thisCarBehaviour && otherCarBehaviour)
                {
                    if (otherCarBehaviour.IsStandingStillAtTrafficLight == false && thisCarBehaviour.IsStandingStillAtTrafficLight == false)
                    {
                        if(otherCarBehaviour.IsGivingPriority == false && thisCarBehaviour.IsGivingPriority == false)
                        {
                            _detectingOtherCarPriorityChecker = true;
                            SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                            SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[1].GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                            //Debug.Log("priority given by courtesy by car: " + SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().GetInstanceID());
                            //Debug.Break();
                        }
                    }
                }
                    
            }
            //else if (other.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false && this.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false)
            //{
            //    if (other.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false && this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false)
            //    {
            //        _detectingOtherCarPriorityChecker = true;
            //        //Debug.Log("priority given by courtesy by car: " + SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().GetInstanceID());
            //        //Debug.Break();
            //        SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
            //        SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[1].GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
            //    }
            //}
        }
        else
        {
            PathFollow otherPathFollow = other.GetComponentInParent<PathFollow>();
            if(otherPathFollow)
            {
                otherPathFollow.CarIsCloselyFollowedByOtherCar = true;
            }
            //if (other.GetComponentInParent<PathFollow>())
            //{
            //    other.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = true;
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CarBehaviour otherCarBehaviour = other.GetComponentInParent<CarBehaviour>();
        CarBehaviour thisCarBehaviour = this.GetComponentInParent<CarBehaviour>();
        PathFollow otherPathFollow = other.GetComponentInParent<PathFollow>();

        //if the carPriorityChecker collider has exited a car
        if (other.transform.parent.CompareTag("Car"))
        {
            if(otherPathFollow)
            {
                if(otherPathFollow.CarBehindThisCarIsFollowingTheSamePath == false)
                {
                    if(thisCarBehaviour)
                    {
                        if(thisCarBehaviour.IsGivingPriority)
                        {
                            if(otherPathFollow.CarIsCloselyFollowedByOtherCar == false && _detectingOtherCarPriorityChecker == false)
                            {
                                thisCarBehaviour.ForceToGivePriority(false);
                                _detectingOtherCar = false;
                            }
                        }
                    }
                }
            }

            //if(other.GetComponentInParent<PathFollow>().CarBehindThisCarIsFollowingTheSamePath == false)
            //{
            //    if(this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority)
            //    {
            //        //Debug.Break();
            //        if(other.gameObject.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar == false && _detectingOtherCarPriorityChecker == false)
            //        {
            //            this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
            //            _detectingOtherCar = false;
            //        }
            //    }

            //}

            if (Vector3.Dot(this.transform.forward, other.transform.forward) > 0)
            {
                if(otherPathFollow)
                {
                    otherPathFollow.CarIsCloselyFollowedByOtherCar = false;
                }
            }

            //    if (Vector3.Dot(this.transform.forward, other.transform.forward) > 0)
            //{
            //    other.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = false;
            //}
        }
        //if the carPriorityChecker collider has exited another carPriorityChecker collider
        else
        {

            if(otherCarBehaviour && thisCarBehaviour)
            {
                if(otherCarBehaviour.IsStandingStillAtTrafficLight == false && thisCarBehaviour.IsStandingStillAtTrafficLight == false)
                {
                    _detectingOtherCarPriorityChecker = false;

                    if (Vector3.Dot(this.transform.forward, other.transform.forward) < 0)
                    {
                        if (thisCarBehaviour.IsGivingPriority)
                        {
                            if (other.gameObject.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar == false)
                            {
                                thisCarBehaviour.ForceToGivePriority(false);
                            }
                        }
                    }
                }
            }
        }
        //else if (other.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false && this.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false)
        //{
        //    _detectingOtherCarPriorityChecker = false;

        //    if (Vector3.Dot(this.transform.forward, other.transform.forward) < 0)
        //    {
        //        if (this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority)
        //        {
        //            if (other.gameObject.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar == false)
        //            {
        //                this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
        //            }
        //        }
        //    }
        //}
     }

    public GameObject[] SortCarsByInstanceIDFromLowestToHighest(GameObject car1, GameObject car2)
    {
        GameObject[] carsSortedByInstanceIDFromLowestToHighest = new GameObject[2];
        carsSortedByInstanceIDFromLowestToHighest[0] = car1;
        carsSortedByInstanceIDFromLowestToHighest[1] = car2;

        if (car2.GetInstanceID() < car1.GetInstanceID())
        {
            carsSortedByInstanceIDFromLowestToHighest[0] = car2;
            carsSortedByInstanceIDFromLowestToHighest[1] = car1;
        }

        return carsSortedByInstanceIDFromLowestToHighest;
    }
}
