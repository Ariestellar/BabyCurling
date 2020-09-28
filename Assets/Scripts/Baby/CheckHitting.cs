using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitting : MonoBehaviour
{
    [SerializeField] private bool _hittingZone;
    [SerializeField] private int _countPoint;

    public bool HittingZone => _hittingZone;


    public void ScorePointsForHitting(int countPoint)
    {
        _countPoint += countPoint;
    }

    public void RemovePointsForFallingOut(int countPoint)
    {
        _countPoint -= countPoint;
    }
}
