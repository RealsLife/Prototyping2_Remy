using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class PropSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    public PathCreator[] PathCreator;
    public GameObject[] PropPrefabs;
    int _randomPropId;
    bool _spawned = false;
    public int MaxPropCount = 0;
    int _spawnedProps = 0;

    private void Start()
    {
     //  GameObject[] lol = this.GetComponent<ZebrapadSpawner>().PathCreator[];
    }

    void LateUpdate()
    {
        CheckIfPropsEnabled();
    }

    void CheckIfPropsEnabled()
    {
        if (!this.GetComponent<Tile>().TileIsEnvironmentTile && !_spawned)
        {  
            SpawnProps();
            _spawned = true;
        }
    }

    void ChooseRandomProp()
    {
        _randomPropId = Random.Range(0, PropPrefabs.Length - 1);
    }

    void SpawnProps()
    {
        if (_spawnedProps < MaxPropCount)
        {
            ChooseRandomProp();
            //GameObject _randomProp = Instantiate(PropPrefabs[_randomProp]);
            //float random_t = Random.Range(0f, 1f);
            //_zebrapad.transform.position = PathCreator[_randomZebrapad].path.GetPointAtTime(random_t) + new Vector3(0, 0.05f, 0);
            //_zebrapad.transform.rotation = PathCreator[_randomZebrapad].path.GetRotation(random_t);
            //_zebrapad.transform.Rotate(new Vector3(0, 0, 0));
            //_zebrapad.transform.parent = this.transform;
            //_spawnedProps += 1;
        }
    }
}
