using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerBehaviour : MonoBehaviour
{
    public CarFactory factory;
    [SerializeField] private bool _spawnCars;
    [SerializeField] private bool _spawnSingleCarOnPlay;
    [SerializeField] private float _secondsBetweenSpawns = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar());
        if(_spawnSingleCarOnPlay)
        {
            factory.SpawnCar(this.transform.position, transform.forward);
        }
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            if (_spawnCars)
            {
                yield return new WaitForSeconds(_secondsBetweenSpawns);
                factory.SpawnCar(this.gameObject.transform.position, transform.forward);
            }
            else
            {
                yield return null;
            }
        }
    }
}
