using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFollow))]
public class CarBehaviour : MonoBehaviour
{
    public float Speed { get { return _speed; }}

    [SerializeField] private float _speed;
    private float _maxSpeed;

    [SerializeField] private GameObject _carCheck;
    [SerializeField] private GameObject _player_TrafficLightCheck;
    [SerializeField] private GameObject _player_TrafficLightCheckClose;

    private bool _isCarInRange;
    private bool _isPlayerInRange;
    private bool _isPlayerClose;
    private bool _isTrafficLightRed;
    private bool _isTrafficLightRedClose;

    public void Start()
    {
        _maxSpeed = _speed;
    }

    private void Update()
    {
        SetBools();
        SetSpeed();
        //Movement();
    }

    private void SetBools()
    {
        _isPlayerInRange = _player_TrafficLightCheck.GetComponent<CarColliderCheck>()._isActive[0];
        _isCarInRange = _carCheck.GetComponent<CarColliderCheck>()._isActive[0];
        _isPlayerClose = _player_TrafficLightCheckClose.GetComponent<CarColliderCheck>()._isActive[0];
        _isTrafficLightRed = _player_TrafficLightCheck.GetComponent<CarColliderCheck>()._isActive[1];
        _isTrafficLightRedClose = _player_TrafficLightCheckClose.GetComponent<CarColliderCheck>()._isActive[1];
    }

    private void SetSpeed()
    {
        if (_speed <= 0.1) _speed = 0;

        if (_isCarInRange)
        {
            _speed = 0;
        }else if (_isPlayerInRange || _isTrafficLightRed)
        {
            _speed -= _maxSpeed/5 * Time.deltaTime;

            if (_isPlayerClose)
            {
                _speed -= _maxSpeed /2 * Time.deltaTime;
            }
        }      

        else _speed = _maxSpeed; 
    }

    private void Movement()
    {
        this.transform.position += this.transform.forward * _speed * Time.deltaTime;
    }

}
