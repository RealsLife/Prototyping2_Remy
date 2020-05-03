using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Car Spawner")]
public class CarFactory : ScriptableObject
{
    public GameObject[] CarPrefabs;
    public ColorGenerator MyColorGenerator;

    public void SpawnCar(Vector3 position, Vector3 forwardDirection, CarSpawnerBehaviour carSpawnerOrigin)
    {
        GameObject carToSpawn = CarPrefabs[Random.Range(0, CarPrefabs.Length)];
        
        Quaternion carLookDirection = GetForwardDirection(carToSpawn, forwardDirection);

        carToSpawn = GameObject.Instantiate(carToSpawn, position, carLookDirection);
        carToSpawn.GetComponent<PathFollow>().CarSpawnerOrigin = carSpawnerOrigin;
        AssignColorToCar(carToSpawn);
    }

    private Quaternion GetForwardDirection(GameObject car, Vector3 forwardDirection)
    {
        Quaternion forwardRotation = Quaternion.LookRotation(forwardDirection, car.transform.up);

        return forwardRotation;
    }

    private void AssignColorToCar(GameObject car)
    {
        MeshRenderer carMeshRenderer = car.GetComponentInChildren<MeshRenderer>();
        carMeshRenderer.materials[0].SetColor("_BaseColor", MyColorGenerator.GenerateColor());
    }
}
