using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPriorityCheckerBehaviour : MonoBehaviour
{
    private bool _detectingOtherCar;
    private bool _detectingOtherCarPriorityChecker;
    private void OnTriggerEnter(Collider other)
    {
        //if(other.transform.CompareTag("Car"))
        {
            if (Vector3.Dot(this.transform.forward, other.transform.forward) < 0)
            {
                //if the carPriorityChecker collider has hit a car
                if (other.transform.parent.CompareTag("Car"))
                {
                    if (other.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false && this.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false)
                    {
                        if(other.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false && this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false)
                        {
                            //Debug.Log("priority given by car detection by car: " + this.gameObject.GetComponentInParent<CarBehaviour>().GetInstanceID());
                            _detectingOtherCar = true;
                            //Debug.Break();
                            this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                        }
                    }   
                }
                //if the carPriorityChecker collider has hit another carPriorityChecker collider
                else if (other.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false && this.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false)
                {
                    if (other.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false && this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority == false)
                    {
                        _detectingOtherCarPriorityChecker = true;
                        //Debug.Log("priority given by courtesy by car: " + SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().GetInstanceID());
                        //Debug.Break();
                        SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                        SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[1].GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                    }
                    

                    //if(this.GetComponentInParent<CarBehaviour>().IsCarInRange == false)
                    //{
                    //    SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                    //    SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[1].GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                    //}
                    //else
                    //{
                    //    this.GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                    //}

                    //this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(true);
                }
            }
            else
            {
                other.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = true;
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.GetComponentInParent<CarBehaviour>().Speed < 1)
    //    {
    //        this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        //if the carPriorityChecker collider has exited a car
        if (other.transform.parent.CompareTag("Car"))
        {
            if(other.GetComponentInParent<PathFollow>().CarBehindThisCarIsFollowingTheSamePath == false)
            {
                if(this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority)
                {
                    //Debug.Break();
                    if(other.gameObject.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar == false && _detectingOtherCarPriorityChecker == false)
                    {
                        this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                        _detectingOtherCar = false;
                    }
                }
                
            }

            if (Vector3.Dot(this.transform.forward, other.transform.forward) > 0)
            {
                other.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = false;
            }
            //other.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar = false;

                //if(other.GetComponentInChildren<PathFollow>().CarBehindThisCarIsFollowingTheSamePath == false)
        }
        //if the carPriorityChecker collider has exited another carPriorityChecker collider
        else if (other.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false && this.GetComponentInParent<CarBehaviour>().IsStandingStillAtTrafficLight == false)
        {
            //if(SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().IsGivingPriority)
            {
                //SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                _detectingOtherCarPriorityChecker = false;
                //this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                //Debug.Log("TRIGGERED");
                //Debug.Break();
            }
            if (Vector3.Dot(this.transform.forward, other.transform.forward) < 0)
            {
                if (this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority)
                {
                    if (other.gameObject.GetComponentInParent<PathFollow>().CarIsCloselyFollowedByOtherCar == false)
                    {
                        this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
                    }
                }
            }
            
            

            //Debug.Log("TRIGGERED");
            //Debug.Break();
        }

        //if(other.transform.parent.CompareTag("Car"))
        {
            //SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().GivePriority(false);

            //if(other.transform.GetComponentInParent<PathFollow>().CarBehindThisCarIsFollowingTheSamePath == false)
            //{
            //    if (this.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority)
            //    {
            //        this.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
            //    }
            //}
            
            //if (other.gameObject.GetComponentInParent<CarBehaviour>().IsGivingPriority)
            //{
            //    other.gameObject.GetComponentInParent<CarBehaviour>().ForceToGivePriority(false);
            //}

            //SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[1].GetComponentInParent<CarBehaviour>().GivePriority(false);
        }
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
