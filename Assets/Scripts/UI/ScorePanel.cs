using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private ParticipantСell _playerCell;
    [SerializeField] private ParticipantСell[] _participantCell;
    [SerializeField] private DataPlayers _dataPlayers;


    private void Awake()
    {       
        //Установка значений остальных участников, для тестов
        _participantCell[0].SetData(_dataPlayers.ScorePlayer1, _dataPlayers.NamePlayer1);
        _participantCell[1].SetData(_dataPlayers.ScorePlayer2, _dataPlayers.NamePlayer2);
        _participantCell[2].SetData(_dataPlayers.ScorePlayer3, _dataPlayers.NamePlayer3);
    }
    public void SetNumberPlayerPoints(int numberPoints)
    {
        _playerCell.SetData(numberPoints, "Player");
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
