using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private string _horizontalInputName;
    [SerializeField] private string _verticalInputName;
    [SerializeField] private float _movementSpeed;

    private UnityEngine.CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<UnityEngine.CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        //Type Horizonatal
        float horizInput = Input.GetAxis(_horizontalInputName) * _movementSpeed;
        //Type Vertical
        float vertInput = Input.GetAxis(_verticalInputName) * _movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {                      
            charController.Move(Vector3.up  * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
    }
}
