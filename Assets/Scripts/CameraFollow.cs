using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class CameraFollow : MonoBehaviour
{
    public PathCreator PathCreator;
    public EndOfPathInstruction End;
    public float Speed;
    

    private float _distantTravelled;

    // Update is called once per frame
    void Update()
    {

        _distantTravelled += Speed * Time.deltaTime;
        transform.position = PathCreator.path.GetPointAtDistance(_distantTravelled, EndOfPathInstruction.Stop);
        transform.rotation = PathCreator.path.GetRotationAtDistance(_distantTravelled, EndOfPathInstruction.Stop);

        if (Input.GetKeyDown("space")) //reset orbit camera
        {
            _distantTravelled = 0;
 
        }



    }

}
