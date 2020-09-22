using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators : MonoBehaviour
{
    [SerializeField] private GameObject _directionArrow;
    //[SerializeField] private ForceIndicator _forceIndicator;

    //public ForceIndicator ForceIndicator => _forceIndicator;

    public void Show()
    {
        _directionArrow.SetActive(true);
        //_forceIndicator.ShowArrow();
    }

    public void Hide()
    {
        _directionArrow.SetActive(false);
        //_forceIndicator.HideArrow();
    }
}
