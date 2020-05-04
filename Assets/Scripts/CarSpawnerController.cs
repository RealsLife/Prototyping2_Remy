using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarSpawnerController : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    public CarSpawnerBehaviour[] CarSpawnerArray;
    private int _currentTileRotation;
    private int _currentTileZPosition;
    private int _currentTileXPosition;
    // Start is called before the first frame update
    void Start()
    {
        if(_tile.TileIsEnvironmentTile)
        {
            _currentTileRotation = (int)gameObject.transform.parent.rotation.eulerAngles.y;
            _currentTileZPosition = (int)gameObject.transform.parent.position.z;
            _currentTileXPosition = (int)gameObject.transform.parent.position.x;

            

            if (_tile.Type == Tile.TileType.Straight)
            {
                EnableCarSpawnersForStraightTile();
            }
            else if(_tile.Type == Tile.TileType.Bend)
            {
                EnableCarSpawnersForBendTile();
                //Debug.Log(gameObject.transform.parent.name);
                //Debug.Log(_currentTileRotation);
                //Debug.Log(_currentTileZPosition);
                //Debug.Log(_currentTileXPosition);
            }
        }
    }

    private void EnableCarSpawnersForStraightTile()
    {
        if (_currentTileRotation == 0)
        {
            if(_currentTileZPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if(_currentTileRotation == 180)
        {
            if (_currentTileZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if(_currentTileRotation == 90)
        {
            if(_currentTileXPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if(_currentTileRotation == -90 || _currentTileRotation == 270)
        {
            if (_currentTileXPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
    }

    private void EnableCarSpawnersForBendTile()
    {
        if (_currentTileRotation == 0)
        {
            if (_currentTileXPosition < 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
        }
        else if (_currentTileRotation == 90)
        {
            if (_currentTileZPosition > 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
        }
        else if (_currentTileRotation == 180)
        {
            if (_currentTileXPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else if(_currentTileXPosition > 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else if(_currentTileZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else if(_currentTileZPosition < 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
        }
        else if(_currentTileRotation == 270)
        {
            if(_currentTileZPosition < 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
        }
    }
}
