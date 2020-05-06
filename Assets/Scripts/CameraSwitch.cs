using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraSwitch : MonoBehaviour
{
    public Camera FPS;
    public Camera TPS;
    public Animator CharacterAnimator;
    public PathCreator PathCreator;
    public GameObject Character;
    public CameraController CameraController;
    public bool EnterTrigger = false;

    static public bool Reset = false;

    public void ResetCamera(bool value)
    {
        Reset = value;
    }

    private void Start()
    {
        TPS = GameObject.Find("TPS Camera").GetComponent<Camera>();
        TPS.enabled = true;
        FPS.enabled = false;
        CharacterAnimator.SetBool("Idle", true);
        Character.GetComponent<CharacterController>().enabled = false;
        CameraController.enabled = false;

    }
    private void Update()
    {
        if (Reset == true) //reset camera's
        {
            TPS.enabled = true;
            FPS.enabled = false;
            CharacterAnimator.SetBool("Idle", true);
            Reset = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TPSCamera"))
        {
            Debug.Log("test");
            EnterTrigger = true;
            TPS.enabled = false;
            FPS.enabled = true;
            CharacterAnimator.SetBool("Idle", false);
            Character.GetComponent<CharacterController>().enabled = true;
            CameraController.enabled = true;
        }
    }
}
