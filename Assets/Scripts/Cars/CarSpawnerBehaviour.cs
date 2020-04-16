using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerBehaviour : MonoBehaviour
{
    public CarFactory factory;
    [SerializeField] private bool _spawnCars;
    [SerializeField] private float _secondsBetweenSpawns = 1;
    //[SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private ForwardDirection _forwardDirection;
    //[SerializeField] private PathCreator _carLane;

    public enum ForwardDirection
    {
        WorldForward,
        WorldRight,
        WorldLeft,
        WorldBack
    };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        while (true)
        {
            if (_spawnCars)
            {
                yield return new WaitForSeconds(_secondsBetweenSpawns);
                factory.SpawnCar(this.gameObject.transform.position, _forwardDirection/*, _carLane*/);
            }
            else
            {
                yield return null;
            }
        }
    }
}
