using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _maxSpeed;

    [SerializeField] private GameObject _carCheck;
    [SerializeField] private GameObject _playerCheck;
    private bool _isCarInRange;
    private bool _isPlayerInRange;

    public void Start()
    {
        _maxSpeed = _speed;
    }

    private void Update()
    {
        SetBools();
        SetSpeed();
        Movement();    
    }

    private void SetBools()
    {
        _isPlayerInRange = _playerCheck.GetComponent<CarColliderCheck>()._isActive;
        _isCarInRange = _carCheck.GetComponent<CarColliderCheck>()._isActive;
    }

    private void SetSpeed()
    {
        if (_isCarInRange)
        {
            _speed = 0;
        }
        else _speed = _maxSpeed; 
    }

    private void Movement()
    {
        this.transform.position += this.transform.forward * _speed * Time.deltaTime;
    }

}
