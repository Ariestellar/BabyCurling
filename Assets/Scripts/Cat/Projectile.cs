using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ProjectileFlight))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Indicators _indicators;
    [SerializeField] private int _pullingForce;
    [SerializeField] private Animator _animationCat;    
    
    private Vector3 _startPositionMouse;
    private CameraMovement _cameraMovement;
    private Camera _camera;
    private Rigidbody _rigidbody;       
    private ProjectileFlight _projectileMovement;
    private AudioManager _audioManager;

    private void Awake()
    {        
        _rigidbody = GetComponent<Rigidbody>();
        _projectileMovement = GetComponent<ProjectileFlight>();
    }

    public void Init(GameSessionCurrentLevel gameSessionCurrentLevel)
    {             
        _camera = gameSessionCurrentLevel.GetMainCamera();
        _cameraMovement = gameSessionCurrentLevel.GetCameraMovement();
        _audioManager = gameSessionCurrentLevel.GetAudioManager();
    }

    public void PreparationForLaunch()
    {
        _indicators.Show();
    }

    public void Launch(int pullingForce)
    {
        _audioManager.PlayNya();
        _indicators.Hide();
        _rigidbody.AddForce(transform.forward * pullingForce * 450);
        //Снаряд запущенн, состояние для проверки окончания его полета
        _projectileMovement.SetStateFlight(true);
        //включаем скрипт слежения камеры что бы проследила за снарядом во время полета
        _cameraMovement.ForProjectile();
        //Выключаем этот скрипт тк больше не нужен
        this.enabled = false;
    }

    public void RotateForwardDirection(float forwardDirection)
    {
        transform.eulerAngles = new Vector3(0, forwardDirection, 0);
    }

    public void AnimationStateGo(bool state)     
    {
        _animationCat.SetBool("go", state);
    }
}
