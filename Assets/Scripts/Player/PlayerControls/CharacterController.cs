using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent((typeof(PlayerInput)))]
public class CharacterController : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private float _movementSpeed;

    private UnityEngine.CharacterController charController;
    private Vector2 _inputMove;

    private void Awake()
    {
        _playerInput = gameObject.GetComponent<PlayerInput>();
        charController = GetComponent<UnityEngine.CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _inputMove = context.ReadValue<Vector2>();
    }

    

    private void Move()
    {
        ////Type Horizonatal
        //float horizInput = Input.GetAxis(_horizontalInputName) * _movementSpeed;
        ////Type Vertical
        //float vertInput = Input.GetAxis(_verticalInputName) * _movementSpeed;

        //Vector3 forwardMovement = transform.forward * InputController.CharacterForward + (-transform.forward * InputController.CharacterBackward);
        ////Vector3 rightMovement = transform.right * ;

        Vector3 movement = new Vector3(_inputMove.x, 0, _inputMove.y) * this._movementSpeed;

        charController.SimpleMove(movement); //forwardMovement /*+ rightMovement*/);
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
