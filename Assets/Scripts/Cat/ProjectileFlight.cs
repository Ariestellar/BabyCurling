using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileFlight : MonoBehaviour
{
    private Action _finishFlight;    
    private bool _isFlight;
    private bool _isTemporaryStop;//временная остановка на платформе
    private bool _isStopPlatform;//снаряд остановился на платформе
    private float _previousPosition;

    public Action FinishFlight { get => _finishFlight; set => _finishFlight = value; }

    private void FixedUpdate()
    {
        //Проверям остановку снаряда после запуска
        if (_isFlight)
        {
            if (transform.position.z == _previousPosition)
            {
                if (_isTemporaryStop)//если это временная остановка то:
                {
                    _isStopPlatform = true;
                }
                else
                {
                    FinishFlight?.Invoke();
                    _isFlight = false;
                    this.enabled = false;//выключаем этот класс за ненадобностью 
                }                
            }
            _previousPosition = transform.position.z;
        }
    }

    public void SetStateFlight(bool isFlight)
    {
        _isFlight = isFlight;
    }

    public void SetTemporaryStop(bool isTemporaryStop)
    {
        _isTemporaryStop = isTemporaryStop;
    }

    public bool GetisStopPlatform()
    {
        return _isStopPlatform;
    }

    private void OnDisable()
    {
        _finishFlight = null;
    }    
}
