using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Vector2 _startTouch;
    [SerializeField] private Vector2 _endTouch;
    [SerializeField] private float _distance;
    [SerializeField] private GameObject _arrowPrefab;      
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameObject _indicatorPullingForce;

    private GameObject _currentArrow;
    private Image _currentArrowImage;
    private int _pullingForce;
    private Projectile _currentProjectile;    
    private Text _indicatorPullingForceText;    

    public Action startLevel;

    private void Awake()
    {
        _indicatorPullingForceText = _indicatorPullingForce.GetComponentInChildren<Text>();
    }

    public void SetProjectile(Projectile currentProjectile)
    {
        _currentProjectile = currentProjectile;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_currentProjectile != null && DataGame.isMainMenu == false)
        {
            _indicatorPullingForce.SetActive(true);
            _currentProjectile.PreparationForLaunch();
            _startTouch = eventData.position;
            if (_currentArrow != null)
            {
                Destroy(_currentArrow);
            }
            else if(_currentArrow == null)
            {
                _currentArrow = Instantiate(_arrowPrefab, _startTouch, Quaternion.identity, transform);
                _currentArrowImage = _currentArrow.GetComponent<Image>();
            }            
        }                
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_currentProjectile != null && DataGame.isMainMenu == false)
        {
            _endTouch = eventData.position;
            Vector2 target = _startTouch -_endTouch;
            
            float angleBetween = Vector2.SignedAngle(target.normalized, Vector2.up);            

            _distance = target.magnitude;
            if (_distance != 0)
            {                
                var _direction = target / _distance;
                _currentArrow.transform.right = _direction;                
                _currentProjectile.RotateForwardDirection(angleBetween);//сравнить угол и врaщать по Y оси                
            }
            _currentArrowImage.fillAmount = _distance / 500;
            _pullingForce = (int)(_currentArrowImage.fillAmount * 10);
            _indicatorPullingForceText.text = "" + _pullingForce;

            //дистанция 50 = 1 сила => 100 = 2 силы итд..
            if (_distance > 50)
            {
                _currentProjectile.AnimationStateGo(true);                
            }
            else 
            {
                _currentProjectile.AnimationStateGo(false);                
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_currentProjectile != null && DataGame.isMainMenu == false)
        {            
            if (_pullingForce != 0)
            {                
                _currentProjectile.Launch(_pullingForce);
                _currentProjectile = null;
            }
            _indicatorPullingForce.SetActive(false);
            Destroy(_currentArrow);
        }
        else
        {
            DataGame.isMainMenu = false;
            startLevel.Invoke();
        }
    }
}
