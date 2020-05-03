using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class CameraFollow : MonoBehaviour
{
    public PathCreator PathCreator;
    public EndOfPathInstruction End;
    public float Speed;
    public bool Reset = false;


    private float _distantTravelled;

    private void Start()
    {


    }

    public void ResetCamera(bool value)
    {
    Reset = value;
    }
    // Update is called once per frame
    void Update()
    {
        PathCreator = GameObject.Find("OrbitCamera").GetComponent<PathCreator>();
        _distantTravelled += Speed * Time.deltaTime;
        transform.position = PathCreator.path.GetPointAtDistance(_distantTravelled, EndOfPathInstruction.Stop);
        transform.rotation = PathCreator.path.GetRotationAtDistance(_distantTravelled, EndOfPathInstruction.Stop);

        if (Reset == true) //reset orbit camera
        {
            _distantTravelled = 0;
 
        }



    }

}
