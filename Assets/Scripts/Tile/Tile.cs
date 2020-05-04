using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Directions _directions;
    bool[] Directions = new bool[4];
    public List<int> ActivatedDirections = new List<int>();
    public int _randomActiveTileStreetDirection;
    public int DirectionFromMainTile;
    public bool TileIsEnvironmentTile;
    public TileType Type;

    public enum TileType
    {
        Straight,
        Bend,
        T_Junction,
        Intersection
    }

    private void Awake()
    {
        InitializeActiveDirections();
       // CalculateTileRotation();
    }

    

    public void InitializeActiveDirections()
    {
        Directions[0] = _directions.LeftEnabled;
        Directions[1] = _directions.UpEnabled;
        Directions[2] = _directions.RightEnabled;
        Directions[3] = _directions.DownEnabled;

        for (int i = 0; i < Directions.Length; i++)
        {
            if (Directions[i])
            {
                ActivatedDirections.Add(i);
            }
        }
    }

    public void CalculateTileRotation()
    {
        if(TileIsEnvironmentTile)
        {
            TakeRandomActiveTileStreetDirection();
            TurnThisTileDirectionToSelectedTile();
            //turn it to the right direction
         
            //rename tile to a direction
        }
    }

    private void TakeRandomActiveTileStreetDirection()
    {
        _randomActiveTileStreetDirection = ActivatedDirections[Random.Range(0, ActivatedDirections.Count)];
    }

    private void TurnThisTileDirectionToSelectedTile()
    {
       
        int _oppositeDirectionFromMainTile = DirectionFromMainTile + 2;
        int radiusNeededToTurn = (_oppositeDirectionFromMainTile - _randomActiveTileStreetDirection) * 90;
        this.transform.Rotate(0, radiusNeededToTurn, 0);
    }

    //    public void CalculateTileEntrance()
    //    {
    //        _TileEntrance = _activatedDirections[Random.Range(0, _activatedDirections.Count)];
    //        Debug.Log("Entrance:" + _TileEntrance);
    //        _activatedDirections.Remove(_TileEntrance);
    //    }

    //    public void CalculateTileExit()
    //    {
    //        if (_activatedDirections.Count > 1)
    //        {
    //            _TileExit = _activatedDirections[Random.Range(0, _activatedDirections.Count)];
    //        }
    //        else
    //        {
    //            _TileExit = _activatedDirections[0];
    //        }
    //        Debug.Log("Exit:" + _TileExit);
    //    }
}
