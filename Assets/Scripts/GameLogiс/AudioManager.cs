using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _babyLaugh;
    [SerializeField] private AudioSource _clashWall;  
    private int _numerAudioBabyLaugh;

    public void PlayNya()
    {        
        if (_numerAudioBabyLaugh > 1)
        {
            _numerAudioBabyLaugh = 0;
        }

        _babyLaugh[_numerAudioBabyLaugh].Play();
        _numerAudioBabyLaugh += 1;
    }
    
    public void PlayClashWall()
    {
        _clashWall.Play();
    }
}
