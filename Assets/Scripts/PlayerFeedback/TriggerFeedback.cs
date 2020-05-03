using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFeedback : MonoBehaviour
{
    public static bool InitializeLevelReset = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InitializeLevelReset = true;
            GameObject.Find("TileGenerator").GetComponent<TileGenerator>().SpawnTile = true;
            LevelEndDirector director = FindObjectOfType<LevelEndDirector>();
            director.GenerateFeedback();
        }
    }
}
