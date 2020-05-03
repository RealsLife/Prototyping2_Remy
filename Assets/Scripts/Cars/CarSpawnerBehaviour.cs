using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerBehaviour : MonoBehaviour
{
    public CarFactory factory;
    [SerializeField] private float _secondsBetweenSpawns = 1;
    [SerializeField] private bool _spawnCars;
    [SerializeField] private bool _spawnSingleCarOnPlay;
    [Range(1, 50)][SerializeField] private int _maximumAmountOfCars;
    private int _currentAmountOfCarsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar());
        if(_spawnSingleCarOnPlay)
        {
            factory.SpawnCar(this.transform.position, transform.forward, this);
            IncreaseAmountOfCars();
        }
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            if (_spawnCars && IsAbleToSpawnCars())
            {
                yield return new WaitForSeconds(_secondsBetweenSpawns);
                factory.SpawnCar(this.gameObject.transform.position, transform.forward, this);
                IncreaseAmountOfCars();
            }
            else
            {
                yield return null;
            }
        }
    }

    private bool IsAbleToSpawnCars()
    {
        if(_currentAmountOfCarsSpawned < _maximumAmountOfCars)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseAmountOfCars()
    {
        _currentAmountOfCarsSpawned++;
    }

    public void DecreaseAmountOfCars()
    {
        _currentAmountOfCarsSpawned--;
    }
}
