using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerPrefabBoy;
    [SerializeField] private GameObject _PlayerPrefabGirl;
    [SerializeField] private bool _HasEnteredTile;


    private bool _IsActive = false;

    enum Gender
    {
        Boy = 0,
        Girl = 1,
    }

    void Update()
    {
        if (_HasEnteredTile && !_IsActive) SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject _player;
        if (ProfileSaver._playerProfile._gender == (int)Gender.Boy)
        {
            _player = Instantiate(_PlayerPrefabBoy, transform.position, transform.rotation);
            _IsActive = true;
            _player.transform.parent = this.transform;
        }
        else if (ProfileSaver._playerProfile._gender == (int)Gender.Girl)
        {
            _player = Instantiate(_PlayerPrefabGirl, transform.position, transform.rotation);
            _IsActive = true;
            _player.transform.parent = this.transform;
        }
        else { return; }
      

    }
}
