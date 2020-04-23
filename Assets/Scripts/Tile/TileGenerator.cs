using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private Tile[] _TilePrefabs;
    [SerializeField] Transform _grid;
    [HideInInspector]public bool SpawnTile = true;
    Tile _mainTile;
    float _tileSize;
    private void Start()
    {
        _tileSize = Vector3.Scale(_TilePrefabs[0].transform.localScale, _TilePrefabs[0].GetComponent<MeshRenderer>().bounds.size).x;
        GenerateNewTile();
        GenerateTileEnvironment();
        SpawnTile = false;
        Debug.Log("SPAWN NIEUWE MAINTILE");
    }
    void Update()
    {
        GenerateTileChecker();
    }
     
    void GenerateTileChecker()
    {
        if (SpawnTile) //Genereert een tile als deze conditie wordt voldaan zoals een collision check
        {
            GenerateNewTile();
            GenerateTileEnvironment();
            SpawnTile = false;
        }
    }

    void GenerateTileEnvironment()
    {
        foreach (int Direction in _mainTile.ActivatedDirections)
        {
            Vector3 positionTile = CalculateTilePosition(Direction);//bereken nodige positie
            Tile randomTile = PickRandomTilePrefab();//neem random prefab tile
            Tile _environtmentTile = Instantiate(randomTile, positionTile, transform.rotation);//instantiate tile
            _environtmentTile.TileIsEnvironmentTile = true;
            _environtmentTile.DirectionFromMainTile = Direction;
            _environtmentTile.transform.SetParent(_mainTile.transform);
            _environtmentTile.CalculateTileRotation();
        }
    }

        void GenerateNewTile()
        {
            CheckIfMainTileExists();//check of main tile al bestaat als dat zo is delete

            Vector3 positionTile = CalculateTilePosition();//bereken nodige positie
            Tile randomTile = PickRandomTilePrefab();//neem random prefab

            _mainTile = Instantiate(randomTile, positionTile, transform.rotation);//instantiate tile

            _mainTile.transform.SetParent(_grid);//parent tile
        }

        Tile PickRandomTilePrefab()
        {
            int randomTile = Random.Range(0, _TilePrefabs.Length);
            return _TilePrefabs[randomTile];
        }

        void CheckIfMainTileExists()
        {
            if (_mainTile != null)
            {
                Destroy(_mainTile.gameObject);
                _mainTile = null;
            }
        }

        Vector3 CalculateTilePosition(int direction = 0)//huidige tile uitgang is de richting
        {
            if (_mainTile == null)
            {
                return Vector3.zero;
            }
            else
            {
                Vector3 _currentTileDirection = Vector3.zero;
                switch (direction)
                {
                    case 0://left
                        _currentTileDirection = Vector3.left;
                        break;
                    case 1://up
                        _currentTileDirection = Vector3.forward;
                        break;
                    case 2://right
                        _currentTileDirection = Vector3.right;
                        break;
                    case 3://down
                        _currentTileDirection = Vector3.back;
                        break;
                    default:

                        break;
                }
                return _mainTile.transform.position + _currentTileDirection* _tileSize;
            }
        }
    
}
    //void CalculateTileRotation(int currentTileEntrance = 0)
    //{
    //    if (currentTileEntrance == 0)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        //neem de tegengestelde richting van de vorige tile uitgang trek die af van huidige 
    //        //tile gekozen random ingang en bereken graden om te roteren
    //        int radiusNeededToTurn = ((_currentTileGameObject.GetComponent<Tile>()._TileExit + 2) - currentTileEntrance) * 90;

    //        _currentTileGameObject.transform.Rotate(0,0,radiusNeededToTurn);
    //    }
    //}

