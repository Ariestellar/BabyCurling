using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekClash : MonoBehaviour
{
    private AudioManager _audioManager;

    public void Init(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            _audioManager.PlayClashWall();
        }        
    }
}
