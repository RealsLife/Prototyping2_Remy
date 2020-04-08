using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Car Spawner")]
public class CarFactory : ScriptableObject
{
    public GameObject[] CarPrefabs;
    public ColorGenerator MyColorGenerator;

    public void SpawnCar(Vector3 position, CarSpawnerBehaviour.ForwardDirection forward)
    {
        GameObject carToSpawn = CarPrefabs[Random.Range(0, CarPrefabs.Length)];
        
        Quaternion forwardDirection = GetForwardDirection(carToSpawn, forward);

        carToSpawn = GameObject.Instantiate(carToSpawn, position, forwardDirection);
        AssignColorToCar(carToSpawn);
    }

    private Quaternion GetForwardDirection(GameObject car, CarSpawnerBehaviour.ForwardDirection forward)
    {
        Quaternion forwardRotation = Quaternion.identity;
        Vector3 forwardVector = Vector3.zero;

        switch (forward)
        {
            case CarSpawnerBehaviour.ForwardDirection.WorldForward:
                forwardVector = Vector3.forward;
                break;

            case CarSpawnerBehaviour.ForwardDirection.WorldBack:
                forwardVector = Vector3.back;
                break;

            case CarSpawnerBehaviour.ForwardDirection.WorldLeft:
                forwardVector = Vector3.left;
                break;
            case CarSpawnerBehaviour.ForwardDirection.WorldRight:
                forwardVector = Vector3.right;
                break;
        }

        forwardRotation = Quaternion.LookRotation(forwardVector, car.transform.up);

        return forwardRotation;
    }

    private void AssignColorToCar(GameObject car)
    {
        MeshRenderer carMeshRenderer = car.GetComponent<MeshRenderer>();
        carMeshRenderer.materials[0].SetColor("_BaseColor", MyColorGenerator.GenerateColor());
    }
}
