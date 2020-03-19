using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class PathFollow : MonoBehaviour
{
    public PathCreator PathCreator;
    public EndOfPathInstruction End;
    public float Speed;
    

    private float _distantTravelled;

    // Update is called once per frame
    void Update()
    {
        _distantTravelled += Speed * Time.deltaTime;
        transform.position = PathCreator.path.GetPointAtDistance(_distantTravelled, End);
        transform.rotation = PathCreator.path.GetRotationAtDistance(_distantTravelled, End);
        
       
    }

}
