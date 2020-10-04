using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitting : MonoBehaviour
{
    //[SerializeField] private bool _hittingZone;
    //[SerializeField] private int _countPoint;
    //public bool HittingZone => _hittingZone;
    private Transform _target;
    private Transform _projectile;
    [SerializeField] private bool _isHittingZone;

    private void Awake()
    {
        _projectile = gameObject.transform;
    }

    public void Init(Transform targetPosition)
    {
        _target = targetPosition;
    }

    public int GetCountScore()
    {
        int countScore = 0;
        float distanceToTarget = Vector3.Distance(_projectile.position, _target.position);
        if (_isHittingZone)
        {
            if (distanceToTarget < 4.5f)
            {
                countScore = 100;
            }
            else if (distanceToTarget < 11f)
            {
                countScore = 50;
            }
            else if (distanceToTarget < 16.5f)
            {
                countScore = 20;
            }
            else
            {
                countScore = 5;
            }
        }
        else
        {
            countScore = 0;
        }       

        return countScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HittingZone")
        {
            _isHittingZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HittingZone")
        {
            _isHittingZone = false;
        }
    }

    /*public void ScorePointsForHitting(int countPoint)
    {
        _countPoint += countPoint;
    }

    public void RemovePointsForFallingOut(int countPoint)
    {
        _countPoint -= countPoint;
    }*/
}
