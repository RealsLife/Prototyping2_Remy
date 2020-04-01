using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraSwitch : MonoBehaviour
{
    public Camera FPS;
    public Camera TPS;

    private void Start()
    {
        TPS.enabled = true;
        FPS.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TPSCamera"))
        {
            Debug.Log("test");
            TPS.enabled = false;
            FPS.enabled = true;
        }

    }
}
