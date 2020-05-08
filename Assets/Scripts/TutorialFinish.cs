using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFinish : MonoBehaviour
{
    public bool Finish = false;
    public GameObject CharacterController;
    public CameraController CameraController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Finish = true;
            CharacterController.GetComponent<CharacterController>().enabled = false;
            CameraController.enabled = false;
        }
    }
}
