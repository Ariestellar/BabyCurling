using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _button;
    [SerializeField] private Text _textResult;

    //[SerializeField] private Sprite _imageDefeat;
    [SerializeField] private Sprite _buttonImageDefeat;
    //[SerializeField] private Sprite _imageVictory;
    [SerializeField] private Sprite _buttonimageVictory;
    [SerializeField] private Text _totalScore;
    [SerializeField] private PartyPanelResultPanel _partyPane;

    public void Show(StateGame stateGame, int totalScore)
    {
        _partyPane.SetActualPartyPanel();
        if (SceneManager.sceneCountInBuildSettings > DataGame.currentLevel)
        {
            if (stateGame == StateGame.Victory)
            {
                //_image.sprite = _imageVictory;
                _textResult.text = "VICTORY";
                _button.sprite = _buttonimageVictory;
                _totalScore.text = "TOTAL SCORE: " + totalScore;
            }
            else if (stateGame == StateGame.Defeat)
            {
                //_image.sprite = _imageDefeat;
                _textResult.text = "LOW SCORE";
                _button.sprite = _buttonImageDefeat;
                _totalScore.text = "TOTAL SCORE: " + totalScore;
            }
        }
        else
        {
            //_resultText.text = "End demo :(";
        }
    }
}
