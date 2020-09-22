using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _nya;
    [SerializeField] private AudioSource _clashWall;   
    public void PlayNya()
    {
        _nya.Play();
    }
    
    public void PlayClashWall()
    {
        _clashWall.Play();
    }
}
