using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStopper : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float _speedStopped;   
    [SerializeField] private Pusher _pusher;
    [SerializeField] private bool _isStopperObject;

    private Rigidbody _ridgidbodyCurrentCat;
    private ProjectileFlight _currentProjectileFlight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            _ridgidbodyCurrentCat = other.gameObject.GetComponent<Rigidbody>();
            _currentProjectileFlight = other.gameObject.GetComponent<ProjectileFlight>();
            _currentProjectileFlight.SetTemporaryStop(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            if (_ridgidbodyCurrentCat && _isStopperObject == false)
            {
                _ridgidbodyCurrentCat.velocity = Vector3.Lerp(_ridgidbodyCurrentCat.velocity, Vector3.zero, _speedStopped);                
            }

            if (_currentProjectileFlight.GetisStopPlatform() == true)
            {
                _pusher.Launch();
                _isStopperObject = true;
            }
        }            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cat")
        {
            _currentProjectileFlight.SetTemporaryStop(false);
            _currentProjectileFlight = null;
            _ridgidbodyCurrentCat = null;
            _isStopperObject = false;                     
        }
    }
}
