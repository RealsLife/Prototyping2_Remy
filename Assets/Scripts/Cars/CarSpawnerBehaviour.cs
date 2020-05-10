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
    private bool _isAbleToSpawnCars = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar());
        if(_spawnSingleCarOnPlay)
        {
            factory.SpawnCar(this.transform.position, transform.forward, this, this.gameObject);
            IncreaseAmountOfCars();
        }
    }

    void Update()
    {
        //LimitAmountOfCarsToMaximum();
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            if (_spawnCars && _isAbleToSpawnCars)
            {
                if (_currentAmountOfCarsSpawned < _maximumAmountOfCars)
                {
                    factory.SpawnCar(this.gameObject.transform.position, transform.forward, this, this.gameObject);
                    IncreaseAmountOfCars();
                    
                }
                yield return new WaitForSeconds(_secondsBetweenSpawns);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void LimitAmountOfCarsToMaximum()
    {
        if (_currentAmountOfCarsSpawned < _maximumAmountOfCars)
        {
            _isAbleToSpawnCars = true;
        }
        else
        {
            _isAbleToSpawnCars = false;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.CompareTag("Car"))
        {
            //Debug.Log("CAR FOUND");
            _isAbleToSpawnCars = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("Car"))
        {
            Debug.Log("CAR EXIT");
            _isAbleToSpawnCars = true;
        }
    }
}
