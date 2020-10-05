using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticipantСell : MonoBehaviour
{   
    [SerializeField] private Text _name;
    [SerializeField] private Text _scoreText;

    private int _numberPoints;

    public void SetNumberPoints(int numberPoints)
    {
        _numberPoints = numberPoints;
        _scoreText.text = Convert.ToString(_numberPoints);
    }

    public int GetNumberPoints()
    {
        return _numberPoints;
    }
}
