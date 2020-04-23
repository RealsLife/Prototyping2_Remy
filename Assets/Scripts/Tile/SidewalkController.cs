using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewalkController : MonoBehaviour
{
    [Header("Sidewalk Prefabs")]
    [SerializeField] private PathCreator[] _sideWalks;
    [SerializeField] private float _sideWalkWidth;
    [Header("Player Prefab")]
    [SerializeField]private GameObject _playerSpawnerPrefab;

    [Header("Objective Prefab")]
    [SerializeField] private GameObject _objectivePrefab;
    private PathCreator _randomSideWalk;
    private PathCreator _previousSideWalk = null;
    private float _randomSideWalkOffset;
    static bool _spawnedPlayer = false;
    static bool _spawnedObjective = false;
    static bool _reset = true;
    private void Start()
    {
        CheckIfMainTile();
    }

    private void Update()
    {
        CheckIfMainTile();
    }

    void CheckIfMainTile()
    {
        if (!this.GetComponent<Tile>().TileIsEnvironmentTile && _reset)
        {
            InitializePlayerBegin();
            InitializeObjectiveEnd();
            _reset = false;
        }
    }

    private PathCreator TakeRandomSideWalk()
    {
        _randomSideWalk = _sideWalks[Random.Range(0, _sideWalks.Length)];
        if(_randomSideWalk == _previousSideWalk)
        {
           return TakeRandomSideWalk();
        }
        else
        {
            _previousSideWalk = _randomSideWalk;
            return _randomSideWalk;
        }      
    }

    private void AssignRandomPositionOnBezier(PathCreator bezier,GameObject target)
    {
        float random_t = Random.Range(0f, 1f);
       // AddOffset()
        target.transform.position = bezier.path.GetPointAtTime(random_t) + new Vector3(0, 0.05f, 0);
        target.transform.rotation = bezier.path.GetRotation(random_t);     
    }

    void InitializePlayerBegin()//player location is the start of the level
    {
        if (!_playerSpawnerPrefab.scene.IsValid() && !_spawnedPlayer)
        {
            _spawnedPlayer = true;
        _playerSpawnerPrefab = Instantiate(_playerSpawnerPrefab);
        }
        AssignRandomPositionOnBezier(TakeRandomSideWalk(), _playerSpawnerPrefab);
    }

    void InitializeObjectiveEnd()//objective is where the player should end the level
    {
        if (!_objectivePrefab.scene.IsValid() && !_spawnedObjective)
        {
            Debug.Log("instantiate player");
            _spawnedObjective = true;
            _objectivePrefab = Instantiate(_objectivePrefab);
        }
        AssignRandomPositionOnBezier(TakeRandomSideWalk(), _objectivePrefab);
    }

    //void InitalizeProps //How many props should spawn randomly on the map

  

    void AddOffset()
    {
       _randomSideWalkOffset = Random.Range(0f, _sideWalkWidth);   
    }

    void CheckIfSpaceIsFree()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Objective")
        {
            Debug.Log("RESEEET");
            _reset = true;
        }
    }
}
