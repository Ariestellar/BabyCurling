using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameManager;
    [SerializeField] private int _countPoint;
    [SerializeField] private int _countHitPoint;
    private void OnTriggerEnter(Collider other)
    {           
        if (other.gameObject.tag == "HitPoint")
        {
            _countHitPoint += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HitPoint")
        {
            _countHitPoint -= 1;
        }
    }
}
