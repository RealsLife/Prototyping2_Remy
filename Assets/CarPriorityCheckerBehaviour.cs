using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPriorityCheckerBehaviour : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //if(other.transform.parent.CompareTag("Car"))
        {
            if (Vector3.Dot(this.transform.forward, other.transform.forward) < 0)
            {
                //Debug.Log("priority given");
                SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().GivePriority(true);
                SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[1].GetComponentInParent<CarBehaviour>().GivePriority(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if(other.transform.parent.CompareTag("Car"))
        {
            SortCarsByInstanceIDFromLowestToHighest(this.gameObject, other.gameObject)[0].GetComponentInParent<CarBehaviour>().GivePriority(false);
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
