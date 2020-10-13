using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private GameSessionCurrentLevel _gameSessionCurrentLevel;
    [SerializeField] private GameObject _upPanel;
    [SerializeField] private ScorePanel _scorePanel;
    [SerializeField] private ResultPanel _resultPanel;     
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private GameObject _brifing;
    [SerializeField] private GameObject _buttonMainMenu;
    [SerializeField] private GameObject _tutor;
    [SerializeField] private Text _levelText;
    [SerializeField] private GameObject _secondCameraTopImage;
    [SerializeField] private NameInputDialog _nameInputDialog;

    private void Awake()
    {
        _nameInputDialog.Init(_touchHandler);
    }

    private void Start()
    {
        if (DataGame.isSetNamePlayer == false)
        {
            _nameInputDialog.gameObject.SetActive(true);
            //_touchHandler.gameObject.SetActive(false);//Останавливаем обработчик касаний, при указании  имени запускаем
        }
    }

    public void SetCountScore(int totalScore)
    {
        _scorePanel.SetNumberPlayerPoints(totalScore);
    }

    public void ShowResultPanel(StateGame stateGame, int totalScore)
    {
        _scorePanel.gameObject.SetActive(false);
        _secondCameraTopImage.SetActive(false);
        _resultPanel.Show(stateGame, totalScore);
        _resultPanel.gameObject.SetActive(true);
    }

    public void ShowBrifing()
    {
        _brifing.SetActive(true);
    }

    public void ShowLifePanel()
    {
        _upPanel.SetActive(true);
    }

    public void HideResultPanel()
    {
        _resultPanel.gameObject.SetActive(false);
    }

    public void HideButtonMainMenu()
    {        
        _buttonMainMenu.SetActive(false);
        _tutor.SetActive(false);
        _secondCameraTopImage.SetActive(true);
    }

    public void ButtonContinueLevel()
    {
        _gameSessionCurrentLevel.ContinueLevel();
    }

    public void ButtonResetLevel()
    {
        _gameSessionCurrentLevel.ResetLevel();
    }

    public TouchHandler GetTouchHandler()
    {
        return _touchHandler;
    }

    public void SetTextLevel(int currentLevel)
    {
        _levelText.text = "Level " + currentLevel;
    }

    public DataPlayers GetDataPlayers()
    {
        return _scorePanel.GetDataPlayers();
    }

    public NameInputDialog GetNameInputDialog()
    {
        return _nameInputDialog;
    }
}
