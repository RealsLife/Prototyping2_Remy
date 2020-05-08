using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;
using System.IO;

public class PathFollow : MonoBehaviour
{
    private float _speed;

    public PathCreator _currentPathToFollow;
    public float _distanceTravelledOnCurrentPath;

    public bool _pathTimeGoesFrom0To1 = true;
    public bool _distanceTravelledOnCurrentPathIsSet = false;

    private Quaternion _carRotation;
    private bool _rotationIsBasedOnRotationPoint;
    public Transform _carRotationPoint;

    public PathController _pathController;
    public CarSpawnerBehaviour CarSpawnerOrigin { get; set; }

    private CarBehaviour _carBehaviour;
    private bool _destroyTriggered;

    public Tile CurrentTile;

    void Start()
    {
        _carBehaviour = gameObject.GetComponent<CarBehaviour>();
        //_speed = gameObject.GetComponent<CarBehaviour>().Speed;
        //_carOffsetFromCenter = 2.27f; //transform.GetComponentInChildren<BoxCollider>().
    }

    void FixedUpdate()
    {
        MoveCarAlongPath();
        RotateCarAlongPath();
        UpdateSpeed();
        DestroyCarOnTileExit();
        //_carDistanceFromCenter = transform.forward.normalized * _carOffsetFromCenter;
    }

    private void DestroyCarOnTileExit()
    {
        if (_distanceTravelledOnCurrentPath < -.5f || _distanceTravelledOnCurrentPath > 46.5f)
        {
            if(_destroyTriggered == false)
            {
                gameObject.transform.position = new Vector3(999, 999, 999);
                //setting the position of the car far away before destroying it triggers OnTriggerExit(), which is a solution to a bug causing cars to stop driving if they immediately drive behind a car which is getting destroyed
                CarSpawnerOrigin.DecreaseAmountOfCars();
                GameObject.Destroy(this.gameObject, .1f);
                _destroyTriggered = true;
            }
        }
    }

    private void UpdateSpeed()
    {
        _speed = _carBehaviour.Speed;
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
        if (_rotationIsBasedOnRotationPoint)
        {
            //Debug.Log("car center");
            _carRotation = _currentPathToFollow.path.GetRotation(_currentPathToFollow.path.GetClosestTimeOnPath(_carRotationPoint.position));
        }
        else
        {
            _carRotation = _currentPathToFollow.path.GetRotation(_currentPathToFollow.path.GetClosestTimeOnPath(transform.position));
        }

        if (!_pathTimeGoesFrom0To1)
        {
            Vector3 rotationVector = _carRotation.eulerAngles;
            rotationVector.y -= 180;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        else
        {
            transform.rotation = _carRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Road"))
        {
            //Debug.Log("TRIGGER ENTERED");
            //_currentPathToFollow = GetClosestPathOnTile(other);

            _pathController = other.transform.parent.GetComponentInChildren<PathController>();
            _currentPathToFollow = GetRandomPath(transform.position);
            _pathTimeGoesFrom0To1 = PathGoesFrom0To1(_currentPathToFollow);
            _distanceTravelledOnCurrentPathIsSet = false;
            _rotationIsBasedOnRotationPoint = false;

            CurrentTile = other.GetComponentInParent<Tile>();
            if (CurrentTile.Type == Tile.TileType.Intersection || CurrentTile.Type == Tile.TileType.T_Junction)
            {
                _carBehaviour.AllowPriorityAwareness(true);
            }
            else
            {
                _carBehaviour.AllowPriorityAwareness(false);
            }

            //Debug.Log("ENTER:" + _currentPathToFollow.transform.root.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Road"))
        {
            //Debug.Log("EXIT:" + other.transform.root.name);
            _rotationIsBasedOnRotationPoint = true;
        }
    }

    //Returns the closest path to the car
    private PathCreator GetClosestPathOnTile(Collider other)
    {
        Vector3 carPosition = transform.position;
        PathCreator closestPath = other.transform.parent.GetComponentInChildren<PathCreator>();

        for (int i = 0; i < other.transform.parent.GetComponentsInChildren<PathCreator>().Length; i++)
        {
            if (Vector3.Distance(closestPath.path.GetClosestPointOnPath(carPosition), carPosition) > Vector3.Distance(other.transform.parent.GetComponentsInChildren<PathCreator>()[i].path.GetClosestPointOnPath(carPosition), carPosition))
            {
                closestPath = other.transform.parent.GetComponentsInChildren<PathCreator>()[i];
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

    private PathCreator GetRandomPath(Vector3 position)
    {
        return _pathController.GetPossiblePathsFromPosition(position)[Random.Range(0, _pathController.GetPossiblePathsFromPosition(position).Count)];
    }

}
