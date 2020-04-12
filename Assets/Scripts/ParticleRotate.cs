using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotate : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;

    private void Update()
    {
        this.transform.Rotate(_rotationSpeed * Vector3.up * Time.deltaTime, Space.Self);
    }
}
