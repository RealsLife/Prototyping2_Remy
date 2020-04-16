using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;
using System.IO;

public class PathFollow : MonoBehaviour
{
    private PathCreator _pathCreator { get; set; }
    //public EndOfPathInstruction End;
    private float _speed;
    
    private float _distanceTravelled;
    private bool _pathTimeGoesFrom0To1 = true;

    void Start()
    {
        _speed = gameObject.GetComponent<CarBehaviour>().Speed;
    }

    void FixedUpdate()
    {
        //GetSpeed();
        
        if(_pathTimeGoesFrom0To1)
        {
            _distanceTravelled += _speed * Time.fixedDeltaTime;
        }
        else
        {
            _distanceTravelled -= _speed * Time.fixedDeltaTime;
        }

        if (_pathCreator)
        {
            transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled); //+ offset;
            
            if (!_pathTimeGoesFrom0To1)
            {
                Quaternion rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
                Vector3 rotationVector = rotation.eulerAngles;
                rotationVector.y -= 180;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else
            {
                transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled);
            }
        }
    }

    private void GetSpeed()
    {
        if(_speed != gameObject.GetComponent<CarBehaviour>().Speed)
        {
            _speed = gameObject.GetComponent<CarBehaviour>().Speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Tile"))
        {
            if (_pathCreator == null)
            {
                _pathCreator = GetClosestPathOnTile(other);
            }
            else if (_pathCreator.GetInstanceID() != other.transform.root.GetComponentsInChildren<PathCreator>()[0].GetInstanceID()
                    && _pathCreator.GetInstanceID() != other.transform.root.GetComponentsInChildren<PathCreator>()[1].GetInstanceID())
            {
                _pathCreator = GetClosestPathOnTile(other);

                _distanceTravelled = 0;
                if (_pathCreator.path.GetClosestTimeOnPath(transform.position) < .5f)
                {
                    _pathTimeGoesFrom0To1 = true;
                }
                else
                {
                    _pathTimeGoesFrom0To1 = false;
                }
            }
            else
            {
                //to do: add behaviour for when car hits collider from tile it's already on (the end tile)
                Debug.Log("Nothing to see here");
            }
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

}
