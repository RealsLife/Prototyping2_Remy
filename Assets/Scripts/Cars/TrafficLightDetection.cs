﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightDetection : MonoBehaviour
{
    public bool HasDetectedStoppingTrafficLight;
    [SerializeField] private GameObject _car;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("TrafficLight"))
        {
            //Debug.Log(other.GetComponentInParent<TrafficLightBehaviour>().ForwardDirectionCarsAreStoppedAt);
            if (Vector3.Dot(other.GetComponentInParent<TrafficLightBehaviour>().ForwardDirectionCarsAreStoppedAt, _car.transform.forward) > .9f)
            {
                //Debug.Log("detected trafficLight");
                HasDetectedStoppingTrafficLight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("TrafficLight"))
        {
            if (Vector3.Dot(other.GetComponentInParent<TrafficLightBehaviour>().ForwardDirectionCarsAreStoppedAt, _car.transform.forward) > .9f)
            {
                HasDetectedStoppingTrafficLight = false;
            }
        }
    }
}