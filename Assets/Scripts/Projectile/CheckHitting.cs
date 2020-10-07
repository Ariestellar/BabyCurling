using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitting : MonoBehaviour
{   
    private Transform _target;    
    private bool _isHittingZone;
    [SerializeField] private int _numberPoint;
    [SerializeField] private float _distanceToTarget;

    public void Init(Transform targetPosition)
    {
        _target = targetPosition;
    }

    public int GetCountScore(TypesPlayingField typesPlayingField)
    {        
        if (typesPlayingField == TypesPlayingField.RoundGoals) 
        {
            float distanceToTarget = Vector3.Distance(transform.position, _target.position);
            _distanceToTarget = distanceToTarget;
            if (_isHittingZone)
            {
                if (distanceToTarget < 4.5f)
                {
                    _numberPoint = 100;
                }
                else if (distanceToTarget < 11f)
                {
                    _numberPoint = 50;
                }
                else if (distanceToTarget < 16.5f)
                {
                    _numberPoint = 20;
                }
                else
                {
                    _numberPoint = 5;
                }
            }
            else
            {
                _numberPoint = 0;
            }

            return _numberPoint;
        }
        else 
        {
            return _numberPoint;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HittingZone")
        {
            _isHittingZone = true;
        }
        else if(other.gameObject.tag == "HittingZone20")
        {
            _numberPoint = 20;
        }
        else if (other.gameObject.tag == "HittingZone50")
        {
            _numberPoint = 50;
        }
        else if (other.gameObject.tag == "HittingZone100")
        {
            _numberPoint = 100;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HittingZone")
        {
            _isHittingZone = false;
            _numberPoint = 0;
        }        
    }
}
