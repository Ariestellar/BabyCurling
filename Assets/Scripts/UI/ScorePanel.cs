using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private ParticipantСell _playerCell;
    [SerializeField] private ParticipantСell[] _participantCell;

    private void Awake()
    {       
        //Установка значений остальных участников, для тестов
        _participantCell[0].SetNumberPoints(100);
        _participantCell[1].SetNumberPoints(55);
        _participantCell[2].SetNumberPoints(5);
    }
    public void SetNumberPlayerPoints(int numberPoints)
    {
        _playerCell.SetNumberPoints(numberPoints);
        ChangePositionTable(numberPoints);
    }

    private void ChangePositionTable(int numberPointsPlayer)
    {        
        int positionPlayerCell = 0;
        for (int i = 0; i < _participantCell.Length; i++)
        {
            if (_participantCell[i].GetNumberPoints() >= numberPointsPlayer)
            {
                positionPlayerCell = i + 1;
            }
            _playerCell.transform.SetSiblingIndex(positionPlayerCell);
        }
    }
}
