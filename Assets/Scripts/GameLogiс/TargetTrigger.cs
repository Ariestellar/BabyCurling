using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameManager;
    [SerializeField] private ColorTargetAndCats _colorTarget;
    private void OnTriggerEnter(Collider other)
    {           
        if (other.gameObject.GetComponent<CheckHitting>())
        {
            CheckHitting checkHitting = other.gameObject.GetComponent<CheckHitting>();
            
            if (_colorTarget == ColorTargetAndCats.non || _colorTarget == checkHitting.ColorTarget)
            {
                _gameManager.IncreaseNumberProjectileAtTarget();
                checkHitting.SetHittingZone(true);
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.GetComponent<CheckHitting>())
        {
            CheckHitting checkHitting = other.gameObject.GetComponent<CheckHitting>();

            if (_colorTarget == ColorTargetAndCats.non || _colorTarget == checkHitting.ColorTarget)
            {
                _gameManager.ReduceNumberProjectileAtTarget();
                other.gameObject.GetComponent<CheckHitting>().SetHittingZone(false);
            }                
        }
    }
}
