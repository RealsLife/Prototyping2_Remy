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
    public bool Reset = false;

    private void Start()
    {
        TPS = GameObject.Find("TPS Camera").GetComponent<Camera>();
        TPS.enabled = true;
        FPS.enabled = false;
        CharacterAnimator.SetBool("Idle", true);
    }
    private void Update()
    {
        if (Reset == true) //reset camera's
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
