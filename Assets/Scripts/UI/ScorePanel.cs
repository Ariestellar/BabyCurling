using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text _playerScore;//Временное решение

    //Временное решение
    public void SetTextPlayerScore(int score)
    {
        _playerScore.text = Convert.ToString(score);
    }
}
