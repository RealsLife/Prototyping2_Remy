using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarSpawnerController : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    public CarSpawnerBehaviour[] CarSpawnerArray;
    private int _YRotation;
    private int _ZPosition;
    private int _XPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (_tile.TileIsEnvironmentTile)
        {
            _YRotation = (int)gameObject.transform.parent.rotation.eulerAngles.y;
            _ZPosition = (int)gameObject.transform.parent.position.z;
            _XPosition = (int)gameObject.transform.parent.position.x;

            if (_tile.Type == Tile.TileType.Straight)
            {
                EnableCarSpawnersForStraightTile();
            }
            else if (_tile.Type == Tile.TileType.Bend)
            {
                EnableCarSpawnersForBendTile();
            }
            else if (_tile.Type == Tile.TileType.T_Junction)
            {
                EnableCarSpawnersForTJunctionTile();
                //Debug.Log(gameObject.transform.parent.name);
                //Debug.Log(_YRotation);
                //Debug.Log(_ZPosition);
                //Debug.Log(_XPosition);

            }
            else if (_tile.Type == Tile.TileType.Intersection)
            {
                EnableCarSpawnersForIntersectionTile();
            }
        }
    }

    private void EnableCarSpawnersForStraightTile()
    {
        if (_YRotation == 0)
        {
            if (_ZPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 180)
        {
            if (_ZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 90)
        {
            if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == -90 || _YRotation == 270)
        {
            if (_XPosition > 0)
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
        if (_YRotation == 0)
        {
            if (_XPosition < 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 90)
        {
            if (_ZPosition > 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 180)
        {
            if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else if (_ZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
            else if (_ZPosition < 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 270)
        {
            if (_ZPosition < 0)
            {
                CarSpawnerArray[3].gameObject.SetActive(true);
            }
            else
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
            }
        }
    }

    private void EnableCarSpawnersForTJunctionTile()
    {
        if (_YRotation == 0)
        {
            if (_ZPosition > 0)
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_ZPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }

        else if (_YRotation == 90)
        {
            if (_ZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[2].gameObject.SetActive(true);
            }
            else if (_ZPosition < 0)
            {
                CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
        }

        else if (_YRotation == 180)
        {
            if (_ZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_ZPosition < 0)
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 270)
        {
            if (_XPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
                //CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_ZPosition > 0)
            {
                CarSpawnerArray[4].gameObject.SetActive(true);
            }
            else if (_ZPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[2].gameObject.SetActive(true);
            }
        }
    }

    private void EnableCarSpawnersForIntersectionTile()
    {
        if (_YRotation == 0)
        {
            if (_ZPosition < 0)
            {
                //CarSpawnerArray[2].gameObject.SetActive(true);
                CarSpawnerArray[7].gameObject.SetActive(true);
            }
            else if (_ZPosition > 0)
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
                //CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                //CarSpawnerArray[2].gameObject.SetActive(true);
                CarSpawnerArray[7].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[5].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 90)
        {
            if (_ZPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[7].gameObject.SetActive(true);
            }
            else if (_ZPosition > 0)
            {
                //CarSpawnerArray[0].gameObject.SetActive(true);
                CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                CarSpawnerArray[2].gameObject.SetActive(true);
                //CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                //CarSpawnerArray[0].gameObject.SetActive(true);
                CarSpawnerArray[5].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 180)
        {
            if (_ZPosition < 0)
            {
                //CarSpawnerArray[2].gameObject.SetActive(true);
                CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_ZPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                //CarSpawnerArray[0].gameObject.SetActive(true);
                CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[7].gameObject.SetActive(true);
            }
        }
        else if (_YRotation == 270)
        {
            if (_ZPosition < 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_ZPosition > 0)
            {
                //CarSpawnerArray[2].gameObject.SetActive(true);
                CarSpawnerArray[7].gameObject.SetActive(true);
            }
            else if (_XPosition > 0)
            {
                CarSpawnerArray[0].gameObject.SetActive(true);
                //CarSpawnerArray[5].gameObject.SetActive(true);
            }
            else if (_XPosition < 0)
            {
                //CarSpawnerArray[2].gameObject.SetActive(true);
                CarSpawnerArray[5].gameObject.SetActive(true);
            }
        }
    }
}
