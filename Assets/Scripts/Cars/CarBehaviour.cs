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

    [SerializeField] private CarColliderCheck _carCheck;
    [SerializeField] private TrafficLightDetection _trafficLightDetection_Close;
    [SerializeField] private TrafficLightDetection _trafficLightDetection_Far;
    [SerializeField] private GameObject _carPriorityChecker;
    //[SerializeField] private CarColliderCheck _player_TrafficLightCheck;
    //[SerializeField] private CarColliderCheck _player_TrafficLightCheckClose;

    private bool _isCarInRange;
    private bool _isPlayerInRange;
    private bool _isPlayerClose;
    private bool _isStoppingTrafficLightNearby;
    private bool _isTrafficLightRedClose;
    private bool _isGivingPriority;

    public void Start()
    {
        _maxSpeed = _speed;
    }

    private void Update()
    {
        SetBools();
        SetSpeed();
        //Debug.Log(gameObject.GetInstanceID() + " " + gameObject.transform.forward);
    }

    private void SetBools()
    {
        //_isPlayerClose = _player_TrafficLightCheckClose._isActive[0];
        //_isPlayerInRange = _player_TrafficLightCheck._isActive[0];

        _isCarInRange = _carCheck._isActive[0];
        //_isTrafficLightRedClose = _player_TrafficLightCheckClose._isActive[1];
        //_isTrafficLightRed = _player_TrafficLightCheck._isActive[1];

        _isStoppingTrafficLightNearby = _trafficLightDetection_Close.HasDetectedStoppingTrafficLight;
    }

    private void SetSpeed()
    {
        if (_speed <= 0.1) _speed = 0;

        if ( _isStoppingTrafficLightNearby || _isCarInRange || _isGivingPriority)
        {
            Stop();
        }
        else if (_isPlayerInRange)
        {
            _speed -= _maxSpeed / 5 * Time.deltaTime;

            if (_isPlayerClose)
            {
                _speed -= _maxSpeed / 2 * Time.deltaTime;
            }
        }

        else
        {
            Drive();
        }
    }

    public void Drive()
    {
        _speed = _maxSpeed;
    }

    public void Stop()
    {
        _speed = 0;
    }

    public void GivePriority(bool toGivePriority)
    {
        if(toGivePriority == true)
        {
            _isGivingPriority = true;
        }
        else
        {
            _isGivingPriority = false;
        }
    }

    //public void IsGettingPriority(bool )

    public void AllowPriorityAwareness(bool toAllow)
    {
        if(toAllow)
        {
            _carPriorityChecker.SetActive(true);
        }
        else
        {
            _carPriorityChecker.SetActive(false);
        }
    }
}
