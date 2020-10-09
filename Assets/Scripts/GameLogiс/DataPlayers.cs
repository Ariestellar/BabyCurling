using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataPlayers : ScriptableObject
{
    [Header("Игрок№1")]
    public string NamePlayer1;
    public int ScorePlayer1;
    [Space]
    [Header("Игрок№2")]
    public string NamePlayer2;
    public int ScorePlayer2;
    [Space]
    [Header("Игрок№3")]
    public string NamePlayer3;
    public int ScorePlayer3;
}
