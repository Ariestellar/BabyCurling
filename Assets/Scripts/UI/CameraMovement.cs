using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private bool _isReturnToStartPosition;
    [SerializeField] private bool _isMovementForProjectile;
    [SerializeField] private int _speedRotateGo;
    [SerializeField] private int _speedRotateReturn;    
    [SerializeField] private StateGame _stateGame;    

    private float _smooth = 1.0f;
    private Vector3 _offset = new Vector3(0, 15, -10);

    private void Awake()
    {
        _stateGame = StateGame.During;
    }

    private void FixedUpdate()
    {
        if (_isMovementForProjectile && _target != null)
        {            
            if (_stateGame == StateGame.Victory || _stateGame == StateGame.Defeat)//при проигрыше или выйгрыше сменить положение камеры
            {
                _speedRotateGo = 1;
                _isReturnToStartPosition = false;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 5, transform.position.z), 0.5f);                 
                transform.RotateAround(transform.position, Vector3.left, _speedRotateGo);
                if (transform.rotation.eulerAngles.x <= 0)
                {                    
                    _speedRotateGo = 0;
                    _stateGame = StateGame.EndDemo;
                }
            }
            else if(_stateGame == StateGame.During)//В процессе игры если есть снаряд то следуем за ним
            {
                transform.position = _target.position + _offset;
                transform.RotateAround(transform.position, Vector3.left, _speedRotateGo);
                if (transform.rotation.eulerAngles.x <= 40)
                {
                    _speedRotateGo = 0;
                }
            }            
        }

        if (_isReturnToStartPosition)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition.position, Time.deltaTime * _smooth);
            transform.rotation = _startPosition.rotation;

            if (Vector3.Distance(transform.position, _startPosition.position) <= 0.1)
            {
                _isReturnToStartPosition = false;                
            }
        }
    }

    public void SetTarget(Transform targetPosition)
    {
        _target = targetPosition;        
    }

    public void DeleteTarget()
    {
        _target = null;
    }

    public void ReturnPosition()
    {                           
        _isMovementForProjectile = false;
        _isReturnToStartPosition = true;        
    }

    public void ForProjectile()
    {
        _isMovementForProjectile = true;
        _speedRotateGo = 1;
    }

    public void SetStateGame(StateGame stateGame)
    {
        _stateGame = stateGame;
    }
}