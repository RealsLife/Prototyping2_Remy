using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private string _mouseXInputName;
    [SerializeField] private float _mouseSensitivity;

    [SerializeField] private Transform _playerBody;

    private float _xAxisClamp;

    private void Awake()
    {
        LockCursor();
        _xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(_mouseXInputName) * _mouseSensitivity * Time.deltaTime;

        if (_xAxisClamp > 90.0f)
        {
            _xAxisClamp = 90.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (_xAxisClamp < -90.0f)
        {
            _xAxisClamp = -90.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        _playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
