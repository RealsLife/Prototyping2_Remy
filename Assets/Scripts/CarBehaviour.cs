using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public float Speed = 5;

    private void Update()
    {
        this.transform.position += this.transform.forward * Speed * Time.deltaTime;
    }
}
