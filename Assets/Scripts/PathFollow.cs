using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;
using System.IO;

public class PathFollow : MonoBehaviour
{
    //public EndOfPathInstruction End;
    private float _speed;

    public PathCreator _currentPathToFollow;
    public float _distanceTravelledOnCurrentPath;
    public bool _pathTimeGoesFrom0To1 = true;
    public bool _distanceTravelledOnCurrentPathIsSet = false;

    void Start()
    {
        _speed = gameObject.GetComponent<CarBehaviour>().Speed;
    }

    void FixedUpdate()
    {
        MoveCarAlongPath();
        RotateCarAlongPath();
        DestroyCarOnTileExit();
    }

    private void DestroyCarOnTileExit()
    {
        if (_distanceTravelledOnCurrentPath < -.5f || _distanceTravelledOnCurrentPath > 30.5f)
        {
            GameObject.Destroy(this.gameObject);
            //Debug.Log("destroyed");
        }
    }

    private void MoveCarAlongPath()
    {
        if (_distanceTravelledOnCurrentPathIsSet == false)
        {
            _distanceTravelledOnCurrentPath = _currentPathToFollow.path.GetClosestDistanceAlongPath(transform.position);
            _distanceTravelledOnCurrentPathIsSet = true;
        }

        if (_pathTimeGoesFrom0To1)
        {
            _distanceTravelledOnCurrentPath += _speed * Time.fixedDeltaTime;
        }
        else
        {
            _distanceTravelledOnCurrentPath -= _speed * Time.fixedDeltaTime;
        }


        if(_currentPathToFollow)
        {
            transform.position = _currentPathToFollow.path.GetPointAtDistance(_distanceTravelledOnCurrentPath, EndOfPathInstruction.Stop);
        }
    }

    private void RotateCarAlongPath()
    {
        if (!_pathTimeGoesFrom0To1)
        {
            Quaternion rotation = _currentPathToFollow.path.GetRotationAtDistance(_distanceTravelledOnCurrentPath);
            Vector3 rotationVector = rotation.eulerAngles;
            rotationVector.y -= 180;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        else
        {
            transform.rotation = _currentPathToFollow.path.GetRotationAtDistance(_distanceTravelledOnCurrentPath);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Road"))
        {
            _currentPathToFollow = GetClosestPathOnTile(other);
            _pathTimeGoesFrom0To1 = PathGoesFrom0To1(_currentPathToFollow);
            _distanceTravelledOnCurrentPathIsSet = false;
            Debug.Log("ENTER:" + _currentPathToFollow.transform.root.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Road"))
        {
            Debug.Log("EXIT:" + other.transform.root.name);
            
        }
    }

    //Returns the closest path to the car
    private PathCreator GetClosestPathOnTile(Collider other)
    {
        Vector3 carPosition = transform.position;
        PathCreator closestPath = other.transform.root.GetComponentInChildren<PathCreator>();

        for (int i = 0; i < other.transform.root.GetComponentsInChildren<PathCreator>().Length; i++)
        {
            if (Vector3.Distance(closestPath.path.GetClosestPointOnPath(carPosition), carPosition) > Vector3.Distance(other.transform.root.GetComponentsInChildren<PathCreator>()[i].path.GetClosestPointOnPath(carPosition), carPosition))
            {
                closestPath = other.transform.root.GetComponentsInChildren<PathCreator>()[i];
            }
        }
        return closestPath;
    }

    private bool PathGoesFrom0To1(PathCreator pathCreator)
    {
        bool pathGoesFrom0To1 = true;
        if(pathCreator.path.GetClosestTimeOnPath(transform.position) < .5f)
        {
            pathGoesFrom0To1 = true;
        }
        else
        {
            pathGoesFrom0To1 = false;
        }
        return pathGoesFrom0To1; 
    }

}
