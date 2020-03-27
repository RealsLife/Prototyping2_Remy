using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerPrefab;
    [SerializeField] private bool _HasEnteredTile;
    private bool _IsActive = false;


    void Update()
    {
        if (_HasEnteredTile && !_IsActive) SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Instantiate(_PlayerPrefab, transform.position, transform.rotation);
        _IsActive = true;
    }
}
