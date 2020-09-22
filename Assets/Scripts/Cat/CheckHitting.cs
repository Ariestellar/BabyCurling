using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHitting : MonoBehaviour
{
    [SerializeField] private bool _hittingZone;
    [SerializeField] private ColorTargetAndCats _colorTarget;

    public ColorTargetAndCats ColorTarget => _colorTarget;
    public bool HittingZone => _hittingZone;

    public void Init(int colorTarget)
    {
        _colorTarget = (ColorTargetAndCats)colorTarget;
    }

    public void SetHittingZone(bool value)
    {
        _hittingZone = value;
    }
}
