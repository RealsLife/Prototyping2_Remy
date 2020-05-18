using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileCharacter : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerPrefabBoy;
    [SerializeField] private GameObject _PlayerPrefabGirl;
    enum Gender
    {
        Boy = 0,
        Girl = 1,
    }

    private void Update()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        //if (ProfileSaver._playerProfile._gender == (int)Gender.Boy)
        //{
        //    _PlayerPrefabBoy.SetActive(true);
        //    _PlayerPrefabGirl.SetActive(false);
        //}
        //else if (ProfileSaver._playerProfile._gender == (int)Gender.Girl)
        //{
        //    _PlayerPrefabBoy.SetActive(false);
        //    _PlayerPrefabGirl.SetActive(true);
        //}
        //else
        //{
        //    _PlayerPrefabBoy.SetActive(true);
        //    _PlayerPrefabGirl.SetActive(false);

        //}
    }
}
