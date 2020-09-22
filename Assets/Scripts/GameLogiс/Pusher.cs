using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] private int _forceLaunch;
    [SerializeField] private bool _isLaunch;    
    [SerializeField] private bool _isRevers;    
    [SerializeField] private DirectionPusher _directionMove;    
    [SerializeField] private Vector3 _directionForce;
    [Range(0,1)][SerializeField] private float _speedRevert;    
    
    private Rigidbody _rigidbody;    
    private Transform _transform;    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

        if (_directionMove == DirectionPusher.right)
        {
            _directionForce = Vector3.right;//не фризить позицию по x
        }
        else if (_directionMove == DirectionPusher.left)
        {
            _directionForce = Vector3.left;//не фризить позицию по x
        }
        else if (_directionMove == DirectionPusher.back)
        {
            _directionForce = Vector3.back;//не фризить позицию по z
        }
        else if (_directionMove == DirectionPusher.forward)
        {
            _directionForce = Vector3.forward;//не фризить позицию по z
        }
        else if (_directionMove == DirectionPusher.diag)
        {
            _directionForce = Vector3.forward + Vector3.left;//не фризить позицию по z
        }
    }

    private void FixedUpdate()
    {  
        if (_isLaunch)
        {            
            if (_transform.localPosition.x > 7)
            {
                Debug.Log("назад");
                _rigidbody.velocity = Vector3.zero;
                _isRevers = true;
            }            
        }

        if (_isRevers)
        {
            _transform.localPosition = Vector3.Lerp(_transform.localPosition, Vector3.zero, 5);
            if (_transform.localPosition == Vector3.zero)
            {
                _isRevers = false;
                _isLaunch = false;
            }
        }
    }

    public void Launch()
    {
        if (_isRevers == false && _isLaunch == false)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(_directionForce * _forceLaunch);
            _isLaunch = true;
            Debug.Log("запуск");
        }        
    }
    public void Stop()
    {
        /*_transform.localPosition = Vector3.zero;*/

        _rigidbody.isKinematic = true;
        //_isRevers = true;
        _isLaunch = false;
        Debug.Log("остановка");
    }

    private void ReverseMovement()
    {
        _isRevers = true;
    }
}
