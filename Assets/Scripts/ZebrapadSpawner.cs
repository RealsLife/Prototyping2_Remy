using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class ZebrapadSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    public PathCreator[] PathCreator;
    public bool IsZebrapadEnabled = true;
    public GameObject prefabZebrapad;
    int _randomZebrapad;
    bool _spawned = false;
    void LateUpdate()
    {
        CheckIfZebrapadEnabled();
    }

    void CheckIfZebrapadEnabled()
    {
        if(!this.GetComponent<Tile>().TileIsEnvironmentTile && !_spawned)
        {
            ChooseRandomZebrapad();
            SpawnZebrapad();
            IsZebrapadEnabled = false;
            _spawned = true;
        }
    }

    void ChooseRandomZebrapad()
    {
        _randomZebrapad = Random.Range(0, PathCreator.Length-1);
    }

    void SpawnZebrapad()
    {
        GameObject _zebrapad = Instantiate(prefabZebrapad);
        float random_t = Random.Range(0f, 1f);
        _zebrapad.transform.position = PathCreator[_randomZebrapad].path.GetPointAtTime(random_t)+new Vector3(0,0.05f,0);
        _zebrapad.transform.rotation =  PathCreator[_randomZebrapad].path.GetRotation(random_t);
        _zebrapad.transform.Rotate(new Vector3(0, 0, 0));
        _zebrapad.transform.parent = this.transform;
    }
}
