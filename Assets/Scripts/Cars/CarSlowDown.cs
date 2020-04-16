using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSlowDown : MonoBehaviour
{
    public PathFollow PathFollow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("CarSpawnerBehaviour");
            //PathFollow.Speed -= 2;
        }
       
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("CarSpawnerBehaviour");
            //PathFollow.Speed = 0;
        }
    }

}
