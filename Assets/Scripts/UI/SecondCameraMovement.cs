using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z);
    }

    public void SetTarget(Transform targetPosition)
    {
        _target = targetPosition;
    }
}
