using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private string _horizontalInputName;
    [SerializeField] private string _verticalInputName;
    [SerializeField] private float _movementSpeed;

    private UnityEngine.CharacterController charController;

    [SerializeField] private AnimationCurve _jumpFallOff;
    [SerializeField] private float _jumpMultiplier;
    [SerializeField] private KeyCode _jumpKey;


    private bool isJumping;

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

        JumpInput();

    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(_jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());         
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {           
            float jumpForce = _jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * _jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
