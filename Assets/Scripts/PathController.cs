using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public PathCreator[] Paths;
    
    public List<PathCreator> GetPossiblePathsFromPosition(Vector3 position)
    {

        List<PathCreator> pathsCloseToPosition = new List<PathCreator>();

        //Vector3 carPosition = transform.position;
        //PathCreator closestPath = other.transform.root.GetComponentInChildren<PathCreator>();

        for (int i = 0; i < Paths.Length; i++)
        {
            

            if(Vector3.Distance(position, Paths[i].path.GetClosestPointOnPath(position)) < .5f)
            {
                pathsCloseToPosition.Add(Paths[i]);
            }
            //if(Vector3.Distance(position, Paths[i].path.))
            //if (Vector3.Distance(closestPath.path.GetClosestPointOnPath(carPosition), carPosition) > Vector3.Distance(other.transform.root.GetComponentsInChildren<PathCreator>()[i].path.GetClosestPointOnPath(carPosition), carPosition))
            //{
            //    closestPath = other.transform.root.GetComponentsInChildren<PathCreator>()[i];
            //}
        }
        return pathsCloseToPosition;
    }
}
