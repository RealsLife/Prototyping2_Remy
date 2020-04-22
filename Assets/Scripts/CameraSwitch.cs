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

    private void Start()
    {
        TPS.enabled = true;
        FPS.enabled = false;
        CharacterAnimator.SetBool("Idle", true);
    }
    private void Update()
    {
        if (Input.GetKeyDown("space")) //reset camera's
        {
            TPS.enabled = true;
            FPS.enabled = false;
            CharacterAnimator.SetBool("Idle", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TPSCamera"))
        {
            Debug.Log("test");

            TPS.enabled = false;
            FPS.enabled = true;
            CharacterAnimator.SetBool("Idle", false);
        }
    }
}
