using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraSwitch : MonoBehaviour
{
    public EndOfPathInstruction End;
    public Camera FPS;
    public Camera TPS;

    private void Start()
    {
        TPS.enabled = true;
        FPS.enabled = false;
    }
    void Update()
    {
        if (End == EndOfPathInstruction.Stop)
        {
            TPS.enabled = false;
            FPS.enabled = true;
        }
    }
}
